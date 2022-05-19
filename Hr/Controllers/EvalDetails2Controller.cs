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
<<<<<<< HEAD
using Devart.Data.Oracle;
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e

namespace Hr.Controllers
{
    public class EvalDetails2Controller : Controller
    {
        private readonly hrContext _context;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();
<<<<<<< HEAD
        AEvaluationGoal av1, av2, av3, av4, av5, av6;
        AEvaluationCompetenciesM am1, am2, am3, am4, am5, am6, am7;
        AEvaluationCompetenciesD ad1, ad2, ad3, ad4, ad5, ad6, ad7,
            ad8, ad9, ad10, ad11, ad12, ad13, ad14, ad15, ad16, ad17, ad18, ad19,
            ad20, ad21, ad22, ad23;
        string TNS1 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.13)(PORT=1521)))(CONNECT_DATA=(SID=sadad)));User ID=eservice;Password=eltizam_sjg";
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e

        public EvalDetails2Controller(hrContext context, IMailService mailService)
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
            var OfferDetailssss = _context.EvalDetailss2
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
        public async Task<IActionResult> Create(EvalDetail2 OfferDetails)
        {

            //if (OfferDetailssss == null)
            //{
            //    return NotFound();
            //}

            var golsreq = _context.AEvaluationGoals
           .Where(e => e.CovenantId == OfferDetails.CourcesIdoffered&&e.CovenantGoalsSeq==1)
           .SingleOrDefault();
            if (golsreq.EvaluationTotal == null)
            {
                ViewBag.msg = " الاهداف بالطلب لم يتم تقييمها   ";
                return View();
            }
            var golsreq2 = _context.AEvaluationCompetenciesDs
         .Where(e => e.CovenantId == OfferDetails.CourcesIdoffered && e.CovenantCompetenciesDSeq == 6 && e.CovenantCompetenciesDSeqD==4)
         .SingleOrDefault();
            if (golsreq2.EvaluationTotal == null)
            {
                ViewBag.msg = " الجدارات  بالطلب لم يتم تقييمها   ";
                return View();
            }
<<<<<<< HEAD

            List<AEvaluationGoal> vAEvaluationGoals = _context.AEvaluationGoals.Where(d => d.CovenantId == OfferDetails.CourcesIdoffered).OrderBy(d => d.CovenantGoalsSeq).ToList();
            av1 = vAEvaluationGoals[0];
            av2 = vAEvaluationGoals[1];
            av3 = vAEvaluationGoals[2];
            av4 = vAEvaluationGoals[3];
            if (vAEvaluationGoals.Count > 4)
            {
                av5 = vAEvaluationGoals[4];

            }
            if (vAEvaluationGoals.Count > 5)
            {
                av6 = vAEvaluationGoals[5];
            }
            List<AEvaluationCompetenciesM> vAEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.Where(d => d.CovenantId == OfferDetails.CourcesIdoffered).OrderBy(d => d.CovenantCompetenciesSeq).ToList();
            am1 = vAEvaluationCompetenciesMs[0];
            am2 = vAEvaluationCompetenciesMs[1];
            am3 = vAEvaluationCompetenciesMs[2];
            am4 = vAEvaluationCompetenciesMs[3];
            am5 = vAEvaluationCompetenciesMs[4];
            am6 = vAEvaluationCompetenciesMs[5];
            if (vAEvaluationCompetenciesMs.Count > 6)
            {

                am7 = vAEvaluationCompetenciesMs[6];
            }

            List<AEvaluationCompetenciesD> vAEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.Where(d => d.CovenantId == OfferDetails.CourcesIdoffered).OrderBy(d => d.CovenantCompetenciesDSeq).ThenBy(d => d.CovenantCompetenciesDSeqD).ToList();
            ad1 = vAEvaluationCompetenciesDs[0];
            ad2 = vAEvaluationCompetenciesDs[1];
            ad3 = vAEvaluationCompetenciesDs[2];
            ad4 = vAEvaluationCompetenciesDs[3];
            ad5 = vAEvaluationCompetenciesDs[4];
            ad6 = vAEvaluationCompetenciesDs[5];
            ad7 = vAEvaluationCompetenciesDs[6];
            ad8 = vAEvaluationCompetenciesDs[7];
            ad9 = vAEvaluationCompetenciesDs[8];
            ad10 = vAEvaluationCompetenciesDs[9];
            ad11 = vAEvaluationCompetenciesDs[10];
            ad12 = vAEvaluationCompetenciesDs[11];
            ad13 = vAEvaluationCompetenciesDs[12];
            ad14 = vAEvaluationCompetenciesDs[13];
            ad15 = vAEvaluationCompetenciesDs[14];
            ad16 = vAEvaluationCompetenciesDs[15];
            ad17 = vAEvaluationCompetenciesDs[16];
            ad18 = vAEvaluationCompetenciesDs[17];
            if (vAEvaluationCompetenciesDs.Count > 18)
            {

                ad19 = vAEvaluationCompetenciesDs[18];
                ad20 = vAEvaluationCompetenciesDs[19];
                ad21 = vAEvaluationCompetenciesDs[20];
                ad22 = vAEvaluationCompetenciesDs[21];
                ad23 = vAEvaluationCompetenciesDs[22];
            }

=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
            if (ModelState.IsValid)
            {
                var OfferDetailssss = _context.EvalDetailss2
           .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial== OfferDetails.OfferedDetailsSerial)
           .SingleOrDefault();



                if (OfferDetailssss.OfferedRequestTo == "4419011" )
                {
                   
                        OfferDetailssss.OfferedRequestTo3 = "1";
                        OfferDetailssss.OfferedRequestTo4 = "1";
                        OfferDetailssss.OfferedRequestTo5 = "1";
                        OfferDetailssss.OfferedRequestTypeSatus = 1;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                        _context.Update(OfferDetailssss);
                        await _context.SaveChangesAsync();
                        Evalcomment2 offerComments = new Evalcomment2
                        {
                            Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                            Offerapproval = HttpContext.Session.GetString("empid"),
                            Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                            dtapproved = DateTime.Now.Date
                        };

                        _context.Add(offerComments);
                        var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds2.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                        OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                        _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                        await _context.SaveChangesAsync();
                        var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                        var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                        var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                        WelcomeRequest request3 = new WelcomeRequest();
                        request3.UserName = emprequestor.CEMPNAME;
                        request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
                        request3.Details = "تم اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                        request3.ToEmail = emprequestor.mail;
                        try
                        {
                            //await mailService.SendEmailAsync(m);
                            await mailService.SendWelcomeEmailAsync(request3);
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "اعتماد التقييم " + ex.Message);
                        }

<<<<<<< HEAD
                    if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 5)
                    {
                        // calculation 

                        string tot1 = Convert.ToString(((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30));
                        string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();

                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 6)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                        string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                        ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? "3 " :
                        ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                        ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                        string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                         ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                         ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                         ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                    {
                        // calculation 

                       string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                       string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                      ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                      ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                      ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                        string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                        ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                        ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                        ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();

                    }
                    else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 4)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                       string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                  ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                  ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                  ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                    {
                        // calculation 

                       string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                       string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                        string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                          ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                          ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                          ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }
                    else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                    {
                        // calculation 

                        string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                        string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                       ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                        OracleConnection Con5 = new OracleConnection(TNS1);
                        Con5.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                        //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                        cmd.Connection = Con5;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                        }
                        Con5.Close();
                        //return View(Records);
                    }



                    return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });
=======


                        return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e


                   

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
                        Evalcomment2 offerComments = new Evalcomment2
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

                            var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds2.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                            OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 1;
                            OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                            _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                            await _context.SaveChangesAsync();
                            var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                            var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                            var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                            
                            WelcomeRequest request3 = new WelcomeRequest();
                            request3.UserName = emprequestor.CEMPNAME;
                            request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
                            request3.Details = "تم اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                            request3.ToEmail = emprequestor.mail;
                            try
                            {
                                //await mailService.SendEmailAsync(m);
                                await mailService.SendWelcomeEmailAsync(request3);
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "اعتماد التقييم " + ex.Message);
                            }

<<<<<<< HEAD
                            if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 5)
                            {
                                // calculation 

                                string tot1 = Convert.ToString(((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30));
                                string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                               ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                               ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                               ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();

                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 6)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                                ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? "3 " :
                                ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                                ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                                 ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                                 ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                                 ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();

                            }
                            else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 4)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                                ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                                  ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                                  ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                                  ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }
                            else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                            {
                                // calculation 

                                string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                                string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                               ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                                OracleConnection Con5 = new OracleConnection(TNS1);
                                Con5.Open();
                                OracleCommand cmd = new OracleCommand();
                                cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                                //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                                cmd.Connection = Con5;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                                }
                                Con5.Close();
                                //return View(Records);
                            }

=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
                        }

                            return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });


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

                        Evalcomment2 offerComments = new Evalcomment2
                        {
                            Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                            Offerapproval = HttpContext.Session.GetString("empid"),
                            Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                            dtapproved = DateTime.Now.Date

                        };
                        _context.Add(offerComments);
                        var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds2.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
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
                        request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
                        request3.Details = "تم اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                        request3.ToEmail = emprequestor.mail;
                        try
                        {
                            //await mailService.SendEmailAsync(m);
                            await mailService.SendWelcomeEmailAsync(request3);
                        }
                        catch (Exception ex)
                        {
                            loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "اعتماد التقييم " + ex.Message);
                        }
<<<<<<< HEAD
                        if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 5)
                        {
                            // calculation 

                            string tot1 = Convert.ToString(((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30));
                            string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                           ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();

                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 6)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                            ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? "3 " :
                            ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                            ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : "9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                             ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                             ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                             ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();

                        }
                        else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 23 && vAEvaluationGoals.Count == 4)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .70 + (ad23.EvaluationTotal / 100) * .30), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 4.5 ? "4" :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 3.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 4.5 ? " 3 " :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 2.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 3.5 ? "2" :
                       ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) >= 1.5 && ((av1.EvaluationTotal / 100) * .70) + ((ad23.EvaluationTotal / 100) * .30) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 7 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 4)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                            ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 1.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 5)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                              ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                              ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                              ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }
                        else if (vAEvaluationCompetenciesMs.Count == 6 && vAEvaluationCompetenciesDs.Count == 18 && vAEvaluationGoals.Count == 6)
                        {
                            // calculation 

                            string tot1 = Convert.ToString((double?)Math.Round(Convert.ToDecimal((av1.EvaluationTotal / 100) * .50 + (ad18.EvaluationTotal / 100) * .50), 2));

                            string tot4 = ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 4.5 ? "4" :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 3.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 4.5 ? " 3 " :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 2.5 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 3.5 ? "2" :
                           ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) >= 0 && ((av1.EvaluationTotal / 100) * .50) + ((ad18.EvaluationTotal / 100) * .50) < 2.5 ? "1 " : " 9";


                            OracleConnection Con5 = new OracleConnection(TNS1);
                            Con5.Open();
                            OracleCommand cmd = new OracleCommand();
                            cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('" + emprequestor.CEMPPASSWRD + "', '" + emprequestor.CEMPNO + "','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '" + tot1 + "', " + Convert.ToInt32(tot4) + ") ";
                            //cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
                            cmd.Connection = Con5;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                loggerx.Error("  لم يتم ارسال بيانات  للموظف ب خدمة التزام   " + emprequestor.Cempid + "ارسال بيانات الي التزام  " + ex.Message);
                            }
                            Con5.Close();
                            //return View(Records);
                        }

=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
                        return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });

                    }
                }
             
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
            var OfferDetailssss = _context.EvalDetailss2
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
        public async Task<IActionResult> Create2( EvalDetail2 OfferDetails)
        {
          
        

                if (ModelState.IsValid)
                {
                    var OfferDetailssss = _context.EvalDetailss2
               .Where(e => e.CourcesIdoffered == OfferDetails.CourcesIdoffered && e.OfferedDetailsSerial == OfferDetails.OfferedDetailsSerial)
               .SingleOrDefault();


                    if (OfferDetailssss.OfferedRequestTo == HttpContext.Session.GetString("empid") && OfferDetailssss.OfferedRequestTo3 == "0")
                    {
                        OfferDetailssss.OfferedRequestTo3 = "0";
                    OfferDetailssss.OfferedRequestTo4 = "1";
                    OfferDetailssss.OfferedRequestTypeSatus = 0;
                        OfferDetailssss.OfferedDetailsSerial = OfferDetails.OfferedDetailsSerial;
                    _context.Update(OfferDetailssss);
                    _context.SaveChanges();
                    Evalcomment2 offerComments = new Evalcomment2
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                        dtapproved = DateTime.Now.Date
                    };

                    _context.Add(offerComments);
                    _context.SaveChanges();

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds2.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 0;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    _context.SaveChanges();

                    var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                    var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                    var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                    //WelcomeRequest request = new WelcomeRequest();
                    //request.UserName = empapproval2.CEMPNAME;
                    //request.header = "ألاداء الوظيفي وتقييم ألاداء ";
                    //request.Details = "تم رفض تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " للموظف   : " + emprequestor.CEMPNAME; 
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
                    //request2.Details = "تم رفض تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " للموظف " + emprequestor.CEMPNAME  + " بواسطة   : " + empapproval2.CEMPNAME; 
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
                    request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
                    request3.Details = "تم  رفض اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة   : " + empapproval2.CEMPNAME;
                    request3.ToEmail = emprequestor.mail;
                    try
                    {
                        //await mailService.SendEmailAsync(m);
                        await mailService.SendWelcomeEmailAsync(request3);
                    }
                    catch (Exception ex)
                    {
                        loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "رفض اعتماد  التقييم " + ex.Message);
                    }


                    return RedirectToAction("IndexOffered4", "ViewModelEvalwithother1", new { area = "" });


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

                    Evalcomment2 offerComments = new Evalcomment2
                    {
                        Offerdetailsid = OfferDetails.OfferedDetailsSerial,
                        Offerapproval = HttpContext.Session.GetString("empid"),
                        Offerdetailscomment = OfferDetails.OfferedRequestNotes,
                        dtapproved = DateTime.Now.Date
                    };
                    _context.Add(offerComments);
                    _context.SaveChanges();

                    var OfferRequestTypeIdsMasterRequestTypeIdserial2 = _context.EvalRequestTypeIds2.Where(b => b.CourcesIdoffered == OfferDetails.CourcesIdoffered && b.Offercoursefrom == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.OfferedRequestType = 0;
                    OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered = OfferDetails.CourcesIdoffered;
                    _context.Update(OfferRequestTypeIdsMasterRequestTypeIdserial2);
                    _context.SaveChanges();
                    var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                    var empapproval1 = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestTo).FirstOrDefault();
                    var emprequestor = _context.Cemps.Where(h => h.Cempid == OfferDetailssss.OfferedRequestFrom).FirstOrDefault();

                    //WelcomeRequest request = new WelcomeRequest();
                    //request.UserName = empapproval2.CEMPNAME;
                    //request.header = "ألاداء الوظيفي وتقييم ألاداء ";
                    //request.Details = "تم رفض تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " للموظف   : " + emprequestor.CEMPNAME ;
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
                    //request2.Details = "تم رفض تقييم ألاداء لعام 1443 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " للموظف " + emprequestor.CEMPNAME  + " بواسطة  : " + empapproval2.CEMPNAME;
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
                    request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
                    request3.Details = "تم رفض اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم :" + OfferRequestTypeIdsMasterRequestTypeIdserial2.CourcesIdoffered + " بواسطة  : " + empapproval2.CEMPNAME; 
                    request3.ToEmail = emprequestor.mail;
                    try
                    {
                        //await mailService.SendEmailAsync(m);
                        await mailService.SendWelcomeEmailAsync(request3);
                    }
                    catch (Exception ex)
                    {
                        loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "رفض  التقييم " + ex.Message);
                    }
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

