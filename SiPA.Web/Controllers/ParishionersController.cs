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

        public ParishionersController(DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
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

            var parishioner = await _context.Parishioners.FindAsync(id);
            if (parishioner == null)
            {
                return NotFound();
            }
            return View(parishioner);
        }

        // POST: Parishioners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Parishioner parishioner)
        {
            if (id != parishioner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parishioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParishionerExists(parishioner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parishioner);
        }

        // GET: Parishioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parishioner = await _context.Parishioners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parishioner == null)
            {
                return NotFound();
            }

            return View(parishioner);
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
    }
}
