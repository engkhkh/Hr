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
    public class ACourcesTypesController : Controller
    {
        private readonly hrContext _context;

        public ACourcesTypesController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesTypes.ToListAsync());
        }

        // GET: ACourcesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesType = await _context.ACourcesTypes
                .FirstOrDefaultAsync(m => m.CourcesIdType == id);
            if (aCourcesType == null)
            {
                return NotFound();
            }

            return View(aCourcesType);
        }

        // GET: ACourcesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdType,CourcesTypeName")] ACourcesType aCourcesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesType);
        }

        // GET: ACourcesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesType = await _context.ACourcesTypes.FindAsync(id);
            if (aCourcesType == null)
            {
                return NotFound();
            }
            return View(aCourcesType);
        }

        // POST: ACourcesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdType,CourcesTypeName")] ACourcesType aCourcesType)
        {
            if (id != aCourcesType.CourcesIdType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesTypeExists(aCourcesType.CourcesIdType))
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
            return View(aCourcesType);
        }

        // GET: ACourcesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesType = await _context.ACourcesTypes
                .FirstOrDefaultAsync(m => m.CourcesIdType == id);
            if (aCourcesType == null)
            {
                return NotFound();
            }

            return View(aCourcesType);
        }

        // POST: ACourcesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesType = await _context.ACourcesTypes.FindAsync(id);
            _context.ACourcesTypes.Remove(aCourcesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesTypeExists(int id)
        {
            return _context.ACourcesTypes.Any(e => e.CourcesIdType == id);
        }
    }
}
