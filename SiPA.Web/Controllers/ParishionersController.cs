using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiPA.Web.Data;
using SiPA.Web.Data.Entities;

namespace SiPA.Web.Controllers
{
    public class ParishionersController : Controller
    {
        private readonly DataContext _context;

        public ParishionersController(DataContext context)
        {
            _context = context;
        }

        // GET: Parishioners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parishioners.ToListAsync());
        }

        // GET: Parishioners/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,CreatedAt,UpdatedAt")] Parishioner parishioner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parishioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parishioner);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedAt,UpdatedAt")] Parishioner parishioner)
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
