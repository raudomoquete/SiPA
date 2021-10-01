using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiPA.Web.Data;
using SiPA.Web.Helpers;
using SiPA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ParishionersRequestController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;


        public ParishionersRequestController(
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddRequest(int? id)
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

            var model = new RequestVM
            {
                RequestDate = DateTime.Today,
                ParishionerId = parishioner.Id,
                RequestTypes = _combosHelper.GetComboRequestTypes()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequest(RequestVM model)
        {
            if (ModelState.IsValid)
            {
                var request = await _converterHelper.ToRequestAsync(model, true);
                _context.Requests.Add(request);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }

            model.Parishioners = _combosHelper.GetComboParishioners();
            model.RequestTypes = _combosHelper.GetComboRequestTypes();
            return View(model);
        }
    }
}
