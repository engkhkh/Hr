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
    public class ACourcesEstimates1Controller : Controller
    {
        private readonly hrContext _context;

        public ACourcesEstimates1Controller(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesEstimates1
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesEstimates.ToListAsync());
        }

        // GET: ACourcesEstimates1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesEstimate = await _context.ACourcesEstimates
                .FirstOrDefaultAsync(m => m.CourcesIdEstimate == id);
            if (aCourcesEstimate == null)
            {
                return NotFound();
            }

            return View(aCourcesEstimate);
        }

        // GET: ACourcesEstimates1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesEstimates1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdEstimate,CourcesNameEstimate")] ACourcesEstimate aCourcesEstimate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesEstimate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesEstimate);
        }

        // GET: ACourcesEstimates1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesEstimate = await _context.ACourcesEstimates.FindAsync(id);
            if (aCourcesEstimate == null)
            {
                return NotFound();
            }
            return View(aCourcesEstimate);
        }

        // POST: ACourcesEstimates1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdEstimate,CourcesNameEstimate")] ACourcesEstimate aCourcesEstimate)
        {
            if (id != aCourcesEstimate.CourcesIdEstimate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesEstimate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesEstimateExists(aCourcesEstimate.CourcesIdEstimate))
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
            return View(aCourcesEstimate);
        }

        // GET: ACourcesEstimates1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesEstimate = await _context.ACourcesEstimates
                .FirstOrDefaultAsync(m => m.CourcesIdEstimate == id);
            if (aCourcesEstimate == null)
            {
                return NotFound();
            }

            return View(aCourcesEstimate);
        }

        // POST: ACourcesEstimates1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesEstimate = await _context.ACourcesEstimates.FindAsync(id);
            _context.ACourcesEstimates.Remove(aCourcesEstimate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesEstimateExists(int id)
        {
            return _context.ACourcesEstimates.Any(e => e.CourcesIdEstimate == id);
        }
    }
}
