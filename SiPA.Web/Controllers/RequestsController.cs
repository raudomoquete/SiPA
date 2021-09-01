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

        public RequestsController(
            DataContext context,
            ICombosHelper combos,
            IConverterHelper request
            )
        {
            _context = context;
            _combos = combos;
            _converter = request;
        }
        public IActionResult Index(string id)
        {
            var request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy == null);
            switch (id)
            {
                case "Pendientes":
                    request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy == null && !x.Finished);
                    break;
                case "Impresas":
                    request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy != null && x.SentBy == null);
                    break;
                case "Enviadas":
                    request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.SentBy != null);
                    break;
                case "Finalizadas":
                    request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.Finished);
                    break;
                default:
                    request = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy == null);
                    break;
            }

            ViewBag.Pendientes = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy == null && !x.Finished).Count();
            ViewBag.Impresas = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.PrintedBy != null && x.SentBy == null).Count();
            ViewBag.Enviadas = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.SentBy != null).Count();
            ViewBag.Finalizadas = _context.Requests.Include(r => r.CertificatesTypes).Where(x => x.Finished).Count();

            ViewBag.title = id;
            return View(request.ToList());               
        }

        //public IActionResult Print(int id)
        //{
        //    Request request = _context.Requests.Find(id);

        //    if (request != null)
        //    {
        //        request.PrintingDate = DateTime.Now;
        //        request.PrintedBy = User.Identity.Name;
        //        _context.Entry(request).State = EntityState.Modified;
        //        _context.SaveChanges();
        //    }
        //    switch (request.CertificateId)
        //    {
        //        case 1:
        //            return RedirectToAction("History", "Parishioners", new { id = request.Identification, type = request.CertificateId });
        //        case 2:
        //            return RedirectToAction("Certificate", "Parishioners", new { id = request.Identification, type = request.CertificateId });
        //        default:
        //            return RedirectToAction("Certificate", "Parishioners", new { id = request.Identification, type = request.CertificateId });
        //    }
        //}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Parishioner)
                .Include(r => r.Histories)
                .Include(r => r.RequestType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        //[HttpGet]
        //public IActionResult AddRequest()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddRequest([Bind("Id,Identification,Email,RequestDate," +
        //    "PrintingDate,PrintedBy,ShippingDate,SentBy,Finished,FinishedBy")]Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Requests.Add(request);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(request);
        //    //if (ModelState.IsValid)
        //    //{
        //    //    var request = await _converter.ToRequestAsync(model, true);
        //    //    _context.Requests.Add(request);

        //    //    try
        //    //    {
        //    //        await _context.SaveChangesAsync();
        //    //        return RedirectToAction($"{nameof(Index)}");
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        ModelState.AddModelError(string.Empty, ex.ToString());
        //    //        return View(model);
        //    //    }
        //    //}

        //    //model.Parishioners = _combos.GetComboParishioners();
        //    //model.RequestTypes = _combos.GetComboRequestTypes();
        //    //return View(model);
        //}

        public ActionResult Finish(int id)
        {
            Request request = _context.Requests.Find(id);

            if (request != null)
            {
                request.Finished = true;
                request.FinishedBy = User.Identity.Name;
                _context.Entry(request).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
