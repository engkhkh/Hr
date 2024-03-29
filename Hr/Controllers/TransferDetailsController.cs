﻿using System;
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
using NLog;

namespace Hr.Controllers
{
    public class TransferDetailsController : Controller
    {
        private readonly hrContext _context;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();

        public TransferDetailsController(hrContext context, IMailService mailService)
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
            return View(await _context.EvalDetailss.ToListAsync());
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

            var offerDetails = await _context.OfferedDetails
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
            var OfferDetailssss = _context.TransferDetails
              .Where(e => e.CourcesIdoffered == id && e.OfferedRequestFrom == from)
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
        public async Task<IActionResult> Create( TransferDetail OfferDetails)
        {
          
            //if (OfferDetailssss == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                var OfferDetailssss = _context.TransferDetails
           .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial== OfferDetails.OfferedDetailsSerial)
           .SingleOrDefault();


                if (OfferDetailssss.OfferedRequestTo == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo3 == "0")
                {
                    OfferDetailssss.OfferedRequestTo3 = "1";
                    OfferDetailssss.OfferedRequestTo4 = "0";
                    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChangesAsync();
                    Transfercomment offerComments = new Transfercomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    };
                   
                    _context.Add(offerComments);
                    _context.SaveChangesAsync();
                    return RedirectToAction("IndexOffered3", "Cemps", new { area = "" });


                }
               else if (OfferDetailssss.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo4 == "0")
                {
                    //OfferDetailssss.OfferedRequestTo3 = "1";
                    OfferDetailssss.OfferedRequestTo4 = "1";
                    OfferDetailssss.OfferedRequestTo5 = "1";
                    OfferDetailssss.OfferedRequestTypeSatus = 1;
                    OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChangesAsync();

                    Transfercomment offerComments = new Transfercomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    };

                    _context.Add(offerComments);
                    _context.SaveChangesAsync();


                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.TransferRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    _context.SaveChangesAsync();

                    //

                    
                    var emp21 = _context.TransferProcesss.Where(b => b.fromr == OfferDetails.OfferedRequestFrom&&b.Id== OfferDetails.CourcesIdoffered).FirstOrDefault();
                    var emp2 = _context.Cemps.Where(b => b.Cempid == OfferDetails.OfferedRequestFrom&&b.CEMPADPRTNO==Convert.ToString(emp21.Olddepid)&&b.DEP_NAME==emp21.Olddepname&&b.MANAGERID== Convert.ToString(emp21.Manageolddepid)&&b.MANAGERNAME==emp21.Manageroldname).FirstOrDefault();
                    var newdeps = _context.DepartWithMnagement.Where(b => b.CEMPADPRTNO ==Convert.ToString(emp21.Newdepid) && b.depcode != null).FirstOrDefault();


                    emp2.Cempid = emp2.Cempid;
                    emp2.CEMPADPRTNO = newdeps.CEMPADPRTNO;
                    emp2.DEP_NAME = newdeps.DEP_NAME;
                    emp2.MANAGERID = newdeps.MANAGERID;
                    emp2.MANAGERNAME = newdeps.MANAGERNAME;
                    emp2.PARENTID = newdeps.PARENTID;
                    emp2.PARENTNAME = newdeps.PARENTNAME;

                    _context.Update(emp2);
                    await _context.SaveChangesAsync();
                    Transfercomment offerComments1 = new Transfercomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = "4321031",
                        Offerdetailscomment = "تمت المراجعة "
                    };

                    _context.Add(offerComments1);
                    _context.SaveChangesAsync();

                    var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();

                    WelcomeRequest request3 = new WelcomeRequest();
                    request3.UserName = emprequestor.CEMPNAME;
                    request3.header = "النقل الوظيفي وتحديث المدير المباشر  ";
                    request3.Details = "تم اعتماد تحديث المدير المباشر ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                    request3.ToEmail = emprequestor.mail;
                    try
                    {
                        //await mailService.SendEmailAsync(m);
                        await mailService.SendWelcomeEmailAsync(request3);
                    }
                    catch (Exception ex)
                    {
                        loggerx.Error("لم يتم ارسال الايميل للموظف بسبب  "+ex.Message);
                    }

                    return RedirectToAction("IndexOffered3", "Cemps", new { area = "" });

                }
                //else if (OfferDetailssss.Offeredoption == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo5 == "0")
                //{
                //    OfferDetailssss.OfferedRequestTo4 = "1";
                //    OfferDetailssss.OfferedRequestTo5 = "1";
                //    OfferDetailssss.OfferedRequestTypeSatus = 1;
                //    OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                //    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                //    _context.Update(OfferDetailssss);
                //    _context.SaveChangesAsync();

                //    Evalcomment offerComments = new Evalcomment
                //    {
                //        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                //        Offerapproval = HttpContext.Session.GetString("empid"),
                //        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                //    };
                //    _context.Add(offerComments);
                //    _context.SaveChangesAsync();

                //    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                //    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                //    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                //    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                //    _context.SaveChangesAsync();
                //    return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });

                //}
                //if (OfferDetails.OfferedRequestTo4 ==Convert.ToString(0))
                //{
                //    var off = new OfferedDetails
                //    {
                //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                //        OfferedRequestTo= HttpContext.Session.GetString("empid"),
                //        OfferedRequestTo2=OfferDetails.OfferedRequestTo2,
                //        OfferedRequestTo3=null,
                //        OfferedRequestTo4="1",
                //        OfferedRequestTo5="0",
                //        COURCES_IDOffered=OfferDetails.COURCES_IDOffered,
                //        Offeredoption=OfferDetails.Offeredoption,
                //        OfferedRequestTypeSatus=0,
                //        OfferedRequestNotes=OfferDetails.OfferedRequestNotes


                //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTypeSatus = 1,
                //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                //    };
                //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 0;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                //    _context.Add(off);
                //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                //    await _context.SaveChangesAsync();
                //    //return RedirectToAction(nameof(Index));
                //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });



                //}
                //else if(OfferDetails.OfferedRequestTo5 == Convert.ToString(1))
                //{
                //    var off = new OfferedDetails
                //    {
                //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                //        OfferedRequestTo = OfferDetails.OfferedRequestTo2,
                //        OfferedRequestTo2 = HttpContext.Session.GetString("empid"),
                //        OfferedRequestTo3 = null,
                //        OfferedRequestTo4 = "1",
                //        OfferedRequestTo5 = "1",
                //        COURCES_IDOffered = OfferDetails.COURCES_IDOffered,
                //        Offeredoption = OfferDetails.Offeredoption,
                //        OfferedRequestTypeSatus = 1,
                //        OfferedRequestNotes = OfferDetails.OfferedRequestNotes

                //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTypeSatus = 1,
                //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                //    };
                //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 1;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                //    _context.Add(off);
                //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                //    await _context.SaveChangesAsync();
                //    //return RedirectToAction(nameof(Index));
                //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });
                //}
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
            var OfferDetailssss = _context.TransferDetails
               .Where(e => e.CourcesIdoffered == id && e.OfferedRequestFrom==from)
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
        public async Task<IActionResult> Create2( TransferDetail OfferDetails)
        {
          
        

                if (ModelState.IsValid)
                {
                    var OfferDetailssss = _context.TransferDetails
               .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial == OfferDetails.OfferedDetailsSerial)
               .SingleOrDefault();


                    if (OfferDetailssss.OfferedRequestTo == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo3 == "0")
                    {
                        OfferDetailssss.OfferedRequestTo3 = "2";
                        //OfferDetailssss.OfferedRequestTo4 = "2";
                        OfferDetailssss.OfferedRequestTypeSatus = 2;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChanges();
                    Transfercomment offerComments = new Transfercomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    };

                    _context.Add(offerComments);
                    _context.SaveChanges();

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.TransferRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 2;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    _context.SaveChanges();
                        return RedirectToAction("IndexOffered3", "Cemps", new { area = "" });


                    }
                    else if (OfferDetailssss.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo4 == "0")
                    {
                        //OfferDetailssss.OfferedRequestTo3 = "1";
                        OfferDetailssss.OfferedRequestTo4 = "2";
                        OfferDetailssss.OfferedRequestTo5 = "2";
                        OfferDetailssss.OfferedRequestTypeSatus = 2;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChanges();

                    Transfercomment offerComments = new Transfercomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    };
                    _context.Add(offerComments);
                    _context.SaveChanges();

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.TransferRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 2;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    
                   
                    _context.SaveChanges();
                        return RedirectToAction("IndexOffered3", "Cemps", new { area = "" });

                    }
                    else if (OfferDetailssss.Offeredoption == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo5 == "0")
                    {
                        //OfferDetailssss.OfferedRequestTo4 = "2";
                        OfferDetailssss.OfferedRequestTo5 = "2";
                        OfferDetailssss.OfferedRequestTypeSatus = 2;
                        OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChanges();


                    Evalcomment offerComments = new Evalcomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    };
                    _context.Add(offerComments);
                    _context.SaveChanges();


                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom== OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 2;
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                        _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    
                    
                    _context.SaveChanges();
                        return RedirectToAction("IndexOffered3", "Cemps", new { area = "" });

                    }
                    //if (OfferDetails.OfferedRequestTo4 ==Convert.ToString(0))
                    //{
                    //    var off = new OfferedDetails
                    //    {
                    //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                    //        OfferedRequestTo= HttpContext.Session.GetString("empid"),
                    //        OfferedRequestTo2=OfferDetails.OfferedRequestTo2,
                    //        OfferedRequestTo3=null,
                    //        OfferedRequestTo4="1",
                    //        OfferedRequestTo5="0",
                    //        COURCES_IDOffered=OfferDetails.COURCES_IDOffered,
                    //        Offeredoption=OfferDetails.Offeredoption,
                    //        OfferedRequestTypeSatus=0,
                    //        OfferedRequestNotes=OfferDetails.OfferedRequestNotes


                    //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                    //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                    //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                    //        //MasterRequestTypeSatus = 1,
                    //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                    //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                    //    };
                    //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                    //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 0;
                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                    //    _context.Add(off);
                    //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                    //    await _context.SaveChangesAsync();
                    //    //return RedirectToAction(nameof(Index));
                    //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });



                    //}
                    //else if(OfferDetails.OfferedRequestTo5 == Convert.ToString(1))
                    //{
                    //    var off = new OfferedDetails
                    //    {
                    //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                    //        OfferedRequestTo = OfferDetails.OfferedRequestTo2,
                    //        OfferedRequestTo2 = HttpContext.Session.GetString("empid"),
                    //        OfferedRequestTo3 = null,
                    //        OfferedRequestTo4 = "1",
                    //        OfferedRequestTo5 = "1",
                    //        COURCES_IDOffered = OfferDetails.COURCES_IDOffered,
                    //        Offeredoption = OfferDetails.Offeredoption,
                    //        OfferedRequestTypeSatus = 1,
                    //        OfferedRequestNotes = OfferDetails.OfferedRequestNotes

                    //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                    //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                    //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                    //        //MasterRequestTypeSatus = 1,
                    //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                    //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                    //    };
                    //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                    //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 1;
                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                    //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                    //    _context.Add(off);
                    //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                    //    await _context.SaveChangesAsync();
                    //    //return RedirectToAction(nameof(Index));
                    //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });
                    //}
                


                //var off = new OfferedDetails
                //{
                //    OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                //    OfferedRequestTo = HttpContext.Session.GetString("empid"),
                //    OfferedRequestTo2 = OfferDetails.OfferedRequestTo2,
                //    OfferedRequestTo3 = null,
                //    OfferedRequestTo4 = "1",
                //    OfferedRequestTo5 = "0",
                //    COURCES_IDOffered = OfferDetails.COURCES_IDOffered,
                //    Offeredoption = OfferDetails.Offeredoption,
                //    OfferedRequestTypeSatus = 0,
                //    OfferedRequestNotes = OfferDetails.OfferedRequestNotes


                //    //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                //    //MasterRequestTo = HttpContext.Session.GetString("empid"),
                //    //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                //    //MasterRequestTypeSatus = 1,
                //    //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                //    //MasterRequestNotes = MasterDetails.MasterRequestNotes
                //};
                //var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                ////MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                //OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 0;
                //OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                //OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                //_context.Add(off);
                //_context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                //await _context.SaveChangesAsync();
                ////return RedirectToAction(nameof(Index));
                //return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });
                //if (OfferDetails.OfferedRequestTo4 == Convert.ToString(0))
                //{
                //    var off = new OfferedDetails
                //    {
                //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                //        OfferedRequestTo = HttpContext.Session.GetString("empid"),
                //        OfferedRequestTo2 = OfferDetails.OfferedRequestTo2,
                //        OfferedRequestTo3 = null,
                //        OfferedRequestTo4 = "1",
                //        OfferedRequestTo5 = "0",
                //        COURCES_IDOffered = OfferDetails.COURCES_IDOffered,
                //        Offeredoption = OfferDetails.Offeredoption,
                //        OfferedRequestTypeSatus = 0,
                //        OfferedRequestNotes = OfferDetails.OfferedRequestNotes


                //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTypeSatus = 1,
                //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                //    };
                //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 0;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                //    _context.Add(off);
                //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                //    await _context.SaveChangesAsync();
                //    //return RedirectToAction(nameof(Index));
                //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });



                //}
                //else if (OfferDetails.OfferedRequestTo5 == Convert.ToString(1))
                //{
                //    var off = new OfferedDetails
                //    {
                //        OfferedRequestFrom = OfferDetails.OfferedRequestFrom,
                //        OfferedRequestTo = OfferDetails.OfferedRequestTo2,
                //        OfferedRequestTo2 = HttpContext.Session.GetString("empid"),
                //        OfferedRequestTo3 = null,
                //        OfferedRequestTo4 = "1",
                //        OfferedRequestTo5 = "1",
                //        COURCES_IDOffered = OfferDetails.COURCES_IDOffered,
                //        Offeredoption = OfferDetails.Offeredoption,
                //        OfferedRequestTypeSatus = 2,
                //        OfferedRequestNotes = OfferDetails.OfferedRequestNotes

                //        //OfferedRequestFrom = OfferDetails.MasterRequestFrom,
                //        //MasterRequestTo = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTo2 = HttpContext.Session.GetString("empid"),
                //        //MasterRequestTypeSatus = 1,
                //        //COURCES_IDMASTER = MasterDetails.COURCES_IDMASTER,
                //        //MasterRequestNotes = MasterDetails.MasterRequestNotes
                //    };
                //    var OfferRequestTypeIdsOfferRequestTypeIdserial2 = _context.OfferedRequestTypeId.Where(b => b.OfferedRequestTypeIdsOfferedRequestTypeIdserial == OfferDetails.OfferedDetailsSerial).FirstOrDefault();

                //    //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestType = 2;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.OfferedRequestTypeIdsOfferedRequestTypeIdserial = OfferDetails.OfferedDetailsSerial;
                //    OfferRequestTypeIdsOfferRequestTypeIdserial2.COURCES_IDOffered = OfferDetails.COURCES_IDOffered;
                //    _context.Add(off);
                //    _context.Update(OfferRequestTypeIdsOfferRequestTypeIdserial2);
                //    await _context.SaveChangesAsync();
                //    //return RedirectToAction(nameof(Index));
                //    return RedirectToAction("IndexOffered", "ViewModelMasterwithother", new { area = "" });
                //}
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

