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
    public class NauczycielController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NauczycielController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nauczyciel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nauczyciel.Include(n => n.NauczycielUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nauczyciel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nauczyciel == null)
            {
                return NotFound();
            }

            var nauczyciel = await _context.Nauczyciel
                .Include(n => n.NauczycielUser)
                .FirstOrDefaultAsync(m => m.NauczycielId == id);
            if (nauczyciel == null)
            {
                return NotFound();
            }

            return View(nauczyciel);
        }

        // GET: Nauczyciel/Create
        public IActionResult Create()
        {
            ViewData["NauczycielUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Nauczyciel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NauczycielId,Imie,Nazwisko,NauczycielUserId")] Nauczyciel nauczyciel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nauczyciel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NauczycielUserId"] = new SelectList(_context.Users, "Id", "Id", nauczyciel.NauczycielUserId);
            return View(nauczyciel);
        }

        // GET: Nauczyciel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nauczyciel == null)
            {
                return NotFound();
            }

            var nauczyciel = await _context.Nauczyciel.FindAsync(id);
            if (nauczyciel == null)
            {
                return NotFound();
            }
            ViewData["NauczycielUserId"] = new SelectList(_context.Users, "Id", "Id", nauczyciel.NauczycielUserId);
            return View(nauczyciel);
        }

        // POST: Nauczyciel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NauczycielId,Imie,Nazwisko,NauczycielUserId")] Nauczyciel nauczyciel)
        {
            if (id != nauczyciel.NauczycielId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nauczyciel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NauczycielExists(nauczyciel.NauczycielId))
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
            ViewData["NauczycielUserId"] = new SelectList(_context.Users, "Id", "Id", nauczyciel.NauczycielUserId);
            return View(nauczyciel);
        }

        // GET: Nauczyciel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nauczyciel == null)
            {
                return NotFound();
            }

            var nauczyciel = await _context.Nauczyciel
                .Include(n => n.NauczycielUser)
                .FirstOrDefaultAsync(m => m.NauczycielId == id);
            if (nauczyciel == null)
            {
                return NotFound();
            }

            return View(nauczyciel);
        }

        // POST: Nauczyciel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nauczyciel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nauczyciel'  is null.");
            }
            var nauczyciel = await _context.Nauczyciel.FindAsync(id);
            if (nauczyciel != null)
            {
                _context.Nauczyciel.Remove(nauczyciel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NauczycielExists(int id)
        {
          return (_context.Nauczyciel?.Any(e => e.NauczycielId == id)).GetValueOrDefault();
        }
    }
}
