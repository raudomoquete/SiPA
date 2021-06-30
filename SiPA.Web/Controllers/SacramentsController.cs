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
                .FirstOrDefaultAsync(s => s.SacramentId == id);
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

        //GET: Christening/Edit
        public async Task<IActionResult> EditChristening(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var christening = await _context.Christenings
                .Include(s => s.Sacrament)
                .FirstOrDefaultAsync(s => s.SacramentId == id.Value);
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

        public async Task<IActionResult> Edit(EditChristeningViewModel model)
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
                .FirstOrDefaultAsync(c => c.SacramentId == id);

            _context.Christenings.Remove(christening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}