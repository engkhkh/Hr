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
    public class EvalDetailsController : Controller
    {
        private readonly hrContext _context;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();

        public EvalDetailsController(hrContext context, IMailService mailService)
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
            var OfferDetailssss = _context.EvalDetailss
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
        public async Task<IActionResult> Create( EvalDetail OfferDetails)
        {
          
            //if (OfferDetailssss == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                var OfferDetailssss = _context.EvalDetailss
           .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial== OfferDetails.OfferedDetailsSerial)
           .SingleOrDefault();


                if (OfferDetailssss.OfferedRequestTo == "4419011")
                {

                    OfferDetailssss.OfferedRequestTo3 = "1";
                    OfferDetailssss.OfferedRequestTo4 = "1";
                    OfferDetailssss.OfferedRequestTo5 = "1";
                    OfferDetailssss.OfferedRequestTypeSatus = 1;
                    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    await _context.SaveChangesAsync();
                    Evalcomment offerComments = new Evalcomment
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                        dtapproved = DateTime.Now.Date
                    };

                    _context.Add(offerComments);
                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    await _context.SaveChangesAsync();
                    var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                    var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                    var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                    WelcomeRequest request3 = new WelcomeRequest();
                    request3.UserName = emprequestor.CEMPNAME;
                    request3.header = "ألاداء الوظيفي وميثاق ألاداء ";
<<<<<<< Updated upstream
<<<<<<< HEAD
                    request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2022 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
=======
<<<<<<< HEAD
                    request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2022 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
=======
                    request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
=======
                    request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2022 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
>>>>>>> Stashed changes
                    request3.ToEmail = emprequestor.mail;
                    try
                    {
                        //await mailService.SendEmailAsync(m);
                        await mailService.SendWelcomeEmailAsync(request3);
                    }
                    catch (Exception ex)
                    {
                        loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة ميثاق  الاداء   " + emprequestor.Cempid + "اعتماد ميثاق الاداء " + ex.Message);
                    }



                    return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });




                }

                else
                {
                    if (OfferDetailssss.OfferedRequestTo == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo3 == "0")
                    {
                        OfferDetailssss.OfferedRequestTo3 = "1";
                        OfferDetailssss.OfferedRequestTo4 = "0";
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                        _context.Update(OfferDetailssss);
                        _context.SaveChangesAsync();
                        Evalcomment offerComments = new Evalcomment
                        {
                            Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                            Offerapproval = HttpContext.Session.GetString("empid"),
                            Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                            dtapproved = DateTime.Now.Date
                        };

                        _context.Add(offerComments);
                        _context.SaveChangesAsync();


                        if (OfferDetailssss.OfferedRequestTo2 == "4419011" && OfferDetailssss.OfferedRequestTo4 == "0")
                        {
                            OfferDetailssss.OfferedRequestTo4 = "1";
                            OfferDetailssss.OfferedRequestTo5 = "1";
                            OfferDetailssss.OfferedRequestTypeSatus = 1;
                            OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                            _context.Update(OfferDetailssss);
                            await _context.SaveChangesAsync();

                            var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                            OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                            OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                            _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                            await _context.SaveChangesAsync();
                            var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                            var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                            var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();


                            WelcomeRequest request3 = new WelcomeRequest();
                            request3.UserName = emprequestor.CEMPNAME;
                            request3.header = "ألاداء الوظيفي ميثاق ألاداء ";
                            request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                            request3.ToEmail = emprequestor.mail;
                            try
                            {
                                //await mailService.SendEmailAsync(m);
                                await mailService.SendWelcomeEmailAsync(request3);
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة ميثاق الاداء   " + emprequestor.Cempid + "اعتماد ميثاق الاداء " + ex.Message);
                            }

                        }
<<<<<<< Updated upstream
<<<<<<< HEAD

                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });

=======
<<<<<<< HEAD

                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });

=======

                        return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });

>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
=======

                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });

>>>>>>> Stashed changes

                    }
                    else if (OfferDetailssss.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo4 == "0")
                    {

                        //OfferDetailssss.OfferedRequestTo3 = "1";
                        OfferDetailssss.OfferedRequestTo4 = "1";
                        OfferDetailssss.OfferedRequestTo5 = "1";
                        OfferDetailssss.OfferedRequestTypeSatus = 1;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                        _context.Update(OfferDetailssss);
                        await _context.SaveChangesAsync();

                        Evalcomment offerComments = new Evalcomment
                        {
                            Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                            Offerapproval = HttpContext.Session.GetString("empid"),
                            Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                            dtapproved = DateTime.Now.Date

                        };
                        _context.Add(offerComments);
                        var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                        _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                        await _context.SaveChangesAsync();
                        var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                        var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                        var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                        //WelcomeRequest request = new WelcomeRequest();
                        //request.UserName = empapproval2.CEMPNAME;
                        //request.header = "ألاداء الوظيفي وتقييم ألاداء ";
                        //request.Details = "تم اعتماد تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered+" للموظف    : "+ emprequestor.CEMPNAME;
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
                        //request2.UserName = empapproval1.CEMPNAME;
                        //request2.header = "ألاداء الوظيفي وتقييم ألاداء ";
                        //request2.Details = "تم اعتماد تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered +" للموظف "+emprequestor.CEMPNAME+ " بواسطة   : " + empapproval2.CEMPNAME;
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
                        request3.header = "ألاداء الوظيفي ميثاق ألاداء ";
                        request3.Details = "تم اعتماد ميثاق الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                        request3.ToEmail = emprequestor.mail;
                        try
                        {
                            //await mailService.SendEmailAsync(m);
                            await mailService.SendWelcomeEmailAsync(request3);
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة ميثاق الاداء   " + emprequestor.Cempid + "اعتماد ميثاق " + ex.Message);
                        }
<<<<<<< Updated upstream
<<<<<<< HEAD
                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });
=======
                        return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
=======
                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });
>>>>>>> Stashed changes

                    }
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
            var OfferDetailssss = _context.EvalDetailss
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
        public async Task<IActionResult> Create2( EvalDetail OfferDetails)
        {
          
        

                if (ModelState.IsValid)
                {
                    var OfferDetailssss = _context.EvalDetailss
               .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial == OfferDetails.OfferedDetailsSerial)
               .SingleOrDefault();


                    if (OfferDetailssss.OfferedRequestTo == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo3 == "0")
                    {
                        OfferDetailssss.OfferedRequestTo3 = "0";
                        //OfferDetailssss.OfferedRequestTo4 = "2";
                        OfferDetailssss.OfferedRequestTypeSatus = 0;
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

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 0;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    _context.SaveChanges();
                        return RedirectToAction("IndexOffered3", "ViewModelEvalwithother1", new { area = "" });


                    }
                    else if (OfferDetailssss.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo4 == "0")
                    {
                        OfferDetailssss.OfferedRequestTo3 = "0";
                        OfferDetailssss.OfferedRequestTo4 = "1";
                        OfferDetailssss.OfferedRequestTo5 = "1";
                        OfferDetailssss.OfferedRequestTypeSatus = 0;
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

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 0;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    
                   
                    _context.SaveChanges();
                        return RedirectToAction("IndexOffered4", "ViewModelMasterwithother", new { area = "" });

                    }
                    //else if (OfferDetailssss.Offeredoption == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo5 == "0")
                    //{
                    //    //OfferDetailssss.OfferedRequestTo4 = "2";
                    //    OfferDetailssss.OfferedRequestTo5 = "2";
                    //    OfferDetailssss.OfferedRequestTypeSatus = 2;
                    //    OfferDetailssss.OfferedRequestNotes = OfferDetails.OfferedRequestNotes;
                    //    OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    //_context.Update(OfferDetailssss);
                    //_context.SaveChanges();


                    //Evalcomment offerComments = new Evalcomment
                    //{
                    //    Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                    //    Offerapproval = HttpContext.Session.GetString("empid"),
                    //    Offerdetailscomment = OfferDetails.OfferedRequestNotes
                    //};
                    //_context.Add(offerComments);
                    //_context.SaveChanges();


                    //var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom== OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    //    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 2;
                    //    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    //    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    
                    
                    //_context.SaveChanges();
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

