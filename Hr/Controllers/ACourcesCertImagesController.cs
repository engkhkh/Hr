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
    public class ACourcesCertImagesController : Controller
    {
        private readonly hrContext _context;

        public ACourcesCertImagesController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesCertImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ACourcesCertImages.ToListAsync());
        }

        // GET: ACourcesCertImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImage = await _context.ACourcesCertImages
                .FirstOrDefaultAsync(m => m.CourcesIdImagecert == id);
            if (aCourcesCertImage == null)
            {
                return NotFound();
            }

            return View(aCourcesCertImage);
        }

        // GET: ACourcesCertImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACourcesCertImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdImagecert,CourcesIdmaster,ImageName,ImagePath,ImageType,ImageCreatedDate,FileName1,Note")] ACourcesCertImage aCourcesCertImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesCertImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aCourcesCertImage);
        }

        // GET: ACourcesCertImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImage = await _context.ACourcesCertImages.FindAsync(id);
            if (aCourcesCertImage == null)
            {
                return NotFound();
            }
            return View(aCourcesCertImage);
        }

        // POST: ACourcesCertImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdImagecert,CourcesIdmaster,ImageName,ImagePath,ImageType,ImageCreatedDate,FileName1,Note")] ACourcesCertImage aCourcesCertImage)
        {
            if (id != aCourcesCertImage.CourcesIdImagecert)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesCertImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesCertImageExists(aCourcesCertImage.CourcesIdImagecert))
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
            return View(aCourcesCertImage);
        }

        // GET: ACourcesCertImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesCertImage = await _context.ACourcesCertImages
                .FirstOrDefaultAsync(m => m.CourcesIdImagecert == id);
            if (aCourcesCertImage == null)
            {
                return NotFound();
            }

            return View(aCourcesCertImage);
        }

        // POST: ACourcesCertImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesCertImage = await _context.ACourcesCertImages.FindAsync(id);
            _context.ACourcesCertImages.Remove(aCourcesCertImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesCertImageExists(int id)
        {
            return _context.ACourcesCertImages.Any(e => e.CourcesIdImagecert == id);
        }
    }
}
