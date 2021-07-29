using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiPA.Web.ActionFilter;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using SiPA.Web.Models;
using static SiPA.Web.ActionFilter.SetTempDataModelStateAttribute;

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
                .Include(p => p.User)
                .Include(p => p.Christenings)
                .Include(p => p.FirstCommunions)
                .Include(p => p.Confirmations));

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
                .Include(p => p.Christenings)
                .Include(p => p.FirstCommunions)
                .Include(p => p.Confirmations)
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
                        SacramentTypes = new List<SacramentType>(),
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parishioner = await _context.Parishioners
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

                parishioner.User.FirstName = model.FirstName;
                parishioner.User.LastName = model.LastName;
                parishioner.User.Identification = model.Identification;
                parishioner.User.DateOfBirth = model.DateOfBirth;
                parishioner.User.Nationality = model.Nationality;
                parishioner.User.Address = model.Address;
                parishioner.User.CivilStatus = model.CivilStatus;
                parishioner.User.PhoneNumber = model.PhoneNumber;

                await _userHelper.UpdateUserAsync(parishioner.User);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
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
                .Include(p => p.Christenings)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (parishioner == null)
            {
                return NotFound();
            }

            //if (parishioner.SacramentTypes.Count > 0)
            //{
            //    ModelState.AddModelError(string.Empty, "El Feligrés no puede ser borrado porque tiene records relacionados.");
            //    return RedirectToAction(nameof(Index));
            //}

            await _userHelper.DeleteUserAsync(parishioner.User.Email);
            _context.Parishioners.Remove(parishioner);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Index)}");
        }

        private bool ParishionerExists(int id)
        {
            return _context.Parishioners.Any(e => e.Id == id);
        }

        [HttpGet]
        [RestoreModelStateFromTempData]
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

            var feligres = await _context.Parishioners
                .Include(p => p.Christenings)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (feligres.Christenings.Count > 0)
            {
                ModelState.AddModelError("", "Solo puede agregar un bautizo por Feligrés");
                //return RedirectToAction("Details", new { Id });
            }

            var model = new ChristeningViewModel
            {
                CreatedAt = DateTime.Today,
                ParishionerId = parishioner.Id,
                SacramentTypes = _combosHelper.GetChristening()
            };

            return View(model);
        }

        [HttpPost]
        [SetTempDataModelState]
        public async Task<IActionResult> AddChristening(ChristeningViewModel model)
        {
            if (model.Id > 0)
            {
                ModelState.AddModelError("", "Solo puede agregar un bautizo por Feligrés");
                return RedirectToAction("Details");
            }

            if (ModelState.IsValid)
            {
                var christening = await _converterHelper.ToChristeningAsync(model, true);
                _context.Christenings.Add(christening);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.ParishionerId}");               
            }

            model.SacramentTypes = _combosHelper.GetChristening();
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

            model.SacramentTypes = _combosHelper.GetChristening();
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

        public async Task<IActionResult> DeleteChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id.Value);
            if (christening == null)
            {
                return NotFound();
            }

            _context.Christenings.Remove(christening);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        [RestoreModelStateFromTempData]
        public async Task<IActionResult> AddFirstCommunion(int? id)
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

            var feligres = await _context.Parishioners
                .Include(p => p.FirstCommunions)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (feligres.FirstCommunions.Count > 0)
            {
                ModelState.AddModelError("", "Solo puede haber una Primera Comunión por Feligrés");
            }

            var model = new FirstCommunionViewModel
            {
                CreatedAt = DateTime.Today,
                ParishionerId = parishioner.Id,
                SacramentTypes = _combosHelper.GetFirstCommunion()
            };

            return View(model);
        }

        [HttpPost]
        [SetTempDataModelState]
        public async Task<IActionResult> AddFirstCommunion(FirstCommunionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var firstCommunion = await _converterHelper.ToFirstCommunionAsync(model, true);
                _context.FirstCommunions.Add(firstCommunion);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.ParishionerId}");
            }

            model.SacramentTypes = _combosHelper.GetFirstCommunion();
            return View(model);
        }

        public async Task<IActionResult> EditFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(f => f.Parishioner)
                .Include(f => f.SacramentType)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (firstCommunion == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToFirstCommunionViewModel(firstCommunion));
        }

        [HttpPost]
        public async Task<IActionResult> EditFirstCommunion(FirstCommunionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var firstCommunion = await _converterHelper.ToFirstCommunionAsync(model, false);
                _context.FirstCommunions.Update(firstCommunion);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.SacramentTypes = _combosHelper.GetFirstCommunion();
            return View(model);
        }


        public async Task<IActionResult> DetailsFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(f => f.Parishioner)
                .ThenInclude(p => p.User)
                .Include(f => f.Parishioner)
                .ThenInclude(p => p.Histories)
                .ThenInclude(p => p.RequestType)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (firstCommunion == null)
            {
                return NotFound();
            }

            return View(firstCommunion);

        }

        public async Task<IActionResult> DeleteFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(f => f.Parishioner)
                .FirstOrDefaultAsync(f => f.Id == id.Value);

            if (firstCommunion == null)
            {
                return NotFound();
            }

            _context.FirstCommunions.Remove(firstCommunion);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{firstCommunion.Parishioner.Id}");
        }

        public async Task<IActionResult> AddConfirmation(int? id)
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

            var model = new ConfirmationViewModel
            {
                ConfirmationDate = DateTime.Today,
                ParishionerId = parishioner.Id,
                SacramentTypes = _combosHelper.GetConfirmation()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfirmation(ConfirmationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var confirmation = await _converterHelper.ToConfirmationAsync(model, true);
                _context.Confirmations.Add(confirmation);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.SacramentTypes = _combosHelper.GetConfirmation();
            return View(model);
        }

        public async Task<IActionResult> EditConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(c => c.Parishioner)
                .Include(c => c.SacramentType)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (confirmation == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToConfirmationViewModel(confirmation));
        }

        [HttpPost]
        public async Task<IActionResult> EditConfirmation(ConfirmationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var confirmation = await _converterHelper.ToConfirmationAsync(model, false);
                _context.Confirmations.Update(confirmation);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ParishionerId}");
            }

            model.SacramentTypes = _combosHelper.GetConfirmation();
            return View(model);
        }

        public async Task<IActionResult> DetailsConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(c => c.Parishioner)
                .ThenInclude(c => c.User)
                .Include(c => c.Parishioner)
                .ThenInclude(c => c.Histories)
                .ThenInclude(c => c.RequestType)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (confirmation == null)
            {
                return NotFound();
            }

            return View(confirmation);
        }

        public async Task<IActionResult> DeleteConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id.Value);

            if (confirmation == null)
            {
                return NotFound();
            }

            _context.Confirmations.Remove(confirmation);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{confirmation.Parishioner.Id}");
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


    }
}
