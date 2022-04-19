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
    public class WfhsController : Controller
    {
        private readonly comfifurnituresContext _context;

        public WfhsController(comfifurnituresContext context)
        {
            _context = context;
        }

        // GET: Wfhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wfhs.ToListAsync());
        }

        public IActionResult GetAllProducts()
        {
            var Wfhs = from product in _context.Wfhs
                             select new
                             {
                                 prodid = product.Prodid,
                                 prodimg = product.Prodimg,
                                 prodquantity = product.Prodquantity,
                                 prodprice = product.Prodprice
                             };
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "*"));
            Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Headers", "Origin,X-Requested-With,Content-Type,Accept,Authorization"));
            return Json(Wfhs.ToList());
        }

        // GET: Wfhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wfh = await _context.Wfhs
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (wfh == null)
            {
                return NotFound();
            }

            return View(wfh);
        }

        // GET: Wfhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wfhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Wfh wfh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wfh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wfh);
        }

        // GET: Wfhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wfh = await _context.Wfhs.FindAsync(id);
            if (wfh == null)
            {
                return NotFound();
            }
            return View(wfh);
        }

        // POST: Wfhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prodid,Prodimg,Prodquantity,Prodprice")] Wfh wfh)
        {
            if (id != wfh.Prodid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wfh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WfhExists(wfh.Prodid))
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
            return View(wfh);
        }

        // GET: Wfhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wfh = await _context.Wfhs
                .FirstOrDefaultAsync(m => m.Prodid == id);
            if (wfh == null)
            {
                return NotFound();
            }

            return View(wfh);
        }

        // POST: Wfhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wfh = await _context.Wfhs.FindAsync(id);
            _context.Wfhs.Remove(wfh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WfhExists(int id)
        {
            return _context.Wfhs.Any(e => e.Prodid == id);
        }
    }
}
