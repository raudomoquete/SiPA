using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrator")]
    public class RequestsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combos;
        private readonly IConverterHelper _converter;
        private readonly IUserHelper _userHelper;

        public RequestsController(
            DataContext context,
            ICombosHelper combos,
            IConverterHelper converter,
            IUserHelper userHelper)
        {
            _context = context;
            _combos = combos;
            _converter = converter;
            _userHelper = userHelper;
        }

        // GET: Requests
        public IActionResult Index()
        {
            return View(_context.Requests
                .Include(r => r.Parishioner)
                .ThenInclude(p => p.User)
                .Include(r => r.RequestType));
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            var model = new RequestVM
            {
                RequestTypes = _combos.GetComboRequestTypes(),
                Parishioners = _combos.GetComboParishioners()
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequest(RequestVM model)
        {
            if (ModelState.IsValid)          {

                var request = await _converter.ToRequestAsync(model, true);
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

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Parishioner)
                .ThenInclude(p => p.User)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(r => r.Id == id.Value);

            if (request == null)
            {
                return NotFound();
            }

            return View(_converter.ToRequestVM(request));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RequestVM model)
        {
            if (ModelState.IsValid)
            {
                var request = await _converter.ToRequestAsync(model, false);
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Parishioner)
                .ThenInclude(p => p.User)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(r => r.Id == id.Value);

            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
   