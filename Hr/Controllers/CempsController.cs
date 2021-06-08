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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            return View(await _context.Cemps.ToListAsync());
        }
        // Get MyInfo
        public async Task<IActionResult> MyInfo()
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
                mmodule=x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == HttpContext.Session.GetString("username"));
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        // GET: Cemps/Details/5
        public async Task<IActionResult> Details(string id)
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
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
        // update role in table 
        public IActionResult Role()
        {
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["Cemprole"] = new SelectList(_context.roless, "Id", "Roles");

            return View();
        }

        // POST: Cemps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Role([Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (ModelState.IsValid)
            {
                var cempss = _context.Cemps.Where(b => b.Cempid == cemp.Cempid).FirstOrDefault();

                //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                cempss.Cempid = cemp.Cempid;
                cempss.CROLEID = cemp.CROLEID;
                
                _context.Update(cempss);
                //_context.Add(cemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cemp);
        }
        //role 1
        public async Task<IActionResult> Role1(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname",cemp.Cempid);
            ViewData["Cemprole"] = new SelectList(_context.roless, "Id", "Roles");
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
        public async Task<IActionResult> Role1(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
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
        // GET: Cemps/Edit/5
        public async Task<IActionResult> Edit(string id)
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
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
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();

                 

                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    emp2.Cempid = cemp.Cempid;
                    emp2.CROLEID = cemp.CROLEID;
                    
                    
                    _context.Update(emp2);
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
        // edit password 
        public async Task<IActionResult> Edit1(string id)
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.Cempid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                    //m => m.Cempid == HttpContext.Session.GetString("username")


                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    emp2.Cempid = cemp.Cempid;
                    emp2.CEMPPASSWRD = cemp.CEMPPASSWRD;


                    _context.Update(emp2);
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
                return RedirectToAction(nameof(MyInfo));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

        }

        // GET: Cemps/Delete/5
        public async Task<IActionResult> Delete(string id)
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
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
