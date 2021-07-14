using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using SiPA.Web.Models;

namespace SiPA.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ParishionersController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ISacramentHelper _sacramentHelper;


        public ParishionersController(
            DataContext context,
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper,
            ISacramentHelper sacramentHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _sacramentHelper = sacramentHelper;
        }

        // GET: Parishioners
        public IActionResult Index()
        {
            return View(_context.Parishioners
                .Include(o => o.User)
                .Include(o => o.Sacraments));
            //(await _context.Parishioners.ToListAsync());
        }

        // GET: Parishioners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parishioner = await _context.Parishioners
                .Include(p => p.Histories)
                .Include(p => p.User)
                .Include(p => p.Sacraments)
                .ThenInclude(s => s.SacramentType)
                .Include(p => p.Sacraments)
                .ThenInclude(s => s.Christening)                
                .FirstOrDefaultAsync(m => m.Id == id);
              
            if (parishioner == null)
            {
                return NotFound();
            }

            return View(parishioner);
        }

        // GET: Parishioners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parishioners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Address = model.Address,
                    Email = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Identification = model.Identification,
                    DateOfBirth = model.DateOfBirth,
                    Nationality = model.Nationality,
                    PhoneNumber = model.PhoneNumber,
                    CivilStatus = model.CivilStatus,
                    UserName = model.UserName
                };

                var response = await _userHelper.AddUserAsync(user, model.Password);
                if (response.Succeeded)
                {
                    var userInDB = await _userHelper.GetUserByEmailAsync(model.UserName);
                    await _userHelper.AddUserToRoleAsync(userInDB, "Customer");


                    var parishioner = new Parishioner
                    {
                        Requests = new List<Request>(),
                        Sacraments = new List<Sacrament>(),
                        User = userInDB
                    };

                    _context.Parishioners.Add(parishioner);

                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                    }
                }

                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }

            return View(model);
        }

        // GET: Parishioners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parishioner = await _context.Parishioners
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (parishioner == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                FirstName = parishioner.User.FirstName,
                LastName = parishioner.User.LastName,
                Identification = parishioner.User.Identification,
                DateOfBirth = (DateTime)parishioner.User.DateOfBirth,
                Nationality = parishioner.User.Nationality,
                Address = parishioner.User.Address,
                Id = parishioner.Id,
                CivilStatus = parishioner.User.CivilStatus,
                PhoneNumber = parishioner.User.PhoneNumber
            };

            return View(model);
        }

        // POST: Parishioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var parishioner = await _context.Parishioners
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == view.Id);
                parishioner.User.FirstName = view.FirstName;
                parishioner.User.LastName = view.LastName;
                parishioner.User.Identification = view.Identification;
                parishioner.User.DateOfBirth = view.DateOfBirth;
                parishioner.User.Nationality = view.Nationality;
                parishioner.User.Address = view.Address;
                parishioner.User.CivilStatus = view.CivilStatus;
                parishioner.User.PhoneNumber = view.PhoneNumber;

                await _userHelper.UpdateUserAsync(parishioner.User);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        // GET: Parishioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parishioner = await _context.Parishioners
                .Include(p => p.User)
                .Include(p => p.Sacraments)
                .ThenInclude(s => s.Christening)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (parishioner == null)
            {
                return NotFound();
            }

            if (parishioner.Sacraments.Count > 0)
            {
                ModelState.AddModelError(string.Empty, "El Feligrés no puede ser borrado porque tiene records relacionados.");
                return RedirectToAction(nameof(Index));
            }

            await _userHelper.DeleteUserAsync(parishioner.User.Email);
            _context.Parishioners.Remove(parishioner);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Index)}");
        }

        private bool ParishionerExists(int id)
        {
            return _context.Parishioners.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parishioner = await _context.Parishioners.FindAsync(id.Value);

            if (parishioner == null)
            {
                return NotFound();
            }

            var model = new ChristeningViewModel
            {
                CreatedAt = DateTime.Today,
                ParishionerId = parishioner.Id,
                //SacramentTypes = _combosHelper.GetComboSacraments()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddChristening(ChristeningViewModel model)
        {
            if (ModelState.IsValid)
            {
                var christening = await _converterHelper.ToChristeningAsync(model, true);
                _context.Christenings.Add(christening);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(c => c.Parishioner)
                .Include(c => c.SacramentType)
                .FirstOrDefaultAsync(c => c.Id == id);
               
            if (christening == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToChristeningViewModel(christening));
        }

        [HttpPost]
        public async Task<IActionResult> EditChristening(ChristeningViewModel model)
        {
            if (ModelState.IsValid)
            {
                var christening = await _converterHelper.ToChristeningAsync(model, false);
                _context.Christenings.Update(christening);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.SacramentTypes = _combosHelper.GetComboSacraments();
            return View(model);
        }

        public async Task<IActionResult> DetailsChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(s => s.Parishioner)
                .ThenInclude(o => o.User)
                .Include(s => s.Parishioner)
                .ThenInclude(s => s.Histories)
                .ThenInclude(h => h.RequestType)               
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (christening == null)
            {
                return NotFound();
            }

            return View(christening);
        }

        //public async Task<IActionResult> AddHistory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sacrament = await _context.Sacraments.FindAsync(id.Value);
        //    if (sacrament == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new HistoryViewModel
        //    {
        //        Date = DateTime.Now,
        //        SacramentId = sacrament.SacramentId,
        //        RequestTypes = _combosHelper.GetComboSacraments(),
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddHsitory(HistoryViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var history = await _converterHelper.ToHistoryAsync(model, true);
        //        _context.Histories.Add(history);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"{nameof(DetailsSacrament)}/{model.SacramentId}");
        //    }

        //    model.RequestTypes = _combosHelper.GetComboRequestTypes();
        //    return View(model);
        //}

        //public async Task<IActionResult> EditHistory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var history = await _context.Histories
        //        .Include(h => h.Sacrament)
        //        .Include(h => h.RequestType)
        //        .FirstOrDefaultAsync(s => s.Id == id.Value);
        //    if (history == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_converterHelper.ToHistoryViewModel(history));
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditHistory(HistoryViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var history = await _converterHelper.ToHistoryAsync(model, false);
        //        _context.Histories.Update(history);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"{nameof(DetailsSacrament)}/{model.SacramentId}");
        //    }

        //    model.RequestTypes = _combosHelper.GetComboRequestTypes();
        //    return View(model);
        //}

        //public async Task<IActionResult> DeleteHistory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var history = await _context.Histories
        //        .Include(h => h.Sacrament)
        //        .FirstOrDefaultAsync(h => h.Id == id.Value);
        //    if (history == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Histories.Remove(history);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction($"{nameof(DetailsSacrament)}/{history.Sacrament.SacramentId}");
        //}

        //public async Task<IActionResult> AddChristening(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var parishioner = await _context.Parishioners.FindAsync(id.Value);
        //    if (parishioner == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new ChristeningViewModel
        //    {
        //        ChristeningDate = DateTime.Today,
        //        ParishionerId = parishioner.Id,
        //        Parishioners = _combosHelper.GetComboParishioners()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddChristening(ChristeningViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var christening = await _converterHelper.ToChristeningAsync(model, true);
        //        _context.Christenings.Add(christening);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"Details/{model.ParishionerId}");
        //    }

        //    model.Parishioners = _combosHelper.GetComboParishioners();
        //    return View(model);
        //}

        //public async Task<IActionResult> EditChristening(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var christening = await _context.Christenings
        //        .Include(c => c.Parishioner)
        //        .FirstOrDefaultAsync(c => c.Id == id);
        //    if (christening == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_converterHelper.ToChristeningViewModel(christening));
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditChristening(ChristeningViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var christening = await _converterHelper.ToChristeningAsync(model, false);
        //        _context.Christenings.Update(christening);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction($"Details/{model.ParishionerId}");
        //    }

        //    model.Parishioners = _combosHelper.GetComboParishioners();
        //    return View(model);
        //}

        //public async Task<IActionResult> DetailsChristening(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var christening = await _context.Christenings
        //        .Include(c => c.Parishioner)
        //        .ThenInclude(p => p.User)
        //        .FirstOrDefaultAsync(p => p.Id == id.Value);
        //    if (christening == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(christening);
        //}
    }
}
