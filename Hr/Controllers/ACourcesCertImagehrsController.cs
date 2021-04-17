using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;

namespace Hr.Controllers
{
    public class ACourcesCertImagehrsController : Controller
    {
        private readonly hrContext _context;

        public ACourcesCertImagehrsController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesCertImagehrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesCertImagehrs.ToListAsync());
        }

        // GET: ACourcesCertImagehrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImagehr = await _context.ACourcesCertImagehrs
                .FirstOrDefaultAsync(m => m.CourcesIdImagehr == id);
            if (aCourcesCertImagehr == null)
            {
                return NotFound();
            }

            return View(aCourcesCertImagehr);
        }

        // GET: ACourcesCertImagehrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesCertImagehrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdImagehr,CourcesIdmaster,ImageName,ImagePath,ImageType,ImageCreatedDate,FileName1,Note")] ACourcesCertImagehr aCourcesCertImagehr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesCertImagehr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesCertImagehr);
        }

        // GET: ACourcesCertImagehrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImagehr = await _context.ACourcesCertImagehrs.FindAsync(id);
            if (aCourcesCertImagehr == null)
            {
                return NotFound();
            }
            return View(aCourcesCertImagehr);
        }

        // POST: ACourcesCertImagehrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdImagehr,CourcesIdmaster,ImageName,ImagePath,ImageType,ImageCreatedDate,FileName1,Note")] ACourcesCertImagehr aCourcesCertImagehr)
        {
            if (id != aCourcesCertImagehr.CourcesIdImagehr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesCertImagehr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesCertImagehrExists(aCourcesCertImagehr.CourcesIdImagehr))
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
            return View(aCourcesCertImagehr);
        }

        // GET: ACourcesCertImagehrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImagehr = await _context.ACourcesCertImagehrs
                .FirstOrDefaultAsync(m => m.CourcesIdImagehr == id);
            if (aCourcesCertImagehr == null)
            {
                return NotFound();
            }

            return View(aCourcesCertImagehr);
        }

        // POST: ACourcesCertImagehrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesCertImagehr = await _context.ACourcesCertImagehrs.FindAsync(id);
            _context.ACourcesCertImagehrs.Remove(aCourcesCertImagehr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesCertImagehrExists(int id)
        {
            return _context.ACourcesCertImagehrs.Any(e => e.CourcesIdImagehr == id);
        }
    }
}
