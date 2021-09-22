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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Hr.Controllers
{
    public class CempsController : Controller
    {
        private readonly hrContext _context;
        private readonly IHostingEnvironment _hosting;
        public CempsController(hrContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }
        [Authorize(Roles = "Admin")]
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
                mmodule = x.mmodule,
                treeroot = x.treeroot
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            return View(await _context.Cemps.ToListAsync());
        }
        // Get MyInfo
        //[Authorize(Roles = "Admin, User")]
        //[Authorize(Roles ="Admin")]
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
                mmodule=x.mmodule,
                treeroot = x.treeroot
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
            List<Cemp> _Cemps = _context.Cemps.Where(x => x.CEMPADPRTNO ==HttpContext.Session.GetString("empdepid")).Select(x => new Cemp
            {
               Cempid=x.Cempid,
               CEMPNAME=x.CEMPNAME
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["Cemps"] = JsonConvert.SerializeObject(_Cemps);

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

            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == id);
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        public void hader(int id,string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from&&x.CourcesIdmaster==id).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid=id,
                mestypetopic="  معالجة ايام الغياب اثناء الدورة  للموظف  "+ emp.CEMPNAME  +"/ ورقمه الوظيفي  "+emp.Cempid,
                redesc="فترة الدورة  "+course.CourcesStartDate.ToString("d") + "  :  " + course.CourcesEndDate.ToString("d"),
                Daterequest =DateTime.Now


            };


            _context.Add(messagesProcess);
            _context.SaveChanges();

            MessagesDetail OfferedDetailss = new MessagesDetail
                {
                    CourcesIdoffered = messagesProcess.Id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                    OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestTo = "4331051", // status in offerrequestto3  4291135
                    OfferedRequestTo2 = "",// status in offerrequestto4
                    OfferedRequestTo3 = "0",
                    OfferedRequestTo4 = "1",
                    OfferedRequestTo5 = "1",// status for  hrpersonapproval
                    OfferedRequestTypeSatus = 0,
                    OfferedRequestNotes = "",
                    Offeredoption = ""   // will srore hr person

                };
                _context.Add(OfferedDetailss);
                _context.SaveChanges();
            
             




            MessagesRequestTypeId OfferedRequestTypeIds = new MessagesRequestTypeId
            {
                CourcesIdoffered = messagesProcess.Id,
                Offercoursefrom = HttpContext.Session.GetString("empid"),
                OfferedRequestType = 0

            };
            _context.Add(OfferedRequestTypeIds);
            _context.SaveChanges();


            //return RedirectToAction(nameof(Search));

            //return View(aCourcesOffered1);


        }
        public void payroll(int id,  string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from && x.CourcesIdmaster == id).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid = id,
                mestypetopic = " احتساب الاستحقاقات المالية للدورة للموظف   " + emp.CEMPNAME + "  ورقمه الوظيفي " + emp.Cempid,
                redesc = "فترة الدورة " + course.CourcesStartDate.ToString("d") +"  :   "+ course.CourcesEndDate.ToString("d"),
                Daterequest = DateTime.Now


            };
            _context.Add(messagesProcess);
            _context.SaveChanges();

            MessagesDetail OfferedDetailss = new MessagesDetail
                {
                    CourcesIdoffered = messagesProcess.Id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                    OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestTo = "4291135",// status in offerrequestto3
                    OfferedRequestTo2 ="",// status in offerrequestto4
                    OfferedRequestTo3 = "0",
                    OfferedRequestTo4 = "1",
                    OfferedRequestTo5 = "1",// status for  hrpersonapproval
                    OfferedRequestTypeSatus = 0,
                    OfferedRequestNotes = "",
                    Offeredoption = ""   // will srore hr person

                };
                _context.Add(OfferedDetailss);
                _context.SaveChanges();
           
             




            MessagesRequestTypeId OfferedRequestTypeIds = new MessagesRequestTypeId
            {
                CourcesIdoffered = messagesProcess.Id,
                Offercoursefrom = HttpContext.Session.GetString("empid"),
                OfferedRequestType = 0

            };
            _context.Add(OfferedRequestTypeIds);
            _context.SaveChanges();



            //return RedirectToAction(nameof(Search));

            //return View(aCourcesOffered1);


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
                mmodule = x.mmodule,
                treeroot = x.treeroot
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
        [Authorize(Roles = "Admin")]
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
       
        
        
        
        public async Task<IActionResult> Edit3(string id)
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

            var cemp = _context.Cemps.Where(b => b.CEMPNAME == id).FirstOrDefault();
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "CEMPNAME");
            return View(cemp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit3(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.CEMPNAME)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                    var emp22 = _context.Cemps.Where(b => b.Cempid == cemp.Cempid).FirstOrDefault();
                    TransferProcess TransferProcess = new TransferProcess
                    {
                        Olddepid=Convert.ToInt32(emp2.CEMPADPRTNO),
                        Olddepname=emp2.DEP_NAME,
                        Manageolddepid=Convert.ToInt32(emp2.MANAGERID),
                        Manageroldname=emp2.MANAGERNAME,
                        Newdepid=Convert.ToInt32(emp22.CEMPADPRTNO),
                        Newdepname=emp22.DEP_NAME,
                        Managernewid=Convert.ToInt32( emp22.MANAGERID),
                        Managernewname=emp22.MANAGERNAME,
                        Daterequest=DateTime.Now,
                        fromr= HttpContext.Session.GetString("username")

                    };

                    _context.Add(TransferProcess);
                    _context.SaveChanges();

                    TransferDetail transferDetail = new TransferDetail
                    {
                        CourcesIdoffered= _context.TransferProcesss.Max(u => u.Id),
                        OfferedRequestFrom= HttpContext.Session.GetString("username"),
                        OfferedRequestTo= emp2.MANAGERID,
                        OfferedRequestTo2=emp22.MANAGERID,
                        OfferedRequestTo3="0",
                        OfferedRequestTo4 = "1",
                        OfferedRequestTo5 = "1",
                        OfferedRequestTypeSatus=0,
                        OfferedRequestNotes="",
                        Offeredoption= "4321031"



                    };
                    _context.Add(transferDetail);
                    TransferRequestTypeId transferRequestTypeId = new TransferRequestTypeId
                    {
                        CourcesIdoffered= _context.TransferProcesss.Max(u => u.Id),
                        Offercoursefrom= HttpContext.Session.GetString("username"),
                        OfferedRequestType=0

                    };
                    _context.Add(transferRequestTypeId);


                    _context.SaveChanges();

                    //m => m.Cempid == HttpContext.Session.GetString("username")


                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    //emp2.Cempid = cemp.Cempid;
                    //emp2.CEMPPASSWRD = cemp.CEMPPASSWRD;


                    //_context.Update(emp2);
                    //await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Search1));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

        }





        // edit image 
        public async Task<IActionResult> Edit2(string id)
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
        public async Task<IActionResult> Edit2(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID,imagepath,Fileimagepath")] Cemp cemp)
        {
            string extension = Path.GetExtension(cemp.Fileimagepath.FileName);
            if (id != cemp.Cempid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (cemp.Fileimagepath!= null&&(extension== ".jpeg" || extension == ".jpg" || extension == ".png" ||extension == ".gif"||extension== ".jfif"))
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\emps");
                    string fullPath = Path.Combine(uploads, DateTime.Now.ToString("ddMMMyyhhmmsstt")+cemp.Fileimagepath.FileName);
                    cemp.Fileimagepath.CopyTo(new FileStream(fullPath, FileMode.Create));
                    try
                    {
                        var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                        //m => m.Cempid == HttpContext.Session.GetString("username")


                        //emp2.CEMPNAME = cemp.CEMPNAME;
                        emp2.Cempid = cemp.Cempid;
                        emp2.imagepath = DateTime.Now.ToString("ddMMMyyhhmmsstt") + cemp.Fileimagepath.FileName;


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
                }
                else
                {
                    ViewBag.ErrorMessage1 = "يرجي رفع الصورة(jpeg,jpg,png,gif,JFIF) !";
                    //return RedirectToAction(nameof(MyInfo));
                    //ModelState.AddModelError("uploadError", "يرجي رفع الصورة");
                    //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع الصورة!');</script>");
                }
                
                return RedirectToAction(nameof(MyInfo));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

        }


        public async Task<IActionResult> Search1()
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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                           from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where f.OfferedRequestFrom== HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }



        public async Task<IActionResult> approveduser()
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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

        public async Task<IActionResult> canceluser()
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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> approveduserm()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

        public async Task<IActionResult> canceluserm()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

        public ActionResult IndexOffered3()
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


            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0




                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);


        }

        public ActionResult IndexOffered4()
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


            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0
                          //where e.Fromr== HttpContext.Session.GetString("empid")




                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);


        }
        

        public async Task<IActionResult> approveduser1()
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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "1")
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> canceluser1()
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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "2") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "2") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "2")

                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }


        public async Task<IActionResult> approveduser11()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "1")
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> canceluser11()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "2") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "2") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "2")

                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
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
