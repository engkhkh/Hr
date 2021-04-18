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
    public class ACourcesDeptoutsController : Controller
    {
        private readonly hrContext _context;

        public ACourcesDeptoutsController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesDeptouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesDeptouts.ToListAsync());
        }

        // GET: ACourcesDeptouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptout = await _context.ACourcesDeptouts
                .FirstOrDefaultAsync(m => m.CourcesIdDeptout == id);
            if (aCourcesDeptout == null)
            {
                return NotFound();
            }

            return View(aCourcesDeptout);
        }

        // GET: ACourcesDeptouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesDeptouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdDeptout,CourcesNameDeptout")] ACourcesDeptout aCourcesDeptout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesDeptout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesDeptout);
        }

        // GET: ACourcesDeptouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptout = await _context.ACourcesDeptouts.FindAsync(id);
            if (aCourcesDeptout == null)
            {
                return NotFound();
            }
            return View(aCourcesDeptout);
        }

        // POST: ACourcesDeptouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdDeptout,CourcesNameDeptout")] ACourcesDeptout aCourcesDeptout)
        {
            if (id != aCourcesDeptout.CourcesIdDeptout)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesDeptout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesDeptoutExists(aCourcesDeptout.CourcesIdDeptout))
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
            return View(aCourcesDeptout);
        }

        // GET: ACourcesDeptouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptout = await _context.ACourcesDeptouts
                .FirstOrDefaultAsync(m => m.CourcesIdDeptout == id);
            if (aCourcesDeptout == null)
            {
                return NotFound();
            }

            return View(aCourcesDeptout);
        }

        // POST: ACourcesDeptouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesDeptout = await _context.ACourcesDeptouts.FindAsync(id);
            _context.ACourcesDeptouts.Remove(aCourcesDeptout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesDeptoutExists(int id)
        {
            return _context.ACourcesDeptouts.Any(e => e.CourcesIdDeptout == id);
        }
    }
}
