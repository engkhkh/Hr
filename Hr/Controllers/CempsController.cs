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
    public class CempsController : Controller
    {
        private readonly hrContext _context;

        public CempsController(hrContext context)
        {
            _context = context;
        }

        // GET: Cemps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cemps.ToListAsync());
        }

        // GET: Cemps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == id);
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        // GET: Cemps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cemps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cemp);
        }

        // GET: Cemps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            if (cemp == null)
            {
                return NotFound();
            }
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.Cempid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cemp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CempExists(cemp.Cempid))
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
            return View(cemp);
        }

        // GET: Cemps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == id);
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        // POST: Cemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cemp = await _context.Cemps.FindAsync(id);
            _context.Cemps.Remove(cemp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CempExists(string id)
        {
            return _context.Cemps.Any(e => e.Cempid == id);
        }
    }
}
