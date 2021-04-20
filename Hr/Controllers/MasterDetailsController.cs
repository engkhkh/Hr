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
    public class MasterDetailsController : Controller
    {
        private readonly hrContext _context;

        public MasterDetailsController(hrContext context)
        {
            _context = context;
        }

        // GET: MasterDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.MasterDetailss.ToListAsync());
        }

        // GET: MasterDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterDetails = await _context.MasterDetailss
                .FirstOrDefaultAsync(m => m.MasterDetailsSerial == id);
            if (masterDetails == null)
            {
                return NotFound();
            }

            return View(masterDetails);
        }

        // GET: MasterDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasterDetailsSerial,COURCES_IDMASTER,MasterRequestFrom,MasterRequestTo,MasterRequestTypeSatus,MasterRequestNotes")] MasterDetails masterDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masterDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masterDetails);
        }

        // GET: MasterDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterDetails = await _context.MasterDetailss.FindAsync(id);
            if (masterDetails == null)
            {
                return NotFound();
            }
            return View(masterDetails);
        }

        // POST: MasterDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MasterDetailsSerial,COURCES_IDMASTER,MasterRequestFrom,MasterRequestTo,MasterRequestTypeSatus,MasterRequestNotes")] MasterDetails masterDetails)
        {
            if (id != masterDetails.MasterDetailsSerial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masterDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterDetailsExists(masterDetails.MasterDetailsSerial))
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
            return View(masterDetails);
        }

        // GET: MasterDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterDetails = await _context.MasterDetailss
                .FirstOrDefaultAsync(m => m.MasterDetailsSerial == id);
            if (masterDetails == null)
            {
                return NotFound();
            }

            return View(masterDetails);
        }

        // POST: MasterDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var masterDetails = await _context.MasterDetailss.FindAsync(id);
            _context.MasterDetailss.Remove(masterDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterDetailsExists(int id)
        {
            return _context.MasterDetailss.Any(e => e.MasterDetailsSerial == id);
        }
    }
}
