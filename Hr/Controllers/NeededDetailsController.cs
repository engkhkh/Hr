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
    public class NeededDetailsController : Controller
    {
        private readonly hrContext _context;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();

        public NeededDetailsController(hrContext context, IMailService mailService)
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
            return View(await _context.NeededDetails.ToListAsync());
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

            var offerDetails = await _context.NeededDetails
                .FirstOrDefaultAsync(m => m.OfferedDetailsSerial == id);
            if (offerDetails == null)
            {
                return NotFound();
            }

            return View(offerDetails);
        }

        // GET: MasterDetails/Create
        public  IActionResult Create(int? id, string  from)
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
            var OfferDetailssss = _context.NeededDetails
              .Where(e => e.COURCES_IDOffered == id && e.OfferedRequestFrom == from)
              .SingleOrDefault();
            if (OfferDetailssss == null)
            {
                return NotFound();
            }
            return View(OfferDetailssss);
        }

        // POST: MasterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfferedDetailsSerial,COURCES_IDOffered,OfferedRequestFrom,OfferedRequestTo,OfferedRequestTo2,OfferedRequestTo3,OfferedRequestTo4,OfferedRequestTo5,OfferedRequestTypeSatus,OfferedRequestNotes,Offeredoption")] NeededDetails OfferDetails)
        {
          
           
            if (ModelState.IsValid)
            {
                var OfferDetailssss = _context.NeededDetails
           .Where(e => e.COURCES_IDOffered == OfferDetails.COURCES_IDOffered && e.OfferedDetailsSerial== OfferDetails.OfferedDetailsSerial)
           .SingleOrDefault();

                    OfferDetailssss.OfferedRequestTypeSatus = 1;
                    OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    OfferDetailssss.Offeredoption = HttpContext.Session.GetString("empid");
                    _context.Update(OfferDetailssss);
                   await _context.SaveChangesAsync();

                    NeededComments offerComments = new NeededComments
                    {
                        id = OfferDetails.OfferedDetailsSerial,
                        offerapproval= HttpContext.Session.GetString("empid"),
                        comments = OfferDetails.OfferedRequestNotes
                    };
                    _context.Add(offerComments);
                   await _context.SaveChangesAsync();

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.NeededRequestTypeId.Where(b => b.COURCES_IDOffered == OfferDetails.COURCES_IDOffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                   await _context.SaveChangesAsync();

                var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetails.OfferedRequestFrom).FirstOrDefault();
                var empapproval1 = _context.Cemps.Where(h => h.Cempid == emprequestor.MANAGERID).FirstOrDefault();

               
                WelcomeRequest request3 = new WelcomeRequest();
                request3.UserName = emprequestor.CEMPNAME;
                request3.header = "خدمة مسح ألاحتياج التدريبي للموظفين  ";
                request3.Details = "تم اعتماد  ,طلب رقم :" + OfferDetails.COURCES_IDOffered + " بواسطة : " + empapproval2.CEMPNAME;
                request3.ToEmail = emprequestor.mail;
                try
                {
                    //await mailService.SendEmailAsync(m);
                    await mailService.SendWelcomeEmailAsync(request3);
                }
                catch (Exception ex)
                {
                    loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة مسح الاحتياج التدريبي للموظفين    " + emprequestor.Cempid + "اعتماد خدمة ألاحتياج التدريبي للموظفين   " + ex.Message);
                }
                //return RedirectToAction(nameof(Index));

                return RedirectToAction("IndexOffered4", "ViewModelMasterwithother", new { area = "" });

               
                
            }
            return View(OfferDetails);
            //return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });
        }
        //
        // GET: MasterDetails/Create
        public IActionResult Create2(int? id, string? from)
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
            var OfferDetailssss = _context.NeededDetails
               .Where(e => e.COURCES_IDOffered == id && e.OfferedRequestFrom==from)
               .SingleOrDefault();
            if (OfferDetailssss == null)
            {
                return NotFound();
            }
          

            return View(OfferDetailssss);
        }

        // POST: MasterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("OfferedDetailsSerial,COURCES_IDOffered,OfferedRequestFrom,OfferedRequestTo,OfferedRequestTo2,OfferedRequestTo3,OfferedRequestTo4,OfferedRequestTo5,OfferedRequestTypeSatus,OfferedRequestNotes,Offeredoption")] NeededDetails OfferDetails)
        {
          
        

                if (ModelState.IsValid)
                {
                    var OfferDetailssss = _context.NeededDetails
               .Where(e => e.COURCES_IDOffered == OfferDetails.COURCES_IDOffered && e.OfferedDetailsSerial == OfferDetails.OfferedDetailsSerial)
               .SingleOrDefault();
                        OfferDetailssss.OfferedRequestTypeSatus = 2;
                        OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                OfferDetailssss.Offeredoption = HttpContext.Session.GetString("empid");
                _context.Update(OfferDetailssss);
                   await _context.SaveChangesAsync();


                    NeededComments offerComments = new NeededComments
                    {
                            id = OfferDetails.OfferedDetailsSerial,
                            offerapproval = HttpContext.Session.GetString("empid"),
                            comments = OfferDetails.OfferedRequestNotes
                        };
                    _context.Add(offerComments);
                   await _context.SaveChangesAsync();


                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.NeededRequestTypeId.Where(b => b.COURCES_IDOffered == OfferDetails.COURCES_IDOffered && b.Offercoursefrom== OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 2;
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                        _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                   await   _context.SaveChangesAsync();

                var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetails.OfferedRequestFrom).FirstOrDefault();
                var empapproval1 = _context.Cemps.Where(h => h.Cempid == emprequestor.MANAGERID).FirstOrDefault();


                WelcomeRequest request3 = new WelcomeRequest();
                request3.UserName = emprequestor.CEMPNAME;
                request3.header = "خدمة مسح ألاحتياج التدريبي للموظفين  ";
                request3.Details = "تم  رفض اعتماد  ,طلب رقم :" + OfferDetails.COURCES_IDOffered + " بواسطة : " + empapproval2.CEMPNAME;
                request3.ToEmail = emprequestor.mail;
                try
                {
                    //await mailService.SendEmailAsync(m);
                    await mailService.SendWelcomeEmailAsync(request3);
                }
                catch (Exception ex)
                {
                    loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة مسح الاحتياج التدريبي للموظفين    " + emprequestor.Cempid + "رفض اعتماد  خدمة ألاحتياج التدريبي للموظفين   " + ex.Message);
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("IndexOffered4", "ViewModelMasterwithother", new { area = "" });

                    
            }
            return View(OfferDetails);
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

