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

namespace Hr.Controllers
{
    public class MenuModelsController : Controller
    {
        private readonly hrContext _context;

        public MenuModelsController(hrContext context)
        {
            _context = context;
        }

        // GET: MenuModels
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
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            return View(await _context.menuemodelss.ToListAsync());
        }

        // GET: MenuModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModels = await _context.menuemodelss
                .FirstOrDefaultAsync(m => m.id == id);
            if (menuModels == null)
            {
                return NotFound();
            }

            return View(menuModels);
        }

        // GET: MenuModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MainMenuId,SubMenuNamear,SubMenuNameen,ControllerName,ActionName,RoleId")] MenuModels menuModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuModels);
        }

        // GET: MenuModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModels = await _context.menuemodelss.FindAsync(id);
            if (menuModels == null)
            {
                return NotFound();
            }
            return View(menuModels);
        }

        // POST: MenuModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MainMenuId,SubMenuNamear,SubMenuNameen,ControllerName,ActionName,RoleId")] MenuModels menuModels)
        {
            if (id != menuModels.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuModelsExists(menuModels.id))
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
            return View(menuModels);
        }

        // GET: MenuModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModels = await _context.menuemodelss
                .FirstOrDefaultAsync(m => m.id == id);
            if (menuModels == null)
            {
                return NotFound();
            }

            return View(menuModels);
        }

        // POST: MenuModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuModels = await _context.menuemodelss.FindAsync(id);
            _context.menuemodelss.Remove(menuModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuModelsExists(int id)
        {
            return _context.menuemodelss.Any(e => e.id == id);
        }
    }
}
