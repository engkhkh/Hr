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
    public class ACourcesDeptinsController : Controller
    {
        private readonly hrContext _context;

        public ACourcesDeptinsController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesDeptins
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesDeptins.ToListAsync());
        }

        // GET: ACourcesDeptins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptin = await _context.ACourcesDeptins
                .FirstOrDefaultAsync(m => m.CourcesIdDeptin == id);
            if (aCourcesDeptin == null)
            {
                return NotFound();
            }

            return View(aCourcesDeptin);
        }

        // GET: ACourcesDeptins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesDeptins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdDeptin,CourcesNameDeptin")] ACourcesDeptin aCourcesDeptin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesDeptin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesDeptin);
        }

        // GET: ACourcesDeptins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptin = await _context.ACourcesDeptins.FindAsync(id);
            if (aCourcesDeptin == null)
            {
                return NotFound();
            }
            return View(aCourcesDeptin);
        }

        // POST: ACourcesDeptins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdDeptin,CourcesNameDeptin")] ACourcesDeptin aCourcesDeptin)
        {
            if (id != aCourcesDeptin.CourcesIdDeptin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesDeptin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesDeptinExists(aCourcesDeptin.CourcesIdDeptin))
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
            return View(aCourcesDeptin);
        }

        // GET: ACourcesDeptins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesDeptin = await _context.ACourcesDeptins
                .FirstOrDefaultAsync(m => m.CourcesIdDeptin == id);
            if (aCourcesDeptin == null)
            {
                return NotFound();
            }

            return View(aCourcesDeptin);
        }

        // POST: ACourcesDeptins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesDeptin = await _context.ACourcesDeptins.FindAsync(id);
            _context.ACourcesDeptins.Remove(aCourcesDeptin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesDeptinExists(int id)
        {
            return _context.ACourcesDeptins.Any(e => e.CourcesIdDeptin == id);
        }
    }
}
