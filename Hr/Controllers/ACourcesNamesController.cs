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
    public class ACourcesNamesController : Controller
    {
        private readonly hrContext _context;

        public ACourcesNamesController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesNames
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            return View(await _context.ACourcesNames.ToListAsync());
        }

        // GET: ACourcesNames/Details/5
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

            var aCourcesName = await _context.ACourcesNames
                .FirstOrDefaultAsync(m => m.CourcesId == id);
            if (aCourcesName == null)
            {
                return NotFound();
            }

            return View(aCourcesName);
        }

        // GET: ACourcesNames/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            return View();
        }

        // POST: ACourcesNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesId,CourcesName")] ACourcesName aCourcesName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesName);
        }

        // GET: ACourcesNames/Edit/5
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

            var aCourcesName = await _context.ACourcesNames.FindAsync(id);
            if (aCourcesName == null)
            {
                return NotFound();
            }
            return View(aCourcesName);
        }

        // POST: ACourcesNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesId,CourcesName")] ACourcesName aCourcesName)
        {
            if (id != aCourcesName.CourcesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesNameExists(aCourcesName.CourcesId))
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
            return View(aCourcesName);
        }

        // GET: ACourcesNames/Delete/5
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

            var aCourcesName = await _context.ACourcesNames
                .FirstOrDefaultAsync(m => m.CourcesId == id);
            if (aCourcesName == null)
            {
                return NotFound();
            }

            return View(aCourcesName);
        }

        // POST: ACourcesNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesName = await _context.ACourcesNames.FindAsync(id);
            _context.ACourcesNames.Remove(aCourcesName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesNameExists(int id)
        {
            return _context.ACourcesNames.Any(e => e.CourcesId == id);
        }
    }
}
