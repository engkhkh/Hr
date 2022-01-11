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
using Hr.Services;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading;
using NLog;

namespace Hr.Controllers
{
    public class MasterDetailsController : Controller
    {
        private readonly hrContext _context;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();

        public MasterDetailsController(hrContext context, IMailService mailService)
        {
            _context = context;
            this.mailService = mailService;
        }

        // GET: MasterDetails
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
            return View(await _context.MasterDetailss.ToListAsync());
        }
        public void SomeAction1(int id, string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from && x.CourcesIdmaster == id).FirstOrDefault();
            var coursetypemethod = _context.ACourcesTrainingMethods.Where(x => x.CourcesIdTraining == course.CourcesIdTraining).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid = id,
                mestypetopic = "  معالجة ايام الغياب اثناء الدورة  للموظف  " + emp.CEMPNAME + "/ ورقمه الوظيفي  " + emp.Cempid,
                redesc = "فترة الدورة  " + course.CourcesStartDate.ToString("d") + "  :  " + course.CourcesEndDate.ToString("d")+Environment.NewLine+"وعدد ألايام "+course.CourcesNumberofdays + Environment.NewLine + "ومكان الدورة " + coursetypemethod.CourcesNameTraining,
                Daterequest = DateTime.Now


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
        public void SomeAction11(int id, string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from && x.CourcesIdmaster == id).FirstOrDefault();
            var coursetypemethod = _context.ACourcesTrainingMethods.Where(x => x.CourcesIdTraining ==course.CourcesIdTraining).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid = id,
                mestypetopic = " احتساب الاستحقاقات المالية للدورة للموظف   " + emp.CEMPNAME + "  ورقمه الوظيفي " + emp.Cempid,
                redesc = "فترة الدورة " + course.CourcesStartDate.ToString("d") + "  :   " + course.CourcesEndDate.ToString("d") + Environment.NewLine + "وعدد ألايام " + course.CourcesNumberofdays+ Environment.NewLine + "ومكان الدورة "+ coursetypemethod.CourcesNameTraining,
                Daterequest = DateTime.Now


            };
            _context.Add(messagesProcess);
            _context.SaveChanges();

            MessagesDetail OfferedDetailss = new MessagesDetail
            {
                CourcesIdoffered = messagesProcess.Id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                OfferedRequestTo = "4291135",// status in offerrequestto3
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
        // GET: MasterDetails/Details/5
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

            var MasterDetails = await _context.MasterDetailss
                .FirstOrDefaultAsync(m => m.MasterDetailsSerial == id);
            if (MasterDetails == null)
            {
                return NotFound();
            }

            return View(MasterDetails);
        }

        // GET: MasterDetails/Create
        public IActionResult Create(int ?id)
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

            //var MasterDetails = await _context.MasterDetailss.FindAsync(id);
            var MasterDetailssss = _context.MasterDetailss
               .Where(e => e.COURCES_IDMASTER == id)
               .SingleOrDefault();
            if (MasterDetailssss == null)
            {
                return NotFound();
            }
            return View(MasterDetailssss);
        }
        public void SomeAction(int id)
        {
            //Do work here.

            //var depwithmangforemps = _context.DepartWithMnagement.Where(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"))
            //                      .ToList<DepartWithMnagement>();

            var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefault(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));
            // var reqdetails=_context.ac
            //int count = depwithmangforemps.Count;
            //int count = 1;
            if (depwithmangforemp != null)
            {
                //var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefaultAsync(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));

                MessagesDetail OfferedDetailss = new MessagesDetail
                {
                    CourcesIdoffered = id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                    OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestTo = depwithmangforemp.MANAGERID,// status in offerrequestto3
                    OfferedRequestTo2 = depwithmangforemp.PARENTMANAGERID,// status in offerrequestto4
                    OfferedRequestTo3 = "0",
                    OfferedRequestTo4 = "1",
                    OfferedRequestTo5 = "1",// status for  hrpersonapproval
                    OfferedRequestTypeSatus = 0,
                    OfferedRequestNotes = "",
                    Offeredoption = "4321031"   // will srore hr person

                };
                _context.Add(OfferedDetailss);
                _context.SaveChanges();
            }
            else
            {
                //foreach (var item in depwithmangforemps)
                //{
                //    string x = item.MANAGERID;

                //}
            }




            MessagesRequestTypeId OfferedRequestTypeIds = new MessagesRequestTypeId
            {
                CourcesIdoffered = id,
                Offercoursefrom = HttpContext.Session.GetString("empid"),
                OfferedRequestType = 0

            };
            _context.Add(OfferedRequestTypeIds);
            _context.SaveChanges();


            //return RedirectToAction(nameof(Search));

            //return View(aCourcesOffered1);


        }



        // POST: MasterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasterDetailsSerial,COURCES_IDMASTER,MasterRequestFrom,MasterRequestTo,MasterRequestTypeSatus,MasterRequestNotes")] MasterDetails MasterDetails)
        {
            if (ModelState.IsValid)
            {
                var mas = new MasterDetails
                {
                    MasterRequestFrom = "",
                    MasterRequestTo = HttpContext.Session.GetString("empid"),
                    MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                    MasterRequestTypeSatus = 1,
                    COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                    MasterRequestNotes = MasterDetails.MasterRequestNotes
                };
                var MasterRequestTypeIdsMasterRequestTypeIdserial2 = _context.MasterRequestTypeIds.Where(b => b.COURCES_IDMASTER == MasterDetails.COURCES_IDMASTER).FirstOrDefault();

                //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestType = 1;
                MasterRequestTypeIdsMasterRequestTypeIdserial2.COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER;
                _context.Add(mas);
                _context.Update(MasterRequestTypeIdsMasterRequestTypeIdserial2);
                await _context.SaveChangesAsync();
                var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                var emprequestor = _context.Cemps.Where(h => h.Cempid == MasterDetails.MasterRequestFrom).FirstOrDefault();
                var empapproval1 = _context.Cemps.Where(h => h.Cempid == emprequestor.MANAGERID).FirstOrDefault();

                //WelcomeRequest request = new WelcomeRequest();
                //request.UserName = empapproval2.CEMPNAME;
                //request.header = "أرشفة الدورات التدريبية ";
                //request.Details = "تم اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + "  للموظف  " + emprequestor.CEMPNAME/*+ "بواسطة   : "+ empapproval2.CEMPNAME*/;
                //request.ToEmail = empapproval2.mail;
                //try
                //{
                //    //await mailService.SendEmailAsync(m);
                //    await mailService.SendWelcomeEmailAsync(request);
                //}
                //catch (Exception ex)
                //{

                //}
                //WelcomeRequest request2 = new WelcomeRequest();
                //request2.UserName = emprequestor.MANAGERNAME;
                //request2.header = "أرشفة الدورات التدريبية ";
                //request2.Details = "تم اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + "  للموظف  " + emprequestor.CEMPNAME + "بواسطة  : " + empapproval2.CEMPNAME;
                //request2.ToEmail = empapproval1.mail;
                //try
                //{
                //    //await mailService.SendEmailAsync(m);
                //    await mailService.SendWelcomeEmailAsync(request2);
                //}
                //catch (Exception ex)
                //{

                //}
                WelcomeRequest request3 = new WelcomeRequest();
                request3.UserName = emprequestor.CEMPNAME;
                request3.header = "أرشفة الدورات التدريبية ";
                request3.Details = "تم اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + " بواسطة : " + empapproval2.CEMPNAME;
                request3.ToEmail = emprequestor.mail;
                try
                {
                    //await mailService.SendEmailAsync(m);
                    await mailService.SendWelcomeEmailAsync(request3);
                }
                catch (Exception ex)
                {
                    loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة الارشفة    " + emprequestor.Cempid + "اعتماد دورة ارشفة  " + ex.Message);
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "ViewModelMasterwithother", new { area = "" });
            }
            return View(MasterDetails);
        }
        //
        // GET: MasterDetails/Create
        public IActionResult Create2(int? id)
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

            //var MasterDetails = await _context.MasterDetailss.FindAsync(id);
            var MasterDetailssss = _context.MasterDetailss
               .Where(e => e.COURCES_IDMASTER == id)
               .SingleOrDefault();
            if (MasterDetailssss == null)
            {
                return NotFound();
            }
            return View(MasterDetailssss);
        }

        // POST: MasterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("MasterDetailsSerial,COURCES_IDMASTER,MasterRequestFrom,MasterRequestTo,MasterRequestTypeSatus,MasterRequestNotes")] MasterDetails MasterDetails)
        {
            if (ModelState.IsValid)
            {
                var mas = new MasterDetails
                {
                    MasterRequestFrom = "",
                    MasterRequestTo = HttpContext.Session.GetString("empid"),
                    MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                    MasterRequestTypeSatus = 2,
                    COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                    MasterRequestNotes = MasterDetails.MasterRequestNotes
                };
                var MasterRequestTypeIdsMasterRequestTypeIdserial2 = _context.MasterRequestTypeIds.Where(b => b.COURCES_IDMASTER == MasterDetails.COURCES_IDMASTER).FirstOrDefault();

                //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestType = 2;
                MasterRequestTypeIdsMasterRequestTypeIdserial2.COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER;
               
                _context.Add(mas);
                _context.Update(MasterRequestTypeIdsMasterRequestTypeIdserial2);
                await _context.SaveChangesAsync();
                var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                var emprequestor = _context.Cemps.Where(h => h.Cempid == MasterDetails.MasterRequestFrom).FirstOrDefault();
                var empapproval1 = _context.Cemps.Where(h => h.Cempid == emprequestor.MANAGERID).FirstOrDefault();

                //WelcomeRequest request = new WelcomeRequest();
                //request.UserName = empapproval2.CEMPNAME;
                //request.header = "أرشفة الدورات التدريبية ";
                //request.Details = "تم رفض اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + "  للموظف  " + emprequestor.CEMPNAME /* + " بواسطة    : " + empapproval2.CEMPNAME*/;
                //request.ToEmail = empapproval2.mail;
                //try
                //{
                //    //await mailService.SendEmailAsync(m);
                //    await mailService.SendWelcomeEmailAsync(request);
                //}
                //catch (Exception ex)
                //{

                //}
                //WelcomeRequest request2 = new WelcomeRequest();
                //request2.UserName = emprequestor.MANAGERNAME;
                //request2.header = "أرشفة الدورات التدريبية ";
                //request2.Details = "تم  رفض اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + "  للموظف  " + emprequestor.CEMPNAME  + " بواسطة  : " + empapproval2.CEMPNAME;
                //request2.ToEmail = empapproval1.mail;
                //try
                //{
                //    //await mailService.SendEmailAsync(m);
                //    await mailService.SendWelcomeEmailAsync(request2);
                //}
                //catch (Exception ex)
                //{

                //}
                WelcomeRequest request3 = new WelcomeRequest();
                request3.UserName = emprequestor.CEMPNAME;
                request3.header = "أرشفة الدورات التدريبية ";
                request3.Details = "تم رفض اعتماد أرشفة دورة تدريبية ,طلب رقم :" + MasterDetails.COURCES_IDMASTER + " بواسطة : " + empapproval2.CEMPNAME;
                request3.ToEmail = emprequestor.mail;
                try
                {
                    //await mailService.SendEmailAsync(m);
                    await mailService.SendWelcomeEmailAsync(request3);
                }
                catch (Exception ex)
                {
                    loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة ارشفة الدورات    " + emprequestor.Cempid + "رفض اعتماد دورة ارشفة  " + ex.Message);
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "ViewModelMasterwithother", new { area = "" });
            }
            return View(MasterDetails);
        }
        // GET: MasterDetails/Edit/5
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

            //var MasterDetails = await _context.MasterDetailss.FindAsync(id);
            var MasterDetailssss = _context.MasterDetailss
               .Where(e => e.COURCES_IDMASTER == id)
               .SingleOrDefault();
            if (MasterDetailssss == null)
            {
                return NotFound();
            }
            return View(MasterDetailssss);
        }

        // POST: MasterDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MasterDetailsSerial,COURCES_IDMASTER,MasterRequestFrom,MasterRequestTo,MasterRequestTypeSatus,MasterRequestNotes")] MasterDetails MasterDetails)
        {
            if (id != MasterDetails.MasterDetailsSerial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mas = new MasterDetails
                    {
                        MasterRequestFrom = "",
                        MasterRequestTo = "",
                        MasterRequestTypeSatus = 1,
                        COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                        MasterRequestNotes = MasterDetails.MasterRequestNotes
                    };
                    var mt = new MasterRequestTypeId
                    {
                        MasterRequestTypeIdsMasterRequestTypeIdserial = _context.MasterRequestTypeIds.Max(u => u.MasterRequestTypeIdsMasterRequestTypeIdserial),
                        MasterRequestType = 2,
                        COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER
                    };
                    _context.Add(mas);
                    _context.Update(mt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterDetailsExists(MasterDetails.MasterDetailsSerial))
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
            return View(MasterDetails);
        }

        // GET: MasterDetails/Delete/5
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

            var MasterDetails = await _context.MasterDetailss
                .FirstOrDefaultAsync(m => m.MasterDetailsSerial == id);
            if (MasterDetails == null)
            {
                return NotFound();
            }

            return View(MasterDetails);
        }

        // POST: MasterDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MasterDetails = await _context.MasterDetailss.FindAsync(id);
            _context.MasterDetailss.Remove(MasterDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterDetailsExists(int id)
        {
            return _context.MasterDetailss.Any(e => e.MasterDetailsSerial == id);
        }
    }
}
