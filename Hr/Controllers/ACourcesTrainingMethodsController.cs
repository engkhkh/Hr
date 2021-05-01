using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;
using Microsoft.AspNetCore.Http;

namespace Hr.Controllers
{
    public class ACourcesTrainingMethodsController : Controller
    {
        private readonly hrContext _context;

        public ACourcesTrainingMethodsController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesTrainingMethods
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            return View(await _context.ACourcesTrainingMethods.ToListAsync());
        }

        // GET: ACourcesTrainingMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesTrainingMethod = await _context.ACourcesTrainingMethods
                .FirstOrDefaultAsync(m => m.CourcesIdTraining == id);
            if (aCourcesTrainingMethod == null)
            {
                return NotFound();
            }

            return View(aCourcesTrainingMethod);
        }

        // GET: ACourcesTrainingMethods/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            return View();
        }

        // POST: ACourcesTrainingMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdTraining,CourcesNameTraining")] ACourcesTrainingMethod aCourcesTrainingMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesTrainingMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesTrainingMethod);
        }

        // GET: ACourcesTrainingMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesTrainingMethod = await _context.ACourcesTrainingMethods.FindAsync(id);
            if (aCourcesTrainingMethod == null)
            {
                return NotFound();
            }
            return View(aCourcesTrainingMethod);
        }

        // POST: ACourcesTrainingMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdTraining,CourcesNameTraining")] ACourcesTrainingMethod aCourcesTrainingMethod)
        {
            if (id != aCourcesTrainingMethod.CourcesIdTraining)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesTrainingMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesTrainingMethodExists(aCourcesTrainingMethod.CourcesIdTraining))
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
            return View(aCourcesTrainingMethod);
        }

        // GET: ACourcesTrainingMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesTrainingMethod = await _context.ACourcesTrainingMethods
                .FirstOrDefaultAsync(m => m.CourcesIdTraining == id);
            if (aCourcesTrainingMethod == null)
            {
                return NotFound();
            }

            return View(aCourcesTrainingMethod);
        }

        // POST: ACourcesTrainingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesTrainingMethod = await _context.ACourcesTrainingMethods.FindAsync(id);
            _context.ACourcesTrainingMethods.Remove(aCourcesTrainingMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesTrainingMethodExists(int id)
        {
            return _context.ACourcesTrainingMethods.Any(e => e.CourcesIdTraining == id);
        }
    }
}
