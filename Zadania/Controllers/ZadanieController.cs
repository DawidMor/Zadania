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
    public class ZadanieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZadanieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zadanie
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zadanie.Include(z => z.Klasa).Include(z => z.Nauczyciel).Include(z => z.Uczen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zadanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zadanie == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .Include(z => z.Klasa)
                .Include(z => z.Nauczyciel)
                .Include(z => z.Uczen)
                .FirstOrDefaultAsync(m => m.ZadanieId == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            return View(zadanie);
        }

        // GET: Zadanie/Create
        public IActionResult Create()
        {
            ViewData["KlasaId"] = new SelectList(_context.Klasa, "KlasaId", "KlasaId");
            ViewData["NauczycielId"] = new SelectList(_context.Nauczyciel, "NauczycielId", "NauczycielId");
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId");
            return View();
        }

        // POST: Zadanie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZadanieId,Tytul,Opis,DataWaznosci,CzyWyslanePoTerminie,Punktacja,UczenId,KlasaId,NauczycielId")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlasaId"] = new SelectList(_context.Klasa, "KlasaId", "KlasaId", zadanie.KlasaId);
            ViewData["NauczycielId"] = new SelectList(_context.Nauczyciel, "NauczycielId", "NauczycielId", zadanie.NauczycielId);
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", zadanie.UczenId);
            return View(zadanie);
        }

        // GET: Zadanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zadanie == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie == null)
            {
                return NotFound();
            }
            ViewData["KlasaId"] = new SelectList(_context.Klasa, "KlasaId", "KlasaId", zadanie.KlasaId);
            ViewData["NauczycielId"] = new SelectList(_context.Nauczyciel, "NauczycielId", "NauczycielId", zadanie.NauczycielId);
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", zadanie.UczenId);
            return View(zadanie);
        }

        // POST: Zadanie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZadanieId,Tytul,Opis,DataWaznosci,CzyWyslanePoTerminie,Punktacja,UczenId,KlasaId,NauczycielId")] Zadanie zadanie)
        {
            if (id != zadanie.ZadanieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zadanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZadanieExists(zadanie.ZadanieId))
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
            ViewData["KlasaId"] = new SelectList(_context.Klasa, "KlasaId", "KlasaId", zadanie.KlasaId);
            ViewData["NauczycielId"] = new SelectList(_context.Nauczyciel, "NauczycielId", "NauczycielId", zadanie.NauczycielId);
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", zadanie.UczenId);
            return View(zadanie);
        }

        // GET: Zadanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zadanie == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .Include(z => z.Klasa)
                .Include(z => z.Nauczyciel)
                .Include(z => z.Uczen)
                .FirstOrDefaultAsync(m => m.ZadanieId == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            return View(zadanie);
        }

        // POST: Zadanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zadanie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Zadanie'  is null.");
            }
            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie != null)
            {
                _context.Zadanie.Remove(zadanie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZadanieExists(int id)
        {
          return (_context.Zadanie?.Any(e => e.ZadanieId == id)).GetValueOrDefault();
        }
    }
}
