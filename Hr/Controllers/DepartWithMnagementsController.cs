using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Hr.Controllers
{
    public class DepartWithMnagementsController : Controller
    {
        private readonly hrContext _context;

        public DepartWithMnagementsController(hrContext context)
        {
            _context = context;
        }
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        // GET: DepartWithMnagements
        public async Task<IActionResult> Index()
        {
            List<MenuModels> _menus = _context.menuemodelss.Where(x => x.RoleId == HttpContext.Session.GetInt32("emprole")).Select(x => new MenuModels
            {
                MainMenuId = x.MainMenuId,
                SubMenuNamear = x.SubMenuNamear,
                id = x.id,
                SubMenuNameen = x.SubMenuNameen,
                ControllerName = x.ControllerName,
                ActionName = x.ActionName,
                RoleId = x.RoleId,
                mmodule = x.mmodule,
                treeroot = x.treeroot
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            return View(await _context.DepartWithMnagement.Where(d=>d.depcode !=null &&d.CEMPADPRTNO== HttpContext.Session.GetString("empdepid")).ToListAsync());
        }

        // GET: DepartWithMnagements/Details/5
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departWithMnagement = await _context.DepartWithMnagement
                .FirstOrDefaultAsync(m => m.id == id);
            if (departWithMnagement == null)
            {
                return NotFound();
            }

            return View(departWithMnagement);
        }

        // GET: DepartWithMnagements/Create
        [Authorize(Roles = "Admin,HR-Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartWithMnagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Create([Bind("id,CEMPADPRTNO,DEP_NAME,MANAGERID,MANAGERNAME,PARENTID,PARENTNAME,PARENTMANAGERID,PARENTMANAGERNAME")] DepartWithMnagement departWithMnagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departWithMnagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departWithMnagement);
        }

        // GET: DepartWithMnagements/Edit/5
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departWithMnagement = await _context.DepartWithMnagement.FindAsync(id);
            if (departWithMnagement == null)
            {
                return NotFound();
            }
            return View(departWithMnagement);
        }

        // POST: DepartWithMnagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("id,CEMPADPRTNO,DEP_NAME,MANAGERID,MANAGERNAME,PARENTID,PARENTNAME,PARENTMANAGERID,PARENTMANAGERNAME")] DepartWithMnagement departWithMnagement)
        {
            if (id != departWithMnagement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departWithMnagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartWithMnagementExists(departWithMnagement.id))
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
            return View(departWithMnagement);
        }

        // GET: DepartWithMnagements/Delete/5
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departWithMnagement = await _context.DepartWithMnagement
                .FirstOrDefaultAsync(m => m.id == id);
            if (departWithMnagement == null)
            {
                return NotFound();
            }

            return View(departWithMnagement);
        }

        // POST: DepartWithMnagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departWithMnagement = await _context.DepartWithMnagement.FindAsync(id);
            _context.DepartWithMnagement.Remove(departWithMnagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartWithMnagementExists(int id)
        {
            return _context.DepartWithMnagement.Any(e => e.id == id);
        }
    }
}
