using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_comfi.Models.comfi;

namespace mvc_comfi.Controllers
{
    public class FurnituresController : Controller
    {
        private readonly comfifurnituresContext _context;

        public FurnituresController(comfifurnituresContext context)
        {
            _context = context;
        }

        // GET: Furnitures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Furnitures.ToListAsync());
        }
        public IActionResult GetAllProducts()
        {
            var Furnitures = from product in _context.Furnitures
                             select new
                             {
                                 prodid = product.Prodid,
                                 prodimg = product.Prodimg,
                                 prodquantity = product.Prodquantity,
                                 prodprice = product.Prodprice
                             };
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return Json(Furnitures.ToList());
        }

        // GET: Furnitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furnitures
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }

        // GET: Furnitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Furnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(furniture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(furniture);
        }

        // GET: Furnitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Furniture furniture)
        {
            if (id != furniture.Prodid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furniture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurnitureExists(furniture.Prodid))
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
            return View(furniture);
        }

        // GET: Furnitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furnitures
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);
            _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurnitureExists(int id)
        {
            return _context.Furnitures.Any(e => e.Prodid == id);
        }
    }
}
