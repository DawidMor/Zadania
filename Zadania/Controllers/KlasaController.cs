using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadania.Data;
using Zadania.Models;

namespace Zadania.Controllers
{
    public class KlasaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlasaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klasa
        public async Task<IActionResult> Index()
        {
              return _context.Klasa != null ? 
                          View(await _context.Klasa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Klasa'  is null.");
        }

        // GET: Klasa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klasa == null)
            {
                return NotFound();
            }

            var klasa = await _context.Klasa
                .FirstOrDefaultAsync(m => m.KlasaId == id);
            if (klasa == null)
            {
                return NotFound();
            }

            return View(klasa);
        }

        // GET: Klasa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlasaId,NazwaKlasy")] Klasa klasa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klasa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klasa);
        }

        // GET: Klasa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klasa == null)
            {
                return NotFound();
            }

            var klasa = await _context.Klasa.FindAsync(id);
            if (klasa == null)
            {
                return NotFound();
            }
            return View(klasa);
        }

        // POST: Klasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlasaId,NazwaKlasy")] Klasa klasa)
        {
            if (id != klasa.KlasaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klasa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlasaExists(klasa.KlasaId))
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
            return View(klasa);
        }

        // GET: Klasa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klasa == null)
            {
                return NotFound();
            }

            var klasa = await _context.Klasa
                .FirstOrDefaultAsync(m => m.KlasaId == id);
            if (klasa == null)
            {
                return NotFound();
            }

            return View(klasa);
        }

        // POST: Klasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klasa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klasa'  is null.");
            }
            var klasa = await _context.Klasa.FindAsync(id);
            if (klasa != null)
            {
                _context.Klasa.Remove(klasa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlasaExists(int id)
        {
          return (_context.Klasa?.Any(e => e.KlasaId == id)).GetValueOrDefault();
        }
    }
}
