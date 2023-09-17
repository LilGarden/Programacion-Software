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
    public class SellProductsController : Controller
    {
        private readonly BellapiewebContext _context;

        public SellProductsController(BellapiewebContext context)
        {
            _context = context;
        }

        // GET: SellProducts
        public async Task<IActionResult> Index()
        {
              return _context.SellProduct != null ? 
                          View(await _context.SellProduct.ToListAsync()) :
                          Problem("Entity set 'BellapiewebContext.SellProduct'  is null.");
        }

        // GET: SellProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellProduct == null)
            {
                return NotFound();
            }

            var sellProduct = await _context.SellProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellProduct == null)
            {
                return NotFound();
            }

            return View(sellProduct);
        }

        // GET: SellProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Qty,Price")] SellProduct sellProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellProduct);
        }

        // GET: SellProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellProduct == null)
            {
                return NotFound();
            }

            var sellProduct = await _context.SellProduct.FindAsync(id);
            if (sellProduct == null)
            {
                return NotFound();
            }
            return View(sellProduct);
        }

        // POST: SellProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Qty,Price")] SellProduct sellProduct)
        {
            if (id != sellProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellProductExists(sellProduct.Id))
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
            return View(sellProduct);
        }

        // GET: SellProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellProduct == null)
            {
                return NotFound();
            }

            var sellProduct = await _context.SellProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellProduct == null)
            {
                return NotFound();
            }

            return View(sellProduct);
        }

        // POST: SellProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellProduct == null)
            {
                return Problem("Entity set 'BellapiewebContext.SellProduct'  is null.");
            }
            var sellProduct = await _context.SellProduct.FindAsync(id);
            if (sellProduct != null)
            {
                _context.SellProduct.Remove(sellProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellProductExists(int id)
        {
          return (_context.SellProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
