using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BellaPieWeb.Models;

namespace BellaPieWeb.Controllers
{
    public class TrendsController : Controller
    {
        private readonly BellapiewebContext _context;

        public TrendsController(BellapiewebContext context)
        {
            _context = context;
        }

        // GET: Trends
        public async Task<IActionResult> Index()
        {
              return _context.Trend != null ? 
                          View(await _context.Trend.ToListAsync()) :
                          Problem("Entity set 'BellapiewebContext.Trend'  is null.");
        }

        // GET: Trends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trend == null)
            {
                return NotFound();
            }

            var trend = await _context.Trend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trend == null)
            {
                return NotFound();
            }

            return View(trend);
        }

        // GET: Trends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Title,Trends")] Trend trend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trend);
        }

        // GET: Trends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trend == null)
            {
                return NotFound();
            }

            var trend = await _context.Trend.FindAsync(id);
            if (trend == null)
            {
                return NotFound();
            }
            return View(trend);
        }

        // POST: Trends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Title,Trends")] Trend trend)
        {
            if (id != trend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrendExists(trend.Id))
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
            return View(trend);
        }

        // GET: Trends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trend == null)
            {
                return NotFound();
            }

            var trend = await _context.Trend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trend == null)
            {
                return NotFound();
            }

            return View(trend);
        }

        // POST: Trends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trend == null)
            {
                return Problem("Entity set 'BellapiewebContext.Trend'  is null.");
            }
            var trend = await _context.Trend.FindAsync(id);
            if (trend != null)
            {
                _context.Trend.Remove(trend);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrendExists(int id)
        {
          return (_context.Trend?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
