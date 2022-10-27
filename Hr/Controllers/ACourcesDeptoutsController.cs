using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
            return View(await _context.ACourcesDeptouts.ToListAsync());
        }
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> IndexWithout()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
            return View(await _context.ACourcesDeptouts.ToListAsync());
        }

        // GET: ACourcesDeptouts/Details/5
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> DetailsWithout(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
        [Authorize(Roles = "Admin,HR-Admin")]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
            return View();
        }

        // POST: ACourcesDeptouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR-Admin")]
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
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
        [Authorize(Roles = "Admin,HR-Admin")]
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
        [Authorize(Roles = "Admin,HR-Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
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
        [Authorize(Roles = "Admin,HR-Admin")]
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
