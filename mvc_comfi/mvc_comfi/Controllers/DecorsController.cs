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
    public class DecorsController : Controller
    {
        private readonly comfifurnituresContext _context;

        public DecorsController(comfifurnituresContext context)
        {
            _context = context;
        }

        // GET: Decors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Decors.ToListAsync());
        }
        public IActionResult GetAllProducts()
        {
            var Decors = from product in _context.Decors
                             select new
                             {
                                 prodid = product.Prodid,
                                 prodimg = product.Prodimg,
                                 prodquantity = product.Prodquantity,
                                 prodprice = product.Prodprice
                             };
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return Json(Decors.ToList());
        }
        // GET: Decors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {   
                return NotFound();
            }

            var decor = await _context.Decors
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (decor == null)
            {
                return NotFound();
            }

            return View(decor);
        }

        // GET: Decors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Decor decor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(decor);
        }

        // GET: Decors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decor = await _context.Decors.FindAsync(id);
            if (decor == null)
            {
                return NotFound();
            }
            return View(decor);
        }

        // POST: Decors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Decor decor)
        {
            if (id != decor.Prodid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecorExists(decor.Prodid))
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
            return View(decor);
        }

        // GET: Decors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decor = await _context.Decors
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (decor == null)
            {
                return NotFound();
            }

            return View(decor);
        }

        // POST: Decors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var decor = await _context.Decors.FindAsync(id);
            _context.Decors.Remove(decor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecorExists(int id)
        {
            return _context.Decors.Any(e => e.Prodid == id);
        }
    }
}
