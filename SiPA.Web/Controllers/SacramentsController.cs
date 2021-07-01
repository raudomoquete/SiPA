using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;
using SiPA.Web.Helpers;
using SiPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers
{
    public class SacramentsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public SacramentsController(DataContext context,
            ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public IActionResult Index()
        {
            return View(_context.SacramentTypes
                .Include(st => st.Sacraments));
        }

        //GET: Christening/Details
        public async Task<IActionResult> ChristeningDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(c => c.Sacrament)
                .Include(c => c.Certificate)
                .ThenInclude(c => c.Sacrament)
                .ThenInclude(s => s.Parishioner)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (christening == null)
            {
                return NotFound();
            }

            return View(christening);
        }

        //GET: Christening/Create
        public IActionResult CreateChristening()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChristening(AddChristeningViewModel model)
        {
            if (ModelState.IsValid)
            {
                var christening = new Christening
                {
                    FirstName = model.FirstName,
                    ChristeningDate = DateTime.Today,
                    Certificate = model.Certificate,
                    PlaceofEvent = model.PlaceofEvent,
                    FatherName = model.FatherName,
                    FatherId = model.FatherId,
                    MotherName = model.MotherName,
                    MotherId = model.MotherId,
                    GodfatherName = model.GodfatherName,
                    GodfatherId = model.GodfatherId,
                    GodmotherName = model.GodmotherName,
                    GodmotherId = model.GodmotherId,
                    Comments = model.Comments,
                    CeremonialCelebrant = model.CeremonialCelebrant
                };

                _context.Christenings.Add(christening);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.ParishionerId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.SacramentTypes = _combosHelper.GetComboSacraments();
            return View(model);
        }

        //GET: Christenings/Edit
        public async Task<IActionResult> EditChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(s => s.Sacrament)
                .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (christening == null)
            {
                return NotFound();
            }

            var model = new EditChristeningViewModel
            {
                FirstName = christening.FirstName,
                ChristeningDate = DateTime.Today,
                Certificate = christening.Certificate,
                PlaceofEvent = christening.PlaceofEvent,
                FatherName = christening.FatherName,
                FatherId = christening.FatherId,
                MotherName = christening.MotherName,
                MotherId = christening.MotherId,
                GodfatherName = christening.GodfatherName,
                GodfatherId = christening.GodfatherId,
                GodmotherName = christening.GodmotherName,
                GodmotherId = christening.GodmotherId,
                Id = christening.SacramentId,
                Comments = christening.Comments,
                CeremonialCelebrant = christening.CeremonialCelebrant
            };

            return View(model);
        }

        //POST: Christenings/Edit
        [HttpPost]

        public async Task<IActionResult> EditChristening(EditChristeningViewModel model)
        {
            if (ModelState.IsValid)
            {
                var christening = await _context.Christenings
                    .Include(c => c.Sacrament)
                    .FirstOrDefaultAsync(c => c.SacramentId == model.Id);

                christening.FirstName = model.FirstName;
                christening.ChristeningDate = model.ChristeningDate;
                christening.Certificate = model.Certificate;
                christening.PlaceofEvent = model.PlaceofEvent;
                christening.FatherName = model.FatherName;
                christening.FatherId = model.FatherId;
                christening.MotherName = model.MotherName;
                christening.MotherId = model.MotherId;
                christening.GodfatherName = model.GodfatherName;
                christening.GodfatherId = model.GodfatherId;
                christening.GodmotherName = model.GodmotherName;
                christening.GodmotherId = model.GodmotherId;
                christening.Comments = model.Comments;
                christening.CeremonialCelebrant = model.CeremonialCelebrant;

                _context.Update(christening.Sacrament);
                return RedirectToAction(nameof(Index));
            }

            return View(model);    
        }

        // GET: Christening/Delete
        public async Task<IActionResult> DeleteChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.Christenings.Remove(christening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: FirstCommunion/Details
        public async Task<IActionResult> DetailsFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(c => c.Sacrament)
                .Include(c => c.Certificate)
                .ThenInclude(c => c.Sacrament)
                .ThenInclude(s => s.Parishioner)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (firstCommunion == null)
            {
                return NotFound();
            }

            return View(firstCommunion);
        }

        // GET: FirstCommunion/Create
        public IActionResult CreateFirstCommunion()
        {
            return View();
        }

        // POST: FirstCommunion/Create
        [HttpPost]
        public async Task<IActionResult> CreateFirstCommunion(AddFirstCommunionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var firstCommunion = new FirstCommunion
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Date = DateTime.Today,
                    Certificate = model.Certificate,
                    PlaceofEvent = model.PlaceofEvent,
                    FatherName = model.FatherName,
                    FatherId = model.FatherId,
                    MotherName = model.MotherName,
                    MotherId = model.MotherId,
                    Comments = model.Comments,
                    CeremonialCelebrant = model.CeremonialCelebrant
                };

                _context.FirstCommunions.Add(firstCommunion);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.ParishionerId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.SacramentTypes = _combosHelper.GetComboSacraments();
            return View(model);
        }

        // GET: FirstCommunion/Edit
        public async Task<IActionResult> EditFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(s => s.Sacrament)
                .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (firstCommunion == null)
            {
                return NotFound();
            }

            var model = new EditFirstCommunionViewModel
            {
                FirstName = firstCommunion.FirstName,
                Date = DateTime.Today,
                Certificate = firstCommunion.Certificate,
                PlaceofEvent = firstCommunion.PlaceofEvent,
                FatherName = firstCommunion.FatherName,
                FatherId = firstCommunion.FatherId,
                MotherName = firstCommunion.MotherName,
                MotherId = firstCommunion.MotherId,
                Id = firstCommunion.SacramentId,
                Comments = firstCommunion.Comments,
                CeremonialCelebrant = firstCommunion.CeremonialCelebrant
            };

            return View(model);
        }

        //POST: FirstCommunions/Edit
        [HttpPost]

        public async Task<IActionResult> EditFirstCommunion(EditFirstCommunionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var firstCommunion = await _context.FirstCommunions
                    .Include(c => c.Sacrament)
                    .FirstOrDefaultAsync(c => c.Id == model.Id);

                firstCommunion.FirstName = model.FirstName;
                firstCommunion.LastName = model.LastName;
                firstCommunion.Date = model.Date;
                firstCommunion.Certificate = model.Certificate;
                firstCommunion.PlaceofEvent = model.PlaceofEvent;
                firstCommunion.FatherName = model.FatherName;
                firstCommunion.FatherId = model.FatherId;
                firstCommunion.MotherName = model.MotherName;
                firstCommunion.MotherId = model.MotherId;
                firstCommunion.Comments = model.Comments;
                firstCommunion.CeremonialCelebrant = model.CeremonialCelebrant;

                _context.Update(firstCommunion.Sacrament);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: FirstCommunion/Delete
        public async Task<IActionResult> DeleteFirstCommunion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstCommunion = await _context.FirstCommunions
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.FirstCommunions.Remove(firstCommunion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Confirmation/Details
        public async Task<IActionResult> DetailsConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(c => c.Sacrament)
                .Include(c => c.Certificate)
                .ThenInclude(c => c.Sacrament)
                .ThenInclude(s => s.Parishioner)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (confirmation == null)
            {
                return NotFound();
            }

            return View(confirmation);
        }

        // GET: Comfirmation/Create
        public IActionResult CreateConfirmation()
        {
            return View();
        }

        // POST: Comfirmation/Create
        [HttpPost]
        public async Task<IActionResult> CreateConfirmation(AddConfirmationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var confirmation = new Confirmation
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Date = DateTime.Today,
                    Certificate = model.Certificate,
                    PlaceofEvent = model.PlaceofEvent,
                    FatherName = model.FatherName,
                    FatherId = model.FatherId,
                    MotherName = model.MotherName,
                    MotherId = model.MotherId,
                    GodfatherName = model.GodfatherName,
                    GodfatherId = model.GodfatherId,
                    GodmotherName = model.GodmotherName,
                    GodmotherId = model.GodmotherId,
                    Comments = model.Comments,
                    CeremonialCelebrant = model.CeremonialCelebrant
                };

                _context.Confirmations.Add(confirmation);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.ParishionerId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.SacramentTypes = _combosHelper.GetComboSacraments();
            return View(model);
        }

        //GET: Confirmations/Edit
        public async Task<IActionResult> EditConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(s => s.Sacrament)
                .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (confirmation == null)
            {
                return NotFound();
            }

            var model = new EditConfirmationViewModel
            {
                FirstName = confirmation.FirstName,
                LastName = confirmation.LastName,
                ConfirmationDate = DateTime.Today,
                Certificate = confirmation.Certificate,
                PlaceofEvent = confirmation.PlaceofEvent,
                FatherName = confirmation.FatherName,
                FatherId = confirmation.FatherId,
                MotherName = confirmation.MotherName,
                MotherId = confirmation.MotherId,
                GodfatherName = confirmation.GodfatherName,
                GodfatherId = confirmation.GodfatherId,
                GodmotherName = confirmation.GodmotherName,
                GodmotherId = confirmation.GodmotherId,
                Id = confirmation.SacramentId,
                Comments = confirmation.Comments,
                CeremonialCelebrant = confirmation.CeremonialCelebrant
            };

            return View(model);
        }

        //POST: Confirmations/Edit
        [HttpPost]

        public async Task<IActionResult> EditConfirmation(EditConfirmationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var confirmation = await _context.Confirmations
                    .Include(c => c.Sacrament)
                    .FirstOrDefaultAsync(c => c.Id == model.Id);

                confirmation.FirstName = model.FirstName;
                confirmation.ConfirmationDate = model.ConfirmationDate;
                confirmation.Certificate = model.Certificate;
                confirmation.PlaceofEvent = model.PlaceofEvent;
                confirmation.FatherName = model.FatherName;
                confirmation.FatherId = model.FatherId;
                confirmation.MotherName = model.MotherName;
                confirmation.MotherId = model.MotherId;
                confirmation.GodfatherName = model.GodfatherName;
                confirmation.GodfatherId = model.GodfatherId;
                confirmation.GodmotherName = model.GodmotherName;
                confirmation.GodmotherId = model.GodmotherId;
                confirmation.Comments = model.Comments;
                confirmation.CeremonialCelebrant = model.CeremonialCelebrant;

                _context.Update(confirmation.Sacrament);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Confirmation/Delete
        public async Task<IActionResult> DeleteConfirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmations
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.Confirmations.Remove(confirmation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Wedding/Details
        public async Task<IActionResult> DetailsWedding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedding = await _context.Weddings
                .Include(c => c.Sacrament)
                .Include(c => c.Certificate)
                .ThenInclude(c => c.Sacrament)
                .ThenInclude(s => s.Parishioner)
                .Include(w => w.WeddingGrooms)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (wedding == null)
            {
                return NotFound();
            }

            return View(wedding);
        }

        // GET: Weddings/Create
        public IActionResult CreateWedding()
        {
            return View();
        }

        // POST: Comfirmation/Create
        [HttpPost]
        public async Task<IActionResult> CreateWedding(AddWeddingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var wedding = new Wedding
                {
                    BrideFirstName = model.BrideFirstName,
                    BrideLastName = model.BrideLastName,
                    BrideId = model.BrideId,
                    BridegroomFirstName = model.BridegroomFirstName,
                    BridegroomLastName = model.BridegroomLastName,
                    BridegroomId = model.BridegroomId,
                    WeddingDate = DateTime.Today,
                    Certificate = model.Certificate,
                    PlaceofEvent = model.PlaceofEvent,
                    BrideFatherName = model.BrideFatherName,
                    BrideFatherId = model.BrideFatherId,
                    BrideMotherName = model.BrideMotherName,
                    BrideMotherId = model.BrideMotherId,
                    BridegroomFatherName = model.BridegroomFatherName,
                    BridegroomFatherId = model.BridegroomFatherId,
                    BridegroomMotherName = model.BridegroomMotherName,
                    BridegroomMotherId = model.BridegroomMotherId,
                    GodmotherName = model.GodmotherName,
                    GodmotherId = model.GodmotherId,
                    GodfatherName = model.GodfatherName,
                    GodfatherId = model.GodfatherId,
                    Comments = model.Comments,
                    CeremonialCelebrant = model.CeremonialCelebrant
                };

                _context.Weddings.Add(wedding);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"Details/{model.ParishionerId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.SacramentTypes = _combosHelper.GetComboSacraments();
            return View(model);
        }

        //GET: Weddings/Edit
        public async Task<IActionResult> EditWedding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedding = await _context.Weddings
                .Include(s => s.Sacrament)
                .FirstOrDefaultAsync(s => s.Id == id.Value);
            if (wedding == null)
            {
                return NotFound();
            }

            var model = new AddWeddingViewModel
            {
                BrideFirstName = wedding.BrideFirstName,
                BrideLastName = wedding.BrideLastName,
                BrideId = wedding.BrideId,
                BridegroomFirstName = wedding.BridegroomFirstName,
                BridegroomLastName = wedding.BridegroomLastName,
                BridegroomId = wedding.BridegroomId,
                WeddingDate = DateTime.Today,
                Certificate = wedding.Certificate,
                PlaceofEvent = wedding.PlaceofEvent,
                BrideFatherName = wedding.BrideFatherName,
                BrideFatherId = wedding.BrideFatherId,
                BrideMotherName = wedding.BrideMotherName,
                BrideMotherId = wedding.BrideMotherId,
                BridegroomFatherName = wedding.BridegroomFatherName,
                BridegroomFatherId = wedding.BridegroomFatherId,
                BridegroomMotherName = wedding.BridegroomMotherName,
                BridegroomMotherId = wedding.BridegroomMotherId,
                GodmotherName = wedding.GodmotherName,
                GodmotherId = wedding.GodmotherId,
                GodfatherName = wedding.GodfatherName,
                GodfatherId = wedding.GodfatherId,
                Id = wedding.SacramentId,
                Comments = wedding.Comments,
                CeremonialCelebrant = wedding.CeremonialCelebrant
            };

            return View(model);
        }

        //POST: Weddings/Edit
        [HttpPost]
        public async Task<IActionResult> EditWedding(EditWeddingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var wedding = await _context.Weddings
                    .Include(c => c.Sacrament)
                    .FirstOrDefaultAsync(c => c.Id == model.Id);

                wedding.BrideFirstName = model.BrideFirstName;
                wedding.BrideLastName = model.BrideLastName;
                wedding.BrideId = model.BrideId;
                wedding.BridegroomFirstName = model.BridegroomFirstName;
                wedding.BridegroomLastName = model.BridegroomLastName;
                wedding.BridegroomId = model.BridegroomId;
                wedding.WeddingDate = model.WeddingDate;
                wedding.BrideFatherName = model.BrideFatherName;
                wedding.BrideFatherId = model.BrideFatherId;
                wedding.BrideMotherName = model.BrideMotherName;
                wedding.BrideMotherId = model.BrideMotherId;
                wedding.BridegroomFatherName = model.BridegroomFatherName;
                wedding.BridegroomFatherId = model.BridegroomFatherId;
                wedding.BridegroomMotherName = model.BridegroomMotherName;
                wedding.BridegroomMotherId = model.BridegroomMotherId;
                wedding.Certificate = model.Certificate;
                wedding.Certificate = model.Certificate;
                wedding.PlaceofEvent = model.PlaceofEvent;
                wedding.GodmotherName = model.GodmotherName;
                wedding.GodmotherId = model.GodmotherId;
                wedding.BrideFatherName = model.GodfatherId;
                wedding.PlaceofEvent = model.PlaceofEvent;
                wedding.CeremonialCelebrant = model.CeremonialCelebrant;

                _context.Update(wedding.Sacrament);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Wedding/Delete
        public async Task<IActionResult> DeleteWedding(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedding = await _context.Weddings
                .Include(c => c.Parishioner)
                .FirstOrDefaultAsync(c => c.Id == id);

            _context.Weddings.Remove(wedding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}