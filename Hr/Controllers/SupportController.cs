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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Hr.Controllers
{
    public class SupportController : Controller
    {
        private readonly hrContext _context;
        private string extension;
        private string file1;
        private readonly IHostingEnvironment _hosting;

        public SupportController(hrContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        // GET: ACourcesTypes
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
            return View(await _context.SupportProcesses.ToListAsync());
        }
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
            return View(await _context.ACourcesTypes.ToListAsync());
        }

        // GET: ACourcesTypes/Details/5
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

            var aCourcesType = await _context.ACourcesTypes
                .FirstOrDefaultAsync(m => m.CourcesIdType == id);
            if (aCourcesType == null)
            {
                return NotFound();
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
            return View(aCourcesType);
        }
        public async Task<IActionResult> DetailsWithout(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Show", "Account", new { area = "" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesType = await _context.ACourcesTypes
                .FirstOrDefaultAsync(m => m.CourcesIdType == id);
            if (aCourcesType == null)
            {
                return NotFound();
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
            return View(aCourcesType);
        }
<<<<<<< Updated upstream
        [Authorize(Roles = "Admin,Manager,User,HR-Admin")]
=======
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
>>>>>>> Stashed changes
        // GET: ACourcesTypes/Create
        public IActionResult ticket()
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

        // POST: ACourcesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ticket(SupportProcess supportProcess)
        {

            if (supportProcess.Filecer != null)
            {
                extension = Path.GetExtension(supportProcess.Filecer.FileName);
            }
            if (supportProcess.Filecer != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
            {
                file1 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + supportProcess.Filecer.FileName;
                string uploads = Path.Combine(_hosting.WebRootPath, @"img\ticket");
                string fullPath = Path.Combine(uploads, file1);
                supportProcess.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                ViewBag.ErrorMessage = "يرجي رفع مرفق للتوضيح (jpeg, jpg, png, gif, jfif,pdf)!";
                return View(supportProcess);
                //ModelState.AddModelError("uploadError", "يرجي رفع شهادة الدورة");
                //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع شهادة الدورة!');</script>");
            }


            if (ModelState.IsValid)
            {
                SupportProcess supportProcess1 = new SupportProcess()
                {
                    Daterequest=DateTime.Now,
                    Fromr= HttpContext.Session.GetString("username"),
                    Mestypereqidp=file1,
                    Mestypetopic= supportProcess.Mestypetopic,
                    Redesc= supportProcess.Redesc
                };

                _context.Add(supportProcess1);
                await _context.SaveChangesAsync();
                SupportDetail supportDetail = new SupportDetail()
                {
                    CourcesIdoffered= supportProcess1.Id,
                    OfferedRequestFrom= HttpContext.Session.GetString("username"),
                    OfferedRequestTo= "4331021",
                    OfferedRequestTo2= "4331021",
                    OfferedRequestTo3= "0",
                    OfferedRequestTo4="1",
                    OfferedRequestTo5="1",
                    Offeredoption="4281001",
                    OfferedRequestNotes="",
                    OfferedRequestTypeSatus=0
                    


                };
                _context.Add(supportDetail);
                await _context.SaveChangesAsync();

                SupportRequestTypeId supportRequestTypeId = new SupportRequestTypeId()
                {
                    CourcesIdoffered= supportProcess1.Id,
                    Offercoursefrom= HttpContext.Session.GetString("username"),
                    OfferedRequestType=0

                };
                _context.Add(supportRequestTypeId);
                await _context.SaveChangesAsync();


                return RedirectToAction("mytickets", "Support", new { area = "" });
                //return RedirectToAction(nameof(Index));
            }
            return View(supportProcess);
        }

        public ActionResult mytickets()
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


            List<SupportProcess> SupportProcess = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in SupportProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          //join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          //from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          //where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0
                          where e.Fromr == HttpContext.Session.GetString("empid")




                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //ACourcesMaster = dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,

                          };
            return View(Records);


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

            List<SupportProcess> SupportProcess = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();
            List<Supportcomment> supportcomments = _context.Supportcomments.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in SupportProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                              //from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          //where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1
                          where e.Fromr == HttpContext.Session.GetString("empid")

                          join dd in supportcomments on f.OfferedDetailsSerial equals dd.Offerdetailsid into table11
                          from dd in table11.ToList()


                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //ACourcesMaster = dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,
                              Supportscomment = dd,

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

            List<SupportProcess> SupportProcess = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();
            List<Supportcomment> supportcomments = _context.Supportcomments.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in SupportProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                              //from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          //where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2
                          where e.Fromr == HttpContext.Session.GetString("empid")

                          join dd in supportcomments on f.OfferedDetailsSerial equals dd.Offerdetailsid into table11
                          from dd in table11.ToList()


                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //ACourcesMaster = dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,
                              Supportscomment = dd,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }


        public async Task<IActionResult> approveduser111()
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

            List<SupportProcess> SupportProcess = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();
            List<Supportcomment> supportcomments = _context.Supportcomments.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in SupportProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                              //from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (f.Offeredoption == HttpContext.Session.GetString("empid"))
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1
                          //where e.Fromr == HttpContext.Session.GetString("empid")

                          join dd in supportcomments on f.OfferedDetailsSerial equals dd.Offerdetailsid into table11
                          from dd in table11.ToList()




                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //ACourcesMaster = dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,
                              Supportscomment=dd,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> canceluser111()
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

            List<SupportProcess> SupportProcess = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();
            List<Supportcomment> supportcomments = _context.Supportcomments.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in SupportProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                              //from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (f.Offeredoption == HttpContext.Session.GetString("empid"))
                          //where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2
                          //where e.Fromr == HttpContext.Session.GetString("empid")

                          join dd in supportcomments on f.OfferedDetailsSerial equals dd.Offerdetailsid into table11
                          from dd in table11.ToList()


                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //ACourcesMaster = dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,
                              Supportscomment = dd,
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


            List<SupportProcess> SupportProcesss = _context.SupportProcesses.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();
            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();
           

            var Records = from e in SupportProcesss
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in SupportDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in SupportRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0




                          select new ViewModelTransferwithother
                          {
                              SupportProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              SupportsDetail = f,
                              SupportsRequestTypeId = h,

                          };
            return View(Records);


        }
        // GET: ACourcesTypes/Edit/5
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

            var aCourcesType = await _context.ACourcesTypes.FindAsync(id);
            if (aCourcesType == null)
            {
                return NotFound();
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
            return View(aCourcesType);
        }

        // POST: ACourcesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdType,CourcesTypeName")] ACourcesType aCourcesType)
        {
            if (id != aCourcesType.CourcesIdType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesTypeExists(aCourcesType.CourcesIdType))
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
            return View(aCourcesType);
        }

        // GET: ACourcesTypes/Delete/5
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

            var aCourcesType = await _context.ACourcesTypes
                .FirstOrDefaultAsync(m => m.CourcesIdType == id);
            if (aCourcesType == null)
            {
                return NotFound();
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
            return View(aCourcesType);
        }

        // POST: ACourcesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesType = await _context.ACourcesTypes.FindAsync(id);
            _context.ACourcesTypes.Remove(aCourcesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesTypeExists(int id)
        {
            return _context.ACourcesTypes.Any(e => e.CourcesIdType == id);
        }
    }
}
