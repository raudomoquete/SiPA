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


        public ParishionersController(
            DataContext context,
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
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
                .Include(p => p.User)
                .Include(p => p.Sacraments)
                .ThenInclude(p => p.Parishioner)
                .Include(p => p.Histories)                
                .FirstOrDefaultAsync(o => o.Id == id.Value);
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
                    ReceivedSacraments = model.ReceivedSacraments,
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
                DateOfBirth = parishioner.User.DateOfBirth,
                Nationality = parishioner.User.Nationality,
                Address = parishioner.User.Address,
                ReceivedSacraments = parishioner.User.ReceivedSacraments,
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
                parishioner.User.ReceivedSacraments = view.ReceivedSacraments;
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
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (parishioner == null)
            {
                return NotFound();
            }

            _context.Parishioners.Remove(parishioner);
            await _context.SaveChangesAsync();
            await _userHelper.DeleteUserAsync(parishioner.User.Email);
            return RedirectToAction($"{nameof(Index)}");
        }

        // POST: Parishioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parishioner = await _context.Parishioners.FindAsync(id);
            _context.Parishioners.Remove(parishioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParishionerExists(int id)
        {
            return _context.Parishioners.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddSacrament(int? id)
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

            var model = new SacramentViewModel
            {
                ParishionerId = parishioner.Id,
                Sacraments = _combosHelper.GetComboSacraments()
            };

            return View(model);
        }

        //sobrecarga del metodo AddSacrament
        [HttpPost]
        public async Task<IActionResult> AddSacrament(SacramentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sacrament = await _converterHelper.ToSacramentAsync(model, true);
                _context.Sacraments.Add(sacrament);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.Sacraments = _combosHelper.GetComboSacraments();
            return View(model);
        }

        public async Task<IActionResult> EditSacrament(int? id)
        {
            if (id == null)
            {
               return NotFound();
            }

            var sacrament = await _context.Sacraments
                .Include(s => s.Parishioner)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToSacramentViewModel(sacrament));
        }

        [HttpPost]
        public async Task<IActionResult> EditSacrament(SacramentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sacrament = await _converterHelper.ToSacramentAsync(model, false);
                _context.Sacraments.Update(sacrament);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.Sacraments = _combosHelper.GetComboSacraments();
            return View(model);
        }

        public async Task<IActionResult> DetailsSacrament(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacraments
                .Include(s => s.Parishioner)
                .ThenInclude(o => o.User)
                .Include(s => s.Parishioner)
                .ThenInclude(s => s.Histories)
                .ThenInclude(h => h.RequestType)               
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(sacrament);
        }

        public async Task<IActionResult> AddHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacraments.FindAsync(id.Value);
            if (sacrament == null)
            {
                return NotFound();
            }

            var model = new HistoryViewModel
            {
                Date = DateTime.Now,
                SacramentId = sacrament.Id,
                RequestTypes = _combosHelper.GetComboSacraments(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHsitory(HistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = await _converterHelper.ToHistoryAsync(model, true);
                _context.Histories.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(DetailsSacrament)}/{model.SacramentId}");
            }

            model.RequestTypes = _combosHelper.GetComboRequestTypes();
            return View(model);
        }

        public async Task<IActionResult> EditHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Sacrament)
                .Include(h => h.RequestType)
                .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (history == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToHistoryViewModel(history));
        }

        [HttpPost]
        public async Task<IActionResult> EditHistory(HistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = await _converterHelper.ToHistoryAsync(model, false);
                _context.Histories.Update(history);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(DetailsSacrament)}/{model.SacramentId}");
            }

            model.RequestTypes = _combosHelper.GetComboRequestTypes();
            return View(model);
        }

        public async Task<IActionResult> DeleteHistory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Sacrament)
                .FirstOrDefaultAsync(h => h.Id == id.Value);
            if (history == null)
            {
                return NotFound();
            }

            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsSacrament)}/{history.Sacrament.Id}");
        }
    }
}
