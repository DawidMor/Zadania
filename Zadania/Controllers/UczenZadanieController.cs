using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadania.Data;
using Zadania.Models;

namespace Zadania.Controllers
{

    public class UczenZadanieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UczenZadanieController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: UczenZadanie
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                }
            }

            var applicationDbContext = _context.UczenZadanie.Include(u => u.Uczen).Include(u => u.Zadanie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UczenZadanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UczenZadanie == null)
            {
                return NotFound();
            }

            var uczenZadanie = await _context.UczenZadanie
                .Include(u => u.Uczen)
                .Include(u => u.Zadanie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uczenZadanie == null)
            {
                return NotFound();
            }

            return View(uczenZadanie);
        }

        // GET: UczenZadanie/Create
        public IActionResult Create()
        {
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId");
            ViewData["ZadanieId"] = new SelectList(_context.Zadanie, "ZadanieId", "ZadanieId");
            return View();
        }

        // POST: UczenZadanie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UczenId,ZadanieId,Tytul,Tresc")] UczenZadanie uczenZadanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uczenZadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", uczenZadanie.UczenId);
            ViewData["ZadanieId"] = new SelectList(_context.Zadanie, "ZadanieId", "ZadanieId", uczenZadanie.ZadanieId);
            return View(uczenZadanie);
        }

        // GET: UczenZadanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UczenZadanie == null)
            {
                return NotFound();
            }

            var uczenZadanie = await _context.UczenZadanie.FindAsync(id);
            if (uczenZadanie == null)
            {
                return NotFound();
            }
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", uczenZadanie.UczenId);
            ViewData["ZadanieId"] = new SelectList(_context.Zadanie, "ZadanieId", "ZadanieId", uczenZadanie.ZadanieId);
            return View(uczenZadanie);
        }

        // POST: UczenZadanie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UczenId,ZadanieId,Tytul,Tresc")] UczenZadanie uczenZadanie)
        {
            if (id != uczenZadanie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uczenZadanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UczenZadanieExists(uczenZadanie.Id))
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
            ViewData["UczenId"] = new SelectList(_context.Uczen, "UczenId", "UczenId", uczenZadanie.UczenId);
            ViewData["ZadanieId"] = new SelectList(_context.Zadanie, "ZadanieId", "ZadanieId", uczenZadanie.ZadanieId);
            return View(uczenZadanie);
        }

        // GET: UczenZadanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UczenZadanie == null)
            {
                return NotFound();
            }

            var uczenZadanie = await _context.UczenZadanie
                .Include(u => u.Uczen)
                .Include(u => u.Zadanie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uczenZadanie == null)
            {
                return NotFound();
            }

            return View(uczenZadanie);
        }

        // POST: UczenZadanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UczenZadanie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UczenZadanie'  is null.");
            }
            var uczenZadanie = await _context.UczenZadanie.FindAsync(id);
            if (uczenZadanie != null)
            {
                _context.UczenZadanie.Remove(uczenZadanie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UczenZadanieExists(int id)
        {
          return (_context.UczenZadanie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
