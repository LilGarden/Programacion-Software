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
    public class SupplierProductsController : Controller
    {
        private readonly BellapiewebContext _context;

        public SupplierProductsController(BellapiewebContext context)
        {
            _context = context;
        }

        // GET: SupplierProducts
        public async Task<IActionResult> Index()
        {
              return _context.SupplierProduct != null ? 
                          View(await _context.SupplierProduct.ToListAsync()) :
                          Problem("Entity set 'BellapiewebContext.SupplierProduct'  is null.");
        }

        // GET: SupplierProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SupplierProduct == null)
            {
                return NotFound();
            }

            var supplierProduct = await _context.SupplierProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplierProduct == null)
            {
                return NotFound();
            }

            return View(supplierProduct);
        }

        // GET: SupplierProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId,ProductId")] SupplierProduct supplierProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierProduct);
        }

        // GET: SupplierProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SupplierProduct == null)
            {
                return NotFound();
            }

            var supplierProduct = await _context.SupplierProduct.FindAsync(id);
            if (supplierProduct == null)
            {
                return NotFound();
            }
            return View(supplierProduct);
        }

        // POST: SupplierProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupplierId,ProductId")] SupplierProduct supplierProduct)
        {
            if (id != supplierProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierProductExists(supplierProduct.Id))
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
            return View(supplierProduct);
        }

        // GET: SupplierProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SupplierProduct == null)
            {
                return NotFound();
            }

            var supplierProduct = await _context.SupplierProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplierProduct == null)
            {
                return NotFound();
            }

            return View(supplierProduct);
        }

        // POST: SupplierProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SupplierProduct == null)
            {
                return Problem("Entity set 'BellapiewebContext.SupplierProduct'  is null.");
            }
            var supplierProduct = await _context.SupplierProduct.FindAsync(id);
            if (supplierProduct != null)
            {
                _context.SupplierProduct.Remove(supplierProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierProductExists(int id)
        {
          return (_context.SupplierProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
