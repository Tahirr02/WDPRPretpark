using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WdprPretparkDenhaag.Areas.Identity.Data;
using WdprPretparkDenhaag.Models;

namespace WdprPretparkDenhaag.Controllers
{
    public class BezoekerController : Controller
    {
        private readonly WdprPretparkDenhaagIdentityDbContext _context;

        public BezoekerController(WdprPretparkDenhaagIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Bezoeker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bezoekers.ToListAsync());
        }

        // GET: Bezoeker/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezoeker = await _context.Bezoekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bezoeker == null)
            {
                return NotFound();
            }

            return View(bezoeker);
        }

        // GET: Bezoeker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bezoeker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Voornaam,Achternaam,Id,Email")] Bezoeker bezoeker)
        {
            if (ModelState.IsValid)
            {
                bezoeker.Id = Guid.NewGuid();
                _context.Add(bezoeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bezoeker);
        }

        // GET: Bezoeker/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezoeker = await _context.Bezoekers.FindAsync(id);
            if (bezoeker == null)
            {
                return NotFound();
            }
            return View(bezoeker);
        }

        // POST: Bezoeker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Voornaam,Achternaam,Id,Email")] Bezoeker bezoeker)
        {
            if (id != bezoeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bezoeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BezoekerExists(bezoeker.Id))
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
            return View(bezoeker);
        }

        // GET: Bezoeker/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bezoeker = await _context.Bezoekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bezoeker == null)
            {
                return NotFound();
            }

            return View(bezoeker);
        }

        // POST: Bezoeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bezoeker = await _context.Bezoekers.FindAsync(id);
            _context.Bezoekers.Remove(bezoeker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BezoekerExists(Guid id)
        {
            return _context.Bezoekers.Any(e => e.Id == id);
        }
    }
}
