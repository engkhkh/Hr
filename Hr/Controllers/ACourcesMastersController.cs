using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Hr.Services;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading;
using NLog;
using Hr.Enums;

namespace Hr.Controllers
{
    public class ACourcesMastersController : Controller
    {
        private readonly hrContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly IDataProtector _protector;
        private readonly IMailService mailService;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();
        //NLog.Logger loggerx = LogManager.GetCurrentClassLogger();
        string extension2="", extension="";
        int result = 0;

        public ACourcesMastersController(hrContext context, IHostingEnvironment hosting, IDataProtectionProvider provider, IMailService mailService)
        {
            _context = context;
            _hosting = hosting;
            _protector = provider.CreateProtector("Hr.ViewModelMasterwithotherController");
            this.mailService = mailService;
        }
<<<<<<< HEAD
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public ActionResult ApprovelAllCourses(/*string SearchString,*/ string b2)
=======
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public ActionResult ApprovelAllCourses(string search)
>>>>>>> 5e413685df04d775df33e2d553756a01df850c9b
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
          
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
<<<<<<< HEAD
            if (b2 == null)
            {
=======
>>>>>>> 5e413685df04d775df33e2d553756a01df850c9b
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList()
<<<<<<< HEAD
                                  //where i.Cempid == HttpContext.Session.GetString("empid")
                              //where i.Cempid == e.Cempid && e.CourcesEndDate >= i.CEMPLASTUPGRADEHIJRA && (e.CourcesEndDate <= Convert.ToDateTime(b2)) && (i.Cempid == SearchString || i.CEMPPASSWRD == SearchString)
=======
                              //where i.Cempid == HttpContext.Session.GetString("empid")
>>>>>>> 5e413685df04d775df33e2d553756a01df850c9b
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                              where x.MasterRequestType == 1
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
<<<<<<< HEAD
                              where y.MasterRequestTypeSatus == 1
=======
                              where y.MasterRequestTypeSatus == 1 
>>>>>>> 5e413685df04d775df33e2d553756a01df850c9b
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                foreach (var course in Records.ToList())
                {
                    var stringId = course.ACourcesMasters.CourcesIdmaster.ToString();
                    course.ACourcesMasters.EncryptedIdd = _protector.Protect(stringId);
<<<<<<< HEAD
                    //emp.AEvaluationGoal.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesM.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesD.EncryptedCovenantId= _protector.Protect(stringId);

                    ////Previous code removed for the example clarity
                    //var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
                    //var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
                    ////just to test that this action works as long as life-time hasn't expired
                    //var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
                    //Thread.Sleep(3000);
                    //var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);
                    if (course.ACourcesMasters.CourcesIdType == 1)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 30.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 2)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 80.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 60.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب بالقطاع الخاص"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 3)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 3 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 1.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {

                        if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 1)
                        {
                            course.ACourcesMasters.gradetocourse = 50.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 2)
                        {
                            course.ACourcesMasters.gradetocourse = 25.0;
                        }
                    }
                }
                return View(Records);
            }
            else
            {
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList()
                                  //where i.Cempid == HttpContext.Session.GetString("empid")
                              where i.Cempid == e.Cempid && e.CourcesEndDate >= i.CEMPLASTUPGRADEHIJRA && (e.CourcesEndDate <= Convert.ToDateTime(b2)) /*&& (i.Cempid == SearchString || i.CEMPPASSWRD == SearchString)*/
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                              where x.MasterRequestType == 1
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
                              where y.MasterRequestTypeSatus == 1
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                foreach (var course in Records.ToList())
                {
                    var stringId = course.ACourcesMasters.CourcesIdmaster.ToString();
                    course.ACourcesMasters.EncryptedIdd = _protector.Protect(stringId);
                    //emp.AEvaluationGoal.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesM.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesD.EncryptedCovenantId= _protector.Protect(stringId);

                    ////Previous code removed for the example clarity
                    //var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
                    //var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
                    ////just to test that this action works as long as life-time hasn't expired
                    //var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
                    //Thread.Sleep(3000);
                    //var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);
                    if (course.ACourcesMasters.CourcesIdType == 1)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 30.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 2)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 80.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 60.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب بالقطاع الخاص"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 3)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 3 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 1.0;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {

                        if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 1)
                        {
                            course.ACourcesMasters.gradetocourse = 50.0;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 2)
                        {
                            course.ACourcesMasters.gradetocourse = 25.0;
                        }
                    }
                }
                return View(Records);
            }
=======
                //emp.AEvaluationGoal.EncryptedCovenantId= _protector.Protect(stringId);
                //emp.AEvaluationCompetenciesM.EncryptedCovenantId= _protector.Protect(stringId);
                //emp.AEvaluationCompetenciesD.EncryptedCovenantId= _protector.Protect(stringId);

                ////Previous code removed for the example clarity
                //var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
                //var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
                ////just to test that this action works as long as life-time hasn't expired
                //var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
                //Thread.Sleep(3000);
                //var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);
                if (course.ACourcesMasters.CourcesIdType == 1)
                {
                    if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                    {
                        course.ACourcesMasters.gradetocourse = 40.0;
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {
                        course.ACourcesMasters.gradetocourse = 30.0;
                    }
                }
                else if (course.ACourcesMasters.CourcesIdType == 2)
                {
                    if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                    {
                        course.ACourcesMasters.gradetocourse = 80.0;
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {
                        course.ACourcesMasters.gradetocourse = 60.0;
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب بالقطاع الخاص"))
                    {
                        course.ACourcesMasters.gradetocourse = 40.0;
                    }
                }
                else if (course.ACourcesMasters.CourcesIdType == 3)
                {
                    if (course.ACourcesMasters.CourcesIdType == 3 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {
                        course.ACourcesMasters.gradetocourse = 1.0;
                    }
                }
                else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                {

                    if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 1)
                    {
                        course.ACourcesMasters.gradetocourse = 50.0;
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 2)
                    {
                        course.ACourcesMasters.gradetocourse = 25.0;
                    }
                }
            }
                return View(Records);
            
>>>>>>> 5e413685df04d775df33e2d553756a01df850c9b


           






            //// Current aCourcesMasters
            //var aCourcesMasters = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            //// Filter down if necessary
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    // Normal search term
            //    var term = searchName;
            //    // Attempt to parse it as an integer
            //    var integerTerm = -1;
            //    Int32.TryParse(searchName, out integerTerm);
            //    // Now search for a contains with the term and an equals on the ID
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagehr.Contains(term) || p.CourcesId == integerTerm);
            //}
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagecert.Contains(searchName) || p.CourcesIdImagehr.Contains(searchName));
            //}
            //// Pass your list out to your view
            //return View(aCourcesMasters.ToList());
        }

       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public ActionResult ApprovelAllCourses1(string selectedtTime)
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
            ViewData["name"] = new SelectList(_context.Cemps, "Cempid", "CEMPNAME");
            double sumgrade = 0.0;
            TempData["sumgrade"] = "";
           
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList()
                              where i.Cempid == e.Cempid && e.CourcesEndDate >= i.CEMPLASTUPGRADEHIJRA && i.Cempid == HttpContext.Session.GetString("username")
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                              where x.MasterRequestType == 1
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
                              where y.MasterRequestTypeSatus == 1
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                foreach (var course in Records.ToList())
                {
                    var stringId = course.ACourcesMasters.CourcesIdmaster.ToString();
                    course.ACourcesMasters.EncryptedIdd = _protector.Protect(stringId);
                    //var emppro = _context.Cemps.Where(x => x.Cempid == course.ACourcesMasters.Cempid).FirstOrDefault();
                    //emp.AEvaluationGoal.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesM.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesD.EncryptedCovenantId= _protector.Protect(stringId);

                    ////Previous code removed for the example clarity
                    //var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
                    //var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
                    ////just to test that this action works as long as life-time hasn't expired
                    //var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
                    //Thread.Sleep(3000);
                    //var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);
                    if (course.ACourcesMasters.CourcesIdType == 1)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 1 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 30.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 2)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب دولية"))
                        {
                            course.ACourcesMasters.gradetocourse = 80.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 60.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 2 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب بالقطاع الخاص"))
                        {
                            course.ACourcesMasters.gradetocourse = 40.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 3)
                    {
                        if (course.ACourcesMasters.CourcesIdType == 3 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                        {
                            course.ACourcesMasters.gradetocourse = 1.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                    }
                    else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية"))
                    {

                        if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 1)
                        {
                            course.ACourcesMasters.gradetocourse = 50.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                        else if (course.ACourcesMasters.CourcesIdType == 4 && course.ACourcesMasters.COURCES_EXCUTION.Equals("جهة تدريب حكومية") && course.ACourcesMasters.CourcesIdEstimate == 2)
                        {
                            course.ACourcesMasters.gradetocourse = 25.0;
                            sumgrade += course.ACourcesMasters.gradetocourse;
                        }
                    }

                    //course.ACourcesMasters.gradetocourset = sumgrade;
                }

                if (sumgrade >= 100.00)
                {
                    //TempData["sumgrade"] = "100.00";
                    // course.ACourcesMasters.gradetocourset = 100.0;
                }
                else
                {
                    //TempData["sumgrade1"] = sumgrade;
                }
                return View(Records);

           
              







            //// Current aCourcesMasters
            //var aCourcesMasters = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            //// Filter down if necessary
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    // Normal search term
            //    var term = searchName;
            //    // Attempt to parse it as an integer
            //    var integerTerm = -1;
            //    Int32.TryParse(searchName, out integerTerm);
            //    // Now search for a contains with the term and an equals on the ID
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagehr.Contains(term) || p.CourcesId == integerTerm);
            //}
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagecert.Contains(searchName) || p.CourcesIdImagehr.Contains(searchName));
            //}
            //// Pass your list out to your view
            //return View(aCourcesMasters.ToList());
        }

        // GET: ACourcesMasters
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
         
            var hrContext = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName");
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdmaster");
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");

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
            return View(await hrContext.ToListAsync());
        }
        public ActionResult Search(string search)
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
            if (search == null)
            {
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList() where i.Cempid == HttpContext.Session.GetString("empid")
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                              where x.MasterRequestType == 0
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
                              where y.MasterRequestTypeSatus == 0 && y.MasterRequestTypeSatus != 2 && y.MasterRequestTypeSatus != 1
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                foreach (var emp in Records.ToList())
                {
                    var stringId = emp.ACourcesMasters.CourcesIdmaster.ToString();
                    emp.ACourcesMasters.EncryptedIdd = _protector.Protect(stringId);
                    //emp.AEvaluationGoal.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesM.EncryptedCovenantId= _protector.Protect(stringId);
                    //emp.AEvaluationCompetenciesD.EncryptedCovenantId= _protector.Protect(stringId);

                    ////Previous code removed for the example clarity
                    //var timeLimitedProtector = _protector.ToTimeLimitedDataProtector();
                    //var timeLimitedData = timeLimitedProtector.Protect("Test timed protector", lifetime: TimeSpan.FromSeconds(2));
                    ////just to test that this action works as long as life-time hasn't expired
                    //var timedUnprotectedData = timeLimitedProtector.Unprotect(timeLimitedData);
                    //Thread.Sleep(3000);
                    //var anotherTimedUnprotectTry = timeLimitedProtector.Unprotect(timeLimitedData);
                }
                return View(Records);
            }
           
           
            else 
            {
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList()  where i.Cempid == HttpContext.Session.GetString("empid")
                              //where i.CEMPNAME.Contains(search)
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                              where x.MasterRequestType == 0
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList() where y.MasterRequestTypeSatus==0 && y.MasterRequestTypeSatus!=2 &&y.MasterRequestTypeSatus != 1
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()
                              where z.CourcesName.Contains(search)


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                return View(Records);

            }

           




            //// Current aCourcesMasters
            //var aCourcesMasters = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            //// Filter down if necessary
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    // Normal search term
            //    var term = searchName;
            //    // Attempt to parse it as an integer
            //    var integerTerm = -1;
            //    Int32.TryParse(searchName, out integerTerm);
            //    // Now search for a contains with the term and an equals on the ID
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagehr.Contains(term) || p.CourcesId == integerTerm);
            //}
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagecert.Contains(searchName) || p.CourcesIdImagehr.Contains(searchName));
            //}
            //// Pass your list out to your view
            //return View(aCourcesMasters.ToList());
        }
        public ActionResult Search11(string search)
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
            if (search == null)
            {
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList() where i.Cempid == HttpContext.Session.GetString("empid")
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                                  //where x.MasterRequestType != 0
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                return View(Records);
            }


            else
            {
                List<ACourcesType> ACourcesTypes = _context.ACourcesTypes.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesEstimate> ACourcesEstimates = _context.ACourcesEstimates.ToList();
                List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesMasters
                              join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList() where i.Cempid == HttpContext.Session.GetString("empid")
                              //where i.CEMPNAME.Contains(search)
                              join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              from j in table3.ToList()
                              join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                              from x in table7.ToList()
                                  //where x.MasterRequestType != 0
                              join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                              from y in table8.ToList()
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()
                              where z.CourcesName.Contains(search)


                              select new ViewModelMasterwithother
                              {
                                  ACourcesMasters = e,
                                  ACourcesTypes = d,
                                  Cemps = i,
                                  ACourcesEstimates = j,
                                  ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  MasterRequestTypeIds = x,
                                  MasterDetails = y,
                                  ACourcesNames = z
                              };
                return View(Records);

            }






            //// Current aCourcesMasters
            //var aCourcesMasters = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            //// Filter down if necessary
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    // Normal search term
            //    var term = searchName;
            //    // Attempt to parse it as an integer
            //    var integerTerm = -1;
            //    Int32.TryParse(searchName, out integerTerm);
            //    // Now search for a contains with the term and an equals on the ID
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagehr.Contains(term) || p.CourcesId == integerTerm);
            //}
            //if (!String.IsNullOrEmpty(searchName))
            //{
            //    aCourcesMasters = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ACourcesMaster, ACourcesName>)aCourcesMasters.Where(p => p.CourcesIdImagecert.Contains(searchName) || p.CourcesIdImagehr.Contains(searchName));
            //}
            //// Pass your list out to your view
            //return View(aCourcesMasters.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: ACourcesMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<MenuModels> _menus = _context.menuemodelss.Where(x => x.RoleId == HttpContext.Session.GetInt32("emprole")).Select(x => new MenuModels
            {
                MainMenuId = x.MainMenuId,
                SubMenuNamear = x.SubMenuNamear,
                id = x.id,
                SubMenuNameen = x.SubMenuNameen,
                ControllerName = x.ControllerName,
                ActionName = x.ActionName,
                RoleId = x.RoleId,
                treeroot = x.treeroot
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesMaster = await _context.ACourcesMasters
                .Include(a => a.Cemp)
                .Include(a => a.Cources)
                .FirstOrDefaultAsync(m => m.CourcesIdmaster == id);
            if (aCourcesMaster == null)
            {
                return NotFound();
            }

            return View(aCourcesMaster);
        }
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        // GET: ACourcesMasters/Create
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
            /*
             List<ACourcesName> ACourcesName1 = new List<ACourcesName>();
            List<ACourcesTrainingMethod> ACourcesTrainingMethod1 = new List<ACourcesTrainingMethod>();
            List<ACourcesType> ACourcesType1 = new List<ACourcesType>();
            List<Cemp> Cemp1 = new List<Cemp>(); 
            List<ACourcesEstimate> ACourcesEstimate1 = new List<ACourcesEstimate>(); 
            List<ACourcesDeptout> ACourcesDeptout1 = new List<ACourcesDeptout>();
            List<ACourcesDeptin> ACourcesDeptin1 = new List<ACourcesDeptin>();
            List<ACourcesCertImagehr> ACourcesCertImagehr1 = new List<ACourcesCertImagehr>();
            List<ACourcesCertImage> ACourcesCertImage1 = new List<ACourcesCertImage>();


            // ACourcesName1 code
            ACourcesName1 = (from product in _context.ACourcesNames
                              
                              select product).ToList();

            ACourcesName1.Insert(0, new ACourcesName{ CourcesId=0, CourcesName="select" }) ;
            ViewBag.ACourcesName1 = ACourcesName1;
            //ACourcesTrainingMethod1 code
            ACourcesTrainingMethod1 = (from product in _context.ACourcesTrainingMethods

                             select product).ToList();

            ACourcesTrainingMethod1.Insert(0, new ACourcesTrainingMethod { CourcesIdTraining = 0, CourcesNameTraining = "select" });
            ViewBag.ACourcesTrainingMethod1 = ACourcesTrainingMethod1;
            // ACourcesType code
            ACourcesType1 = (from product in _context.ACourcesTypes

                             select product).ToList();

            ACourcesType1.Insert(0, new ACourcesType { CourcesIdType = 0, CourcesTypeName = "select" });
            ViewBag.ACourcesType1 = ACourcesType1;


            // Cemp1 code
            Cemp1 = (from product in _context.Cemps

                             select product).ToList();

            Cemp1.Insert(0, new Cemp { Cempid = "0", Cempname = "select" });
            ViewBag.Cemp1 = Cemp1;
            //ACourcesEstimate1 code
            ACourcesEstimate1 = (from product in _context.ACourcesEstimates

                     select product).ToList();

            ACourcesEstimate1.Insert(0, new ACourcesEstimate { CourcesIdEstimate = 0, CourcesNameEstimate = "select" });
            ViewBag.ACourcesEstimate1 = ACourcesEstimate1;

            // ACourcesDeptout1 code 
            ACourcesDeptout1 = (from product in _context.ACourcesDeptouts

                             select product).ToList();

            ACourcesDeptout1.Insert(0, new ACourcesDeptout { CourcesIdDeptout = 0, CourcesNameDeptout = "select" });
            ViewBag.ACourcesDeptout1 = ACourcesDeptout1;
            //ACourcesDeptin1 code 

            ACourcesDeptin1 = (from product in _context.ACourcesDeptins

                             select product).ToList();

            ACourcesDeptin1.Insert(0, new ACourcesDeptin { CourcesIdDeptin = 0, CourcesNameDeptin = "select" });
            ViewBag.ACourcesDeptin1 = ACourcesDeptin1;
            // ACourcesCertImagehr1 code  
            ACourcesCertImagehr1 = (from product in _context.ACourcesCertImagehrs

                             select product).ToList();

            ACourcesCertImagehr1.Insert(0, new ACourcesCertImagehr { CourcesIdImagehr = 0, CourcesIdmaster = 0 });
            ViewBag.ACourcesCertImagehr1 = ACourcesCertImagehr1;

            //ACourcesCertImage1 code

            ACourcesCertImage1 = (from product in _context.ACourcesCertImages

                             select product).ToList();

            ACourcesCertImage1.Insert(0, new ACourcesCertImage { CourcesIdImagecert = 0, CourcesIdmaster = 0 });
            ViewBag.ACourcesCertImage1 = ACourcesCertImage1;

            //
             */
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName");
            ViewData["CourcesIdImagecert"]= new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdmaster");
            ViewData["ACourcesCertImagehr"]= new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"]= new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"]= new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"]= new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"]= new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"]= new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");


            return View();
        }

        // POST: ACourcesMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid,Filecer,Filehr,COURCES_EXCUTION")] ACourcesMaster aCourcesMaster)
        {
            // dublicate 
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
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName");
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdmaster");
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins.Where(d=>d.newcode!=null), "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");

            // end dublicate in  post create 
            if (aCourcesMaster.CourcesIdType == 0 || aCourcesMaster.CourcesIdmaster == 5 || aCourcesMaster.CourcesIdDeptout==0 || aCourcesMaster.CourcesIdTraining==0)
            {
                ViewBag.ErrorMessage3 = "يرجي أخيار نوع ومكان وجهةوأسم الدورة من القائمة بشكل صحيح ولا يتم اختيار العنصر -تحديد-!!   ";
                return View(aCourcesMaster);
              
            }

            if (aCourcesMaster.Filecer != null)
            {
                 extension = Path.GetExtension(aCourcesMaster.Filecer.FileName);
            }
           
            if (aCourcesMaster.Filehr != null)
            {
                 extension2 = Path.GetExtension(aCourcesMaster.Filehr.FileName);
            }
           
            var objuser1 = _context.Cemps.Where(b => b.Cempid == HttpContext.Session.GetString("empid")).FirstOrDefault();
            var coursesforuser = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId== aCourcesMaster.CourcesId&&b.CourcesStartDate== aCourcesMaster.CourcesStartDate).FirstOrDefault();
            if (coursesforuser!=null)
            {
                var coursesforuserapptoval = _context.MasterRequestTypeIds.Where(d => d.COURCES_IDMASTER == coursesforuser.CourcesIdmaster).FirstOrDefault();
                if (aCourcesMaster.CourcesIdType != 3)
                {
                    if (coursesforuserapptoval.MasterRequestType != 2)
                    {
                        ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ البداية ";
                        return View(aCourcesMaster);
                    }
                }
            }
            var coursesforuser1 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId&& b.CourcesEndDate == aCourcesMaster.CourcesEndDate).FirstOrDefault();
            if (coursesforuser1 != null)
            {
                var coursesforuserapptoval = _context.MasterRequestTypeIds.Where(d => d.COURCES_IDMASTER == coursesforuser1.CourcesIdmaster).FirstOrDefault();
                if (aCourcesMaster.CourcesIdType != 3)
                {
                    if (coursesforuserapptoval.MasterRequestType != 2)
                    {
                        ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ النهاية ";
                        return View(aCourcesMaster);
                    }
                }
            }
            var coursesforuser11 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") /*&& b.CourcesId == aCourcesMaster.CourcesId*/ && (b.CourcesIdType == 1 || b.CourcesIdType == 2 || b.CourcesIdType == 4) && (b.CourcesStartDate <= aCourcesMaster.CourcesStartDate && aCourcesMaster.CourcesStartDate <= b.CourcesEndDate)).ToList();
            if (coursesforuser11.Count != 0)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") /*&& b.CourcesId == aCourcesMaster.CourcesId*/ && (b.CourcesIdType == 1 || b.CourcesIdType == 2 || b.CourcesIdType == 4) && (b.CourcesStartDate <= aCourcesMaster.CourcesStartDate && aCourcesMaster.CourcesStartDate <= b.CourcesEndDate)).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                //var coursesforuserapptoval = _context.MasterRequestTypeIds.Where(d => d.COURCES_IDMASTER == aCourcesMaster.CourcesIdmaster).FirstOrDefault();

                //if (coursesforuserapptoval.MasterRequestType != 2)
                //{
                if (aCourcesMaster.CourcesIdType != 3)
                { 
                if (yy1446.ToList().Count > 0)
                {
                    ViewBag.ErrorMessage3 = "لا يمكن ارشفة الدورة لوجود الموظف بدورة اخري بنفس التاريخ   ";
                    return View(aCourcesMaster);
                    //}
                }
                }
            }
            if (aCourcesMaster.CourcesIdType == 3)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
                var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
                var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
                var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
                var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
                var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
                var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).Count();
                if (coursesforuser20count1446 >= 20 || coursesforuser20count1445 >= 20 || coursesforuser20count1444 >= 20 || coursesforuser20count1443 >= 20 || coursesforuser20count1442 >= 20 || coursesforuser20count1441 >= 20 || coursesforuser20count1440 >= 20|| coursesforuser20count1439>=20|| coursesforuser20count1438>=20)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if(yy1446.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 20 || yy1445.ToList().Count >= 20 || yy1444.ToList().Count >= 20 || yy1443.ToList().Count >= 20 || yy1442.ToList().Count >= 20 || yy1441.ToList().Count >= 20 || yy1440.ToList().Count >= 20 || yy1439.ToList().Count >= 20 || yy1438.ToList().Count >= 20)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }
            if (aCourcesMaster.CourcesIdType == 1)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();

                var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
                var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
                var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
                var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
                var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
                var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
                var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 &&(b.CourcesEndDate.Year == 1439)).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 &&(b.CourcesEndDate.Year == 1438)).Count();
                if (coursesforuser2count1446 >= 2 || coursesforuser2count1445 >= 2 || coursesforuser2count1444 >= 2 || coursesforuser2count1443 >= 2 || coursesforuser2count1442 >= 2 || coursesforuser2count1441 >= 2 || coursesforuser2count1440 >= 2 || coursesforuser20count1439 >= 2 || coursesforuser20count1438 >= 2)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if (yy1446.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 2 || yy1445.ToList().Count >= 2 || yy1444.ToList().Count >= 2 || yy1443.ToList().Count >= 2 || yy1442.ToList().Count >= 2 || yy1441.ToList().Count >= 2 || yy1440.ToList().Count >= 2 || yy1439.ToList().Count >= 2 || yy1438.ToList().Count >= 2)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }
            string x = "", y = "",file1="",file2="";

            if (aCourcesMaster.Filecer != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
            {
                file1 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filecer.FileName;
                string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath = Path.Combine(uploads,file1);
                aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                ViewBag.ErrorMessage = "يرجي رفع شهادة الدورة (jpeg, jpg, png, gif, jfif,pdf)!";
                return View(aCourcesMaster);
                //ModelState.AddModelError("uploadError", "يرجي رفع شهادة الدورة");
                //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع شهادة الدورة!');</script>");
            }

            //
            if (aCourcesMaster.Filehr != null && (extension2 == ".jpeg" || extension2 == ".jpg" || extension2 == ".png" || extension2 == ".gif" || extension2 == ".jfif" || extension == ".pdf"))
            {
                file2 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filehr.FileName;
                string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                string fullPath2 = Path.Combine(uploads2,file2);
                aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                x = file2;
            }
            else
            {
                y = "";
            }
           
            
            if (ModelState.IsValid)
            {
                ACourcesMaster aCourcesMasteritems = new ACourcesMaster
                {
                    CourcesIdmaster = aCourcesMaster.CourcesIdmaster,
                    CourcesId = aCourcesMaster.CourcesId,
                    CourcesIdType = aCourcesMaster.CourcesIdType,
                    CourcesIdDeptin = Convert.ToInt32(HttpContext.Session.GetString("empdepid")) /*aCourcesMaster.CourcesIdDeptin*/,
                    CourcesIdTraining = aCourcesMaster.CourcesIdTraining,
                    CourcesIdDeptout = aCourcesMaster.CourcesIdDeptout,
                    CourcesIdEstimate = aCourcesMaster.CourcesIdEstimate,
                    CourcesIdImagecert = file1,
                    CourcesIdImagehr = x == x ? x : y,
                    CourcesStartDate = aCourcesMaster.CourcesStartDate,
                    CourcesEndDate = aCourcesMaster.CourcesEndDate,
                    CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1,
                    CourcesPassRate = aCourcesMaster.CourcesPassRate,
                    COURCES_EXCUTION = aCourcesMaster.COURCES_EXCUTION,
                    Cempid = HttpContext.Session.GetString("empid")


                };
               
                 
                
                MasterRequestTypeId MasterRequestTypeIds = new MasterRequestTypeId
                {
                    COURCES_IDMASTER = _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestType = 0

                };
                MasterDetails MasterDetailss = new MasterDetails
                {
                    COURCES_IDMASTER= _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestFrom= HttpContext.Session.GetString("empid"),
                    MasterRequestTo= "4321031",
                    MasterRequestTo2= "4411013",
                    MasterRequestTo3 = "4321038",
                    MasterRequestTo4 = "123",
                    MasterRequestTo5 = "4411011",
                    MasterRequestTypeSatus =0,
                    MasterRequestNotes=""

                };
                ACourcesName newcourcename = new ACourcesName
                {
                   

                    CourcesName = aCourcesMaster.CourcesPassRate
                       
                };

                //_context.Add(aCourcesMasteritems);
                //await _context.SaveChangesAsync();
                //int z=0,zz=0;
                if (objuser1.CEMPLASTUPGRADEHIJRA > objuser1.CEMPHIRINGDATEHIJRA)
                {
                    if (aCourcesMasteritems.CourcesEndDate < aCourcesMasteritems.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة قبل  تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (aCourcesMasteritems.CourcesEndDate> objuser1.CEMPLASTUPGRADEHIJRA)
                    {
                        // z = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.CEMPLASTUPGRADEHIJRA);
                        //zz = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.Cemplastupgrade);
                        if (aCourcesMaster.CourcesPassRate != null)
                        {
                            var newcourcename1 = _context.ACourcesNames.Where(b => b.CourcesName.Equals(aCourcesMaster.CourcesPassRate)).FirstOrDefault();
                            if (newcourcename1 != null)
                            {
                                ViewBag.ErrorMessage3 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                                return View(aCourcesMaster);
                            }
                            else
                            {
                                _context.Add(newcourcename);
                                await _context.SaveChangesAsync();
                                aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);
                            }

                        }
                        _context.Add(aCourcesMasteritems);
                        await _context.SaveChangesAsync();
                        _context.Add(MasterRequestTypeIds);
                        _context.Add(MasterDetailss);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage1 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ آخر ترقية  ";
                        return View(aCourcesMaster);
                        //ViewBag.Message = "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!');</script>");
                        //ModelState.AddModelError("CourcesStartDate", "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!");


                    }

                }
                if (objuser1.CEMPLASTUPGRADEHIJRA <= objuser1.CEMPHIRINGDATEHIJRA)
                {
                    //if (aCourcesMasteritems.CourcesEndDate < aCourcesMasteritems.CourcesStartDate)
                    //{
                    //    ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة قبل  تاريخ بداية الدورة   ";
                    //    return View(aCourcesMaster);
                    //}
                    if (aCourcesMasteritems.CourcesEndDate > objuser1.CEMPHIRINGDATEHIJRA)
                    {
                        if (aCourcesMaster.CourcesPassRate != null)
                        {
                            var newcourcename1 = _context.ACourcesNames.Where(b => b.CourcesName.Equals(aCourcesMaster.CourcesPassRate)).FirstOrDefault();
                            if (newcourcename1 != null)
                            {
                                ViewBag.ErrorMessage3 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                                return View(aCourcesMaster);
                            }
                            else
                            {
                                _context.Add(newcourcename);
                                await _context.SaveChangesAsync();
                                aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);
                            }

                        }
                        _context.Add(aCourcesMasteritems);
                        await _context.SaveChangesAsync();
                        _context.Add(MasterRequestTypeIds);
                        _context.Add(MasterDetailss);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage2 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ التعين ";
                        return View(aCourcesMaster);
                        // ViewBag.Message = "تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!');</script>");
                    }

                }

                //if (result > 0)
                //{
                //    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Employee added");
                //}
                //else ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Search", "ACourcesMasters", new { area = "" });
            }
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");

            return View(aCourcesMaster);
        }

        // GET: ACourcesMasters/Create
        public IActionResult Create11()
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
            /*
             List<ACourcesName> ACourcesName1 = new List<ACourcesName>();
            List<ACourcesTrainingMethod> ACourcesTrainingMethod1 = new List<ACourcesTrainingMethod>();
            List<ACourcesType> ACourcesType1 = new List<ACourcesType>();
            List<Cemp> Cemp1 = new List<Cemp>(); 
            List<ACourcesEstimate> ACourcesEstimate1 = new List<ACourcesEstimate>(); 
            List<ACourcesDeptout> ACourcesDeptout1 = new List<ACourcesDeptout>();
            List<ACourcesDeptin> ACourcesDeptin1 = new List<ACourcesDeptin>();
            List<ACourcesCertImagehr> ACourcesCertImagehr1 = new List<ACourcesCertImagehr>();
            List<ACourcesCertImage> ACourcesCertImage1 = new List<ACourcesCertImage>();


            // ACourcesName1 code
            ACourcesName1 = (from product in _context.ACourcesNames
                              
                              select product).ToList();

            ACourcesName1.Insert(0, new ACourcesName{ CourcesId=0, CourcesName="select" }) ;
            ViewBag.ACourcesName1 = ACourcesName1;
            //ACourcesTrainingMethod1 code
            ACourcesTrainingMethod1 = (from product in _context.ACourcesTrainingMethods

                             select product).ToList();

            ACourcesTrainingMethod1.Insert(0, new ACourcesTrainingMethod { CourcesIdTraining = 0, CourcesNameTraining = "select" });
            ViewBag.ACourcesTrainingMethod1 = ACourcesTrainingMethod1;
            // ACourcesType code
            ACourcesType1 = (from product in _context.ACourcesTypes

                             select product).ToList();

            ACourcesType1.Insert(0, new ACourcesType { CourcesIdType = 0, CourcesTypeName = "select" });
            ViewBag.ACourcesType1 = ACourcesType1;


            // Cemp1 code
            Cemp1 = (from product in _context.Cemps

                             select product).ToList();

            Cemp1.Insert(0, new Cemp { Cempid = "0", Cempname = "select" });
            ViewBag.Cemp1 = Cemp1;
            //ACourcesEstimate1 code
            ACourcesEstimate1 = (from product in _context.ACourcesEstimates

                     select product).ToList();

            ACourcesEstimate1.Insert(0, new ACourcesEstimate { CourcesIdEstimate = 0, CourcesNameEstimate = "select" });
            ViewBag.ACourcesEstimate1 = ACourcesEstimate1;

            // ACourcesDeptout1 code 
            ACourcesDeptout1 = (from product in _context.ACourcesDeptouts

                             select product).ToList();

            ACourcesDeptout1.Insert(0, new ACourcesDeptout { CourcesIdDeptout = 0, CourcesNameDeptout = "select" });
            ViewBag.ACourcesDeptout1 = ACourcesDeptout1;
            //ACourcesDeptin1 code 

            ACourcesDeptin1 = (from product in _context.ACourcesDeptins

                             select product).ToList();

            ACourcesDeptin1.Insert(0, new ACourcesDeptin { CourcesIdDeptin = 0, CourcesNameDeptin = "select" });
            ViewBag.ACourcesDeptin1 = ACourcesDeptin1;
            // ACourcesCertImagehr1 code  
            ACourcesCertImagehr1 = (from product in _context.ACourcesCertImagehrs

                             select product).ToList();

            ACourcesCertImagehr1.Insert(0, new ACourcesCertImagehr { CourcesIdImagehr = 0, CourcesIdmaster = 0 });
            ViewBag.ACourcesCertImagehr1 = ACourcesCertImagehr1;

            //ACourcesCertImage1 code

            ACourcesCertImage1 = (from product in _context.ACourcesCertImages

                             select product).ToList();

            ACourcesCertImage1.Insert(0, new ACourcesCertImage { CourcesIdImagecert = 0, CourcesIdmaster = 0 });
            ViewBag.ACourcesCertImage1 = ACourcesCertImage1;

            //
             */
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName");
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdmaster");
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");


            return View();
        }

        // POST: ACourcesMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create11([Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid,Filecer,Filehr")] ACourcesMaster aCourcesMaster)
        {
            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath = Path.Combine(uploads, aCourcesMaster.Filecer.FileName);
                aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
                //
                string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                //
                ACourcesMaster aCourcesMasteritems = new ACourcesMaster
                {
                    CourcesId = aCourcesMaster.CourcesId,
                    CourcesIdType = aCourcesMaster.CourcesIdType,
                    CourcesIdDeptin = aCourcesMaster.CourcesIdDeptin,
                    CourcesIdTraining = aCourcesMaster.CourcesIdTraining,
                    CourcesIdDeptout = aCourcesMaster.CourcesIdDeptout,
                    CourcesIdEstimate = aCourcesMaster.CourcesIdEstimate,
                    CourcesIdImagecert = aCourcesMaster.Filecer.FileName,
                    CourcesIdImagehr = aCourcesMaster.Filehr.FileName,
                    CourcesStartDate = aCourcesMaster.CourcesStartDate,
                    CourcesEndDate = aCourcesMaster.CourcesEndDate,
                    CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays),
                    CourcesPassRate = aCourcesMaster.CourcesPassRate,
                    Cempid = "0"


                };
                MasterRequestTypeId MasterRequestTypeIds = new MasterRequestTypeId
                {
                    COURCES_IDMASTER = _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestType = 0

                };
                MasterDetails MasterDetailss = new MasterDetails
                {
                    COURCES_IDMASTER = _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestFrom = "0",
                    MasterRequestTo = "0",
                    MasterRequestTypeSatus = 0,
                    MasterRequestNotes = ""

                };
                _context.Add(aCourcesMasteritems);
                _context.Add(MasterRequestTypeIds);
                _context.Add(MasterDetailss);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Search11", "ACourcesMasters", new { area = "" });
            }
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");

            return View(aCourcesMaster);
        }

        // GET: ACourcesMasters/Edit/5
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        //[Authorize(Roles = "Admin")]
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
            String cid = _protector.Unprotect(id);
            if (cid == null)
            {
                return NotFound();
            }
           

            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(Convert.ToInt32(cid));
            if (aCourcesMaster == null)
            {
                return NotFound();
            }


            //ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            //ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ACourcesMaster aCourcesMaster)
        {
            //String cid = _protector.Unprotect(EncryptedIdd);
            //int id = Convert.ToInt32(cid);
            //if (id != aCourcesMaster.CourcesIdmaster)
            //{
            //    return NotFound();
            //}
            if (aCourcesMaster.CourcesIdType == 0 || aCourcesMaster.CourcesIdDeptout == 0 || aCourcesMaster.CourcesIdTraining == 0)
            {
                ViewBag.ErrorMessage3 = "يرجي أخيار نوع ومكان وجهة الدورة من القائمة بشكل صحيح ولا يتم اختيار العنصر -تحديد-!!   ";
                return View(aCourcesMaster);

            }
            if (aCourcesMaster.Filecer != null)
            {
                 extension = Path.GetExtension(aCourcesMaster.Filecer.FileName);
            }
            if (aCourcesMaster.Filehr != null)
            {
                extension2 = Path.GetExtension(aCourcesMaster.Filehr.FileName);
            }
          
           
            var objuser1 = _context.Cemps.Where(b => b.Cempid == aCourcesMaster.Cempid).FirstOrDefault();
            //var coursesforuser = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesStartDate == aCourcesMaster.CourcesStartDate).FirstOrDefault();
            //if (coursesforuser != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ البداية ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser1 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesEndDate == aCourcesMaster.CourcesEndDate).FirstOrDefault();
            //if (coursesforuser1 != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ النهاية ";
            //    return View(aCourcesMaster);
            //}



            //var coursesforuser11 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") /*&& b.CourcesId == aCourcesMaster.CourcesId*/ && (b.CourcesIdType == 1 || b.CourcesIdType == 2 || b.CourcesIdType == 4) && (b.CourcesStartDate <= aCourcesMaster.CourcesStartDate && aCourcesMaster.CourcesStartDate <= b.CourcesEndDate)).ToList();
            //if (coursesforuser11.Count != 0)
            //{
            //    ViewBag.ErrorMessage3 = "لا يمكن ارشفة الدورة لوجود الموظف بدورة اخري بنفس التاريخ   ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
            //var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
            //var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
            //var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
            //var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
            //var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
            //var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
            //if (coursesforuser20count1446 > 20 || coursesforuser20count1445 > 20 || coursesforuser20count1444 > 20 || coursesforuser20count1443 > 20 || coursesforuser20count1442 > 20 || coursesforuser20count1441 > 20 || coursesforuser20count1440 > 20)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
            //var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
            //var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
            //var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
            //var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
            //var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
            //var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
            //if (coursesforuser2count1446 > 2 || coursesforuser2count1445 > 2 || coursesforuser2count1444 > 2 || coursesforuser2count1443 > 2 || coursesforuser2count1442 > 2 || coursesforuser2count1441 > 2 || coursesforuser2count1440 > 2)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}

            if (aCourcesMaster.CourcesIdType == 3)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
                var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
                var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
                var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
                var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
                var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
                var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).Count();
                if (coursesforuser20count1446 > 20 || coursesforuser20count1445 > 20 || coursesforuser20count1444 > 20 || coursesforuser20count1443 > 20 || coursesforuser20count1442 > 20 || coursesforuser20count1441 > 20 || coursesforuser20count1440 > 20 || coursesforuser20count1439 > 20 || coursesforuser20count1438 > 20)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if (yy1446.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 20 || yy1445.ToList().Count >= 20 || yy1444.ToList().Count >= 20 || yy1443.ToList().Count >= 20 || yy1442.ToList().Count >= 20 || yy1441.ToList().Count >= 20 || yy1440.ToList().Count >= 20 || yy1439.ToList().Count >= 20 || yy1438.ToList().Count >= 20)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }
            if (aCourcesMaster.CourcesIdType == 1)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();

                var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
                var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
                var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
                var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
                var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
                var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
                var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1439)).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1438)).Count();
                if (coursesforuser2count1446 > 2 || coursesforuser2count1445 > 2 || coursesforuser2count1444 > 2 || coursesforuser2count1443 > 2 || coursesforuser2count1442 > 2 || coursesforuser2count1441 > 2 || coursesforuser2count1440 > 2 || coursesforuser20count1439 > 2 || coursesforuser20count1438 > 2)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if (yy1446.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 2 || yy1445.ToList().Count >= 2 || yy1444.ToList().Count >= 2 || yy1443.ToList().Count >= 2 || yy1442.ToList().Count >= 2 || yy1441.ToList().Count >= 2 || yy1440.ToList().Count >= 2 || yy1439.ToList().Count >= 2 || yy1438.ToList().Count >= 2)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }
            string x = "", y = "", file1 = "", file2 = "";

            //if (aCourcesMaster.Filecer != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
            //{
            //    file1 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filecer.FileName;
            //    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
            //    string fullPath = Path.Combine(uploads, file1);
            //    aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "يرجي رفع شهادة الدورة (jpeg, jpg, png, gif, jfif,pdf)!";
            //    return View(aCourcesMaster);
            //    //ModelState.AddModelError("uploadError", "يرجي رفع شهادة الدورة");
            //    //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع شهادة الدورة!');</script>");
            //}

            //
            //if (aCourcesMaster.Filehr != null && (extension2 == ".jpeg" || extension2 == ".jpg" || extension2 == ".png" || extension2 == ".gif" || extension2 == ".jfif" || extension == ".pdf"))
            //{
            //    file2 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filehr.FileName;
            //    string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
            //    string fullPath2 = Path.Combine(uploads2, file2);
            //    aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
            //    x = file2;
            //}
            //else
            //{
            //    y = "";
            //}
            var ac = _context.ACourcesMasters.Find(aCourcesMaster.CourcesIdmaster);
            if (ac == null)
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{
                try
                {
                    //string uploads1 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    //string fullPath1 = Path.Combine(uploads1, aCourcesMaster.Filecer.FileName);
                    //aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath1, FileMode.Create));
                    ////
                    //string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                    //string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                    //aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                    //aCourcesMaster.CourcesIdImagecert = aCourcesMaster.Filecer.FileName;
                    //aCourcesMaster.CourcesIdImagehr = aCourcesMaster.Filehr.FileName;
                    ac.CourcesIdmaster = aCourcesMaster.CourcesIdmaster;
                    ac.CourcesId = aCourcesMaster.CourcesId;
                    ac.CourcesIdType = aCourcesMaster.CourcesIdType;
                   /* ac.CourcesIdDeptin = Convert.ToInt32(HttpContext.Session.GetString("empdepid"))*/ /*aCourcesMaster.CourcesIdDeptin*/;
                    ac.CourcesIdTraining = aCourcesMaster.CourcesIdTraining;
                    ac.CourcesIdDeptout = aCourcesMaster.CourcesIdDeptout;
                    ac.CourcesIdEstimate = aCourcesMaster.CourcesIdEstimate;
                    //ac.CourcesIdImagecert = file1;
                    //ac.CourcesIdImagehr = x == x ? x : y;
                    if (aCourcesMaster.CourcesStartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                    {
                    ac.CourcesStartDate = Convert.ToDateTime(aCourcesMaster.CourcesStartDateh);
                    //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;

                    }
                    else
                {
                    ac.CourcesStartDate = Convert.ToDateTime(aCourcesMaster.CourcesStartDateh);
                }

                if (aCourcesMaster.CourcesEndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);

                }
                else {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);
                }
                ac.CourcesNumberofdays = Convert.ToInt32((ac.CourcesEndDate - ac.CourcesStartDate).TotalDays) + 1;

                //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;
                //ac.CourcesPassRate = aCourcesMaster.CourcesPassRate;
                ac.COURCES_EXCUTION = aCourcesMaster.COURCES_EXCUTION;
                    //ac.Cempid = HttpContext.Session.GetString("empid");
                    //
                 
                                                    //int z=0,zz=0;
                    if (objuser1.CEMPLASTUPGRADEHIJRA > objuser1.CEMPHIRINGDATEHIJRA)
                    {
                        if (ac.CourcesEndDate < ac.CourcesStartDate)
                        {
                            ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                            return View(aCourcesMaster);
                        }
                        if (ac.CourcesEndDate > objuser1.CEMPLASTUPGRADEHIJRA)
                        {
                            //// z = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.CEMPLASTUPGRADEHIJRA);
                            ////zz = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.Cemplastupgrade);
                            //if (aCourcesMaster.CourcesPassRate != null)
                            //{
                            //    _context.Add(newcourcename);
                            //    await _context.SaveChangesAsync();
                            //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                            //}
                            //_context.Add(aCourcesMasteritems);
                            //_context.Add(MasterRequestTypeIds);
                            //_context.Add(MasterDetailss);
                            //await _context.SaveChangesAsync();
                            _context.Update(ac);//
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            ViewBag.ErrorMessage1 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ آخر ترقية  ";
                            return View(aCourcesMaster);
                            //ViewBag.Message = "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!";
                            //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!');</script>");
                            //ModelState.AddModelError("CourcesStartDate", "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!");


                        }

                    }
                    if (objuser1.CEMPLASTUPGRADEHIJRA <= objuser1.CEMPHIRINGDATEHIJRA)
                    {
                    if (ac.CourcesEndDate < ac.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (ac.CourcesEndDate > objuser1.CEMPHIRINGDATEHIJRA)
                        {
                            //if (aCourcesMaster.CourcesPassRate != null)
                            //{
                            //    _context.Add(newcourcename);
                            //    await _context.SaveChangesAsync();
                            //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                            //}
                            //_context.Add(aCourcesMasteritems);
                            //_context.Add(MasterRequestTypeIds);
                            //_context.Add(MasterDetailss);
                            //await _context.SaveChangesAsync();
                            _context.Update(ac);//
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            ViewBag.ErrorMessage2 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ التعين ";
                            return View(aCourcesMaster);
                            // ViewBag.Message = "تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!";
                            //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!');</script>");
                        }

                    }


                    //return RedirectToAction(nameof(Index));
                   
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesMasterExists(aCourcesMaster.CourcesIdmaster))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                //}


              
            }
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            //logs
            ACourcesLogs aa = new ACourcesLogs
            {
                requestid = Convert.ToString(aCourcesMaster.CourcesIdmaster),
                userr = HttpContext.Session.GetString("empid"),
                tt = DateTime.Now
            };

            _context.ACourcesLogs.Add(aa);//
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "ViewModelMasterwithother", new { area = "" });
            return View(aCourcesMaster);
        }

        // edit for user 
        // GET: ACourcesMasters/Edit/5
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit11(string id)
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
            String cid = _protector.Unprotect(id);
            if (cid == null)
            {
                return NotFound();
            }


            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(Convert.ToInt32(cid));
            if (aCourcesMaster == null)
            {
                return NotFound();
            }


            //ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            //ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit11(ACourcesMaster aCourcesMaster)
        {
            //String cid = _protector.Unprotect(EncryptedIdd);
            //int id = Convert.ToInt32(cid);
            //if (id != aCourcesMaster.CourcesIdmaster)
            //{
            //    return NotFound();
            //}
            if (aCourcesMaster.CourcesIdType == 0 || aCourcesMaster.CourcesIdDeptout == 0 || aCourcesMaster.CourcesIdTraining == 0)
            {
                ViewBag.ErrorMessage3 = "يرجي أخيار نوع ومكان وجهة الدورة من القائمة بشكل صحيح ولا يتم اختيار العنصر -تحديد-!!   ";
                return View(aCourcesMaster);

            }
            if (aCourcesMaster.Filecer != null)
            {
                extension = Path.GetExtension(aCourcesMaster.Filecer.FileName);
            }
            if (aCourcesMaster.Filehr != null)
            {
                extension2 = Path.GetExtension(aCourcesMaster.Filehr.FileName);
            }


            var objuser1 = _context.Cemps.Where(b => b.Cempid == aCourcesMaster.Cempid).FirstOrDefault();
            //var coursesforuser = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesStartDate == aCourcesMaster.CourcesStartDate).FirstOrDefault();
            //if (coursesforuser != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ البداية ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser1 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesEndDate == aCourcesMaster.CourcesEndDate).FirstOrDefault();
            //if (coursesforuser1 != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ النهاية ";
            //    return View(aCourcesMaster);
            //}



            //var coursesforuser11 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") /*&& b.CourcesId == aCourcesMaster.CourcesId*/ && (b.CourcesIdType == 1 || b.CourcesIdType == 2 || b.CourcesIdType == 4) && (b.CourcesStartDate <= aCourcesMaster.CourcesStartDate && aCourcesMaster.CourcesStartDate <= b.CourcesEndDate)).ToList();
            //if (coursesforuser11.Count != 0)
            //{
            //    ViewBag.ErrorMessage3 = "لا يمكن ارشفة الدورة لوجود الموظف بدورة اخري بنفس التاريخ   ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
            //var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
            //var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
            //var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
            //var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
            //var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
            //var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
            //if (coursesforuser20count1446 > 20 || coursesforuser20count1445 > 20 || coursesforuser20count1444 > 20 || coursesforuser20count1443 > 20 || coursesforuser20count1442 > 20 || coursesforuser20count1441 > 20 || coursesforuser20count1440 > 20)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
            //var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
            //var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
            //var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
            //var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
            //var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
            //var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
            //if (coursesforuser2count1446 > 2 || coursesforuser2count1445 > 2 || coursesforuser2count1444 > 2 || coursesforuser2count1443 > 2 || coursesforuser2count1442 > 2 || coursesforuser2count1441 > 2 || coursesforuser2count1440 > 2)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}

           

            string x = "", y = "", file1 = "", file2 = "";

            if (aCourcesMaster.Filecer != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
            {
                file1 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filecer.FileName;
                string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath = Path.Combine(uploads, file1);
                aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                ViewBag.ErrorMessage = "يرجي رفع شهادة الدورة (jpeg, jpg, png, gif, jfif,pdf)!";
                return View(aCourcesMaster);
                //ModelState.AddModelError("uploadError", "يرجي رفع شهادة الدورة");
                //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع شهادة الدورة!');</script>");
            }


            if (aCourcesMaster.Filehr != null && (extension2 == ".jpeg" || extension2 == ".jpg" || extension2 == ".png" || extension2 == ".gif" || extension2 == ".jfif" || extension == ".pdf"))
            {
                file2 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filehr.FileName;
                string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                string fullPath2 = Path.Combine(uploads2, file2);
                aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                x = file2;
            }
            else
            {
                y = "";
            }
            var ac = _context.ACourcesMasters.Find(aCourcesMaster.CourcesIdmaster);
            if (ac == null)
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{
            try
            {
                //string uploads1 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                //string fullPath1 = Path.Combine(uploads1, aCourcesMaster.Filecer.FileName);
                //aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath1, FileMode.Create));
                ////
                //string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                //string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                //aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                //aCourcesMaster.CourcesIdImagecert = aCourcesMaster.Filecer.FileName;
                //aCourcesMaster.CourcesIdImagehr = aCourcesMaster.Filehr.FileName;
                ac.CourcesIdmaster = aCourcesMaster.CourcesIdmaster;
                ac.CourcesId = aCourcesMaster.CourcesId;
                ac.CourcesIdType = aCourcesMaster.CourcesIdType;
                /* ac.CourcesIdDeptin = Convert.ToInt32(HttpContext.Session.GetString("empdepid"))*/ /*aCourcesMaster.CourcesIdDeptin*/
                ;
                ac.CourcesIdTraining = aCourcesMaster.CourcesIdTraining;
                ac.CourcesIdDeptout = aCourcesMaster.CourcesIdDeptout;
                ac.CourcesIdEstimate = aCourcesMaster.CourcesIdEstimate;
                ac.CourcesIdImagecert = file1;
                ac.CourcesIdImagehr = x == x ? x : y;
                if (aCourcesMaster.CourcesStartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    ac.CourcesStartDate =Convert.ToDateTime( aCourcesMaster.CourcesStartDateh);
                    //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;

                }
                else
                {
                    ac.CourcesStartDate = Convert.ToDateTime(aCourcesMaster.CourcesStartDateh);
                }

                if (aCourcesMaster.CourcesEndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);

                }
                else
                {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);
                }
                ac.CourcesNumberofdays = Convert.ToInt32((ac.CourcesEndDate - ac.CourcesStartDate).TotalDays) + 1;

                //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;
                //ac.CourcesPassRate = aCourcesMaster.CourcesPassRate;
                ac.COURCES_EXCUTION = aCourcesMaster.COURCES_EXCUTION;
                //ac.Cempid = HttpContext.Session.GetString("empid");
                //

                //int z=0,zz=0;
                if (objuser1.CEMPLASTUPGRADEHIJRA > objuser1.CEMPHIRINGDATEHIJRA)
                {
                    if (ac.CourcesEndDate < ac.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (ac.CourcesEndDate > objuser1.CEMPLASTUPGRADEHIJRA)
                    {
                        //// z = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.CEMPLASTUPGRADEHIJRA);
                        ////zz = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.Cemplastupgrade);
                        //if (aCourcesMaster.CourcesPassRate != null)
                        //{
                        //    _context.Add(newcourcename);
                        //    await _context.SaveChangesAsync();
                        //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                        //}
                        //_context.Add(aCourcesMasteritems);
                        //_context.Add(MasterRequestTypeIds);
                        //_context.Add(MasterDetailss);
                        //await _context.SaveChangesAsync();
                        _context.Update(ac);//
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage1 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ آخر ترقية  ";
                        return View(aCourcesMaster);
                        //ViewBag.Message = "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!');</script>");
                        //ModelState.AddModelError("CourcesStartDate", "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!");


                    }

                }
                if (objuser1.CEMPLASTUPGRADEHIJRA <= objuser1.CEMPHIRINGDATEHIJRA)
                {
                    if (ac.CourcesEndDate < ac.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (ac.CourcesEndDate > objuser1.CEMPHIRINGDATEHIJRA)
                    {
                        //if (aCourcesMaster.CourcesPassRate != null)
                        //{
                        //    _context.Add(newcourcename);
                        //    await _context.SaveChangesAsync();
                        //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                        //}
                        //_context.Add(aCourcesMasteritems);
                        //_context.Add(MasterRequestTypeIds);
                        //_context.Add(MasterDetailss);
                        //await _context.SaveChangesAsync();
                        _context.Update(ac);//
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage2 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ التعين ";
                        return View(aCourcesMaster);
                        // ViewBag.Message = "تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!');</script>");
                    }

                }


                //return RedirectToAction(nameof(Index));


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACourcesMasterExists(aCourcesMaster.CourcesIdmaster))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                //}



            }
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            //logs
            ACourcesLogs aa = new ACourcesLogs
            {
                requestid = Convert.ToString(aCourcesMaster.CourcesIdmaster),
                userr = HttpContext.Session.GetString("empid"),
                tt = DateTime.Now
            };

            _context.ACourcesLogs.Add(aa);//
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            return RedirectToAction("search", "ACourcesMasters", new { area = "" });
            return View(aCourcesMaster);
        }



        // edit for user 
        // GET: ACourcesMasters/Edit/5
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit111(string id)
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
            String cid = _protector.Unprotect(id);
            if (cid == null)
            {
                return NotFound();
            }


            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(Convert.ToInt32(cid));
            if (aCourcesMaster == null)
            {
                return NotFound();
            }


            //ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            //ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit111(ACourcesMaster aCourcesMaster)
        {
            //String cid = _protector.Unprotect(EncryptedIdd);
            //int id = Convert.ToInt32(cid);
            //if (id != aCourcesMaster.CourcesIdmaster)
            //{
            //    return NotFound();
            //}
            if (aCourcesMaster.CourcesIdType == 0 || aCourcesMaster.CourcesIdDeptout == 0 || aCourcesMaster.CourcesIdTraining == 0)
            {
                ViewBag.ErrorMessage3 = "يرجي أخيار نوع ومكان وجهة الدورة من القائمة بشكل صحيح ولا يتم اختيار العنصر -تحديد-!!   ";
                return View(aCourcesMaster);

            }
            if (aCourcesMaster.Filecer != null)
            {
                extension = Path.GetExtension(aCourcesMaster.Filecer.FileName);
            }
            if (aCourcesMaster.Filehr != null)
            {
                extension2 = Path.GetExtension(aCourcesMaster.Filehr.FileName);
            }


            var objuser1 = _context.Cemps.Where(b => b.Cempid == aCourcesMaster.Cempid).FirstOrDefault();
            //var coursesforuser = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesStartDate == aCourcesMaster.CourcesStartDate).FirstOrDefault();
            //if (coursesforuser != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ البداية ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser1 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesId == aCourcesMaster.CourcesId && b.CourcesEndDate == aCourcesMaster.CourcesEndDate).FirstOrDefault();
            //if (coursesforuser1 != null)
            //{
            //    ViewBag.ErrorMessage3 = "تم تسجيل الدورة سابقا بنفس تاريخ النهاية ";
            //    return View(aCourcesMaster);
            //}



            //var coursesforuser11 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") /*&& b.CourcesId == aCourcesMaster.CourcesId*/ && (b.CourcesIdType == 1 || b.CourcesIdType == 2 || b.CourcesIdType == 4) && (b.CourcesStartDate <= aCourcesMaster.CourcesStartDate && aCourcesMaster.CourcesStartDate <= b.CourcesEndDate)).ToList();
            //if (coursesforuser11.Count != 0)
            //{
            //    ViewBag.ErrorMessage3 = "لا يمكن ارشفة الدورة لوجود الموظف بدورة اخري بنفس التاريخ   ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
            //var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
            //var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
            //var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
            //var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
            //var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
            //var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
            //if (coursesforuser20count1446 > 20 || coursesforuser20count1445 > 20 || coursesforuser20count1444 > 20 || coursesforuser20count1443 > 20 || coursesforuser20count1442 > 20 || coursesforuser20count1441 > 20 || coursesforuser20count1440 > 20)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}
            //var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
            //var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
            //var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
            //var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
            //var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
            //var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
            //var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == HttpContext.Session.GetString("empid") && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
            //if (coursesforuser2count1446 > 2 || coursesforuser2count1445 > 2 || coursesforuser2count1444 > 2 || coursesforuser2count1443 > 2 || coursesforuser2count1442 > 2 || coursesforuser2count1441 > 2 || coursesforuser2count1440 > 2)
            //{
            //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
            //    return View(aCourcesMaster);
            //}

            if (aCourcesMaster.CourcesIdType == 3)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                var coursesforuser20count1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1446).Count();
                var coursesforuser20count1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1445).Count();
                var coursesforuser20count1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1444).Count();
                var coursesforuser20count1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1443).Count();
                var coursesforuser20count1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1442).Count();
                var coursesforuser20count1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1441).Count();
                var coursesforuser20count1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1440).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1439).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 3 && b.CourcesEndDate.Year == 1438).Count();
                if (coursesforuser20count1446 > 20 || coursesforuser20count1445 > 20 || coursesforuser20count1444 > 20 || coursesforuser20count1443 > 20 || coursesforuser20count1442 > 20 || coursesforuser20count1441 > 20 || coursesforuser20count1440 > 20 || coursesforuser20count1439 > 20 || coursesforuser20count1438 > 20)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if (yy1446.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 20)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 20 || yy1445.ToList().Count >= 20 || yy1444.ToList().Count >= 20 || yy1443.ToList().Count >= 20 || yy1442.ToList().Count >= 20 || yy1441.ToList().Count >= 20 || yy1440.ToList().Count >= 20 || yy1439.ToList().Count >= 20 || yy1438.ToList().Count >= 20)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 20 دورة اثرائية بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }
            if (aCourcesMaster.CourcesIdType == 1)
            {
                List<ACourcesMaster> ACourcesMasters1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1446).ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                var yy1446 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1446 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1445).ToList();
                var yy1445 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1445 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1444).ToList();
                var yy1444 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1444 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1443).ToList();
                var yy1443 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1443 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1442).ToList();
                var yy1442 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1442 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1441).ToList();
                var yy1441 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1441 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1440).ToList();
                var yy1440 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1440 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1439).ToList();
                var yy1439 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1439 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();
                List<ACourcesMaster> ACourcesMasters1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && b.CourcesEndDate.Year == 1438).ToList();
                var yy1438 = from xx in MasterRequestTypeIds
                             join n in ACourcesMasters1438 on xx.COURCES_IDMASTER equals n.CourcesIdmaster into table88
                             from n in table88.ToList().Distinct()
                             where (xx.MasterRequestType != 2)
                             select (xx.COURCES_IDMASTER).ToString();

                var coursesforuser2count1446 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1446)).Count();
                var coursesforuser2count1445 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1445)).Count();
                var coursesforuser2count1444 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1444)).Count();
                var coursesforuser2count1443 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1443)).Count();
                var coursesforuser2count1442 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1442)).Count();
                var coursesforuser2count1441 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1441)).Count();
                var coursesforuser2count1440 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1440)).Count();
                var coursesforuser20count1439 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1439)).Count();
                var coursesforuser20count1438 = _context.ACourcesMasters.Where(b => b.Cempid == aCourcesMaster.Cempid && b.CourcesIdType == 1 && (b.CourcesEndDate.Year == 1438)).Count();
                if (coursesforuser2count1446 > 2 || coursesforuser2count1445 > 2 || coursesforuser2count1444 > 2 || coursesforuser2count1443 > 2 || coursesforuser2count1442 > 2 || coursesforuser2count1441 > 2 || coursesforuser2count1440 > 2 || coursesforuser20count1439 > 2 || coursesforuser20count1438 > 2)
                {
                    if (aCourcesMaster.CourcesStartDate.Year == 1446)
                    {
                        if (yy1446.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1445)
                    {
                        if (yy1445.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1444)
                    {
                        if (yy1444.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1443)
                    {
                        if (yy1443.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1442)
                    {
                        if (yy1442.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1441)
                    {
                        if (yy1441.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1440)
                    {
                        if (yy1440.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1439)
                    {
                        if (yy1439.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    if (aCourcesMaster.CourcesStartDate.Year == 1438)
                    {
                        if (yy1438.ToList().Count >= 2)
                        {
                            ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                            return View(aCourcesMaster);
                        }

                    }
                    //if (yy1446.ToList().Count >= 2 || yy1445.ToList().Count >= 2 || yy1444.ToList().Count >= 2 || yy1443.ToList().Count >= 2 || yy1442.ToList().Count >= 2 || yy1441.ToList().Count >= 2 || yy1440.ToList().Count >= 2 || yy1439.ToList().Count >= 2 || yy1438.ToList().Count >= 2)
                    //{
                    //    ViewBag.ErrorMessage3 = "لايمكن تسجيل اكثر من 2  دورة بدون اختبار  بالعام الواحد  ";
                    //    return View(aCourcesMaster);
                    //}
                }
            }

            string x = "", y = "", file1 = "", file2 = "";

            //if (aCourcesMaster.Filecer != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
            //{
            //    file1 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filecer.FileName;
            //    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
            //    string fullPath = Path.Combine(uploads, file1);
            //    aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "يرجي رفع شهادة الدورة (jpeg, jpg, png, gif, jfif,pdf)!";
            //    return View(aCourcesMaster);
            //    //ModelState.AddModelError("uploadError", "يرجي رفع شهادة الدورة");
            //    //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع شهادة الدورة!');</script>");
            //}

            //
            //if (aCourcesMaster.Filehr != null && (extension2 == ".jpeg" || extension2 == ".jpg" || extension2 == ".png" || extension2 == ".gif" || extension2 == ".jfif" || extension == ".pdf"))
            //{
            //    file2 = DateTime.Now.ToString("ddMMMyyhhmmsstt") + aCourcesMaster.Filehr.FileName;
            //    string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
            //    string fullPath2 = Path.Combine(uploads2, file2);
            //    aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
            //    x = file2;
            //}
            //else
            //{
            //    y = "";
            //}
            var ac = _context.ACourcesMasters.Find(aCourcesMaster.CourcesIdmaster);
            if (ac == null)
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{
            try
            {
                //string uploads1 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                //string fullPath1 = Path.Combine(uploads1, aCourcesMaster.Filecer.FileName);
                //aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath1, FileMode.Create));
                ////
                //string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfoliohr");
                //string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                //aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                //aCourcesMaster.CourcesIdImagecert = aCourcesMaster.Filecer.FileName;
                //aCourcesMaster.CourcesIdImagehr = aCourcesMaster.Filehr.FileName;
                ac.CourcesIdmaster = aCourcesMaster.CourcesIdmaster;
                ac.CourcesId = aCourcesMaster.CourcesId;
                ac.CourcesIdType = aCourcesMaster.CourcesIdType;
                /* ac.CourcesIdDeptin = Convert.ToInt32(HttpContext.Session.GetString("empdepid"))*/ /*aCourcesMaster.CourcesIdDeptin*/
                ;
                ac.CourcesIdTraining = aCourcesMaster.CourcesIdTraining;
                ac.CourcesIdDeptout = aCourcesMaster.CourcesIdDeptout;
                ac.CourcesIdEstimate = aCourcesMaster.CourcesIdEstimate;
                //ac.CourcesIdImagecert = file1;
                //ac.CourcesIdImagehr = x == x ? x : y;
                if (aCourcesMaster.CourcesStartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    ac.CourcesStartDate = Convert.ToDateTime(aCourcesMaster.CourcesStartDateh);
                    //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;

                }
                else
                {
                    ac.CourcesStartDate = Convert.ToDateTime(aCourcesMaster.CourcesStartDateh);
                }

                if (aCourcesMaster.CourcesEndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);

                }
                else
                {
                    ac.CourcesEndDate = Convert.ToDateTime(aCourcesMaster.CourceendDateh);
                }
                ac.CourcesNumberofdays = Convert.ToInt32((ac.CourcesEndDate - ac.CourcesStartDate).TotalDays) + 1;

                //ac.CourcesNumberofdays = Convert.ToInt32((aCourcesMaster.CourcesEndDate - aCourcesMaster.CourcesStartDate).TotalDays) + 1;
                //ac.CourcesPassRate = aCourcesMaster.CourcesPassRate;
                ac.COURCES_EXCUTION = aCourcesMaster.COURCES_EXCUTION;
                //ac.Cempid = HttpContext.Session.GetString("empid");
                //

                //int z=0,zz=0;
                if (objuser1.CEMPLASTUPGRADEHIJRA > objuser1.CEMPHIRINGDATEHIJRA)
                {
                    if (ac.CourcesEndDate < ac.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (ac.CourcesEndDate > objuser1.CEMPLASTUPGRADEHIJRA)
                    {
                        //// z = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.CEMPLASTUPGRADEHIJRA);
                        ////zz = aCourcesMasteritems.CourcesStartDate.CompareTo(objuser1.Cemplastupgrade);
                        //if (aCourcesMaster.CourcesPassRate != null)
                        //{
                        //    _context.Add(newcourcename);
                        //    await _context.SaveChangesAsync();
                        //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                        //}
                        //_context.Add(aCourcesMasteritems);
                        //_context.Add(MasterRequestTypeIds);
                        //_context.Add(MasterDetailss);
                        //await _context.SaveChangesAsync();
                        _context.Update(ac);//
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage1 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ آخر ترقية  ";
                        return View(aCourcesMaster);
                        //ViewBag.Message = "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!');</script>");
                        //ModelState.AddModelError("CourcesStartDate", "تاريخ الدورة اقل من تاريخ اخر ترقية ولن يتم الحفظ!");


                    }

                }
                if (objuser1.CEMPLASTUPGRADEHIJRA <= objuser1.CEMPHIRINGDATEHIJRA)
                {
                    if (ac.CourcesEndDate < ac.CourcesStartDate)
                    {
                        ViewBag.ErrorMessage1 = "تاريخ نهاية الدورة اقل من تاريخ بداية الدورة   ";
                        return View(aCourcesMaster);
                    }
                    if (ac.CourcesEndDate > objuser1.CEMPHIRINGDATEHIJRA)
                    {
                        //if (aCourcesMaster.CourcesPassRate != null)
                        //{
                        //    _context.Add(newcourcename);
                        //    await _context.SaveChangesAsync();
                        //    aCourcesMasteritems.CourcesId = _context.ACourcesNames.Max(u => u.CourcesId);

                        //}
                        //_context.Add(aCourcesMasteritems);
                        //_context.Add(MasterRequestTypeIds);
                        //_context.Add(MasterDetailss);
                        //await _context.SaveChangesAsync();
                        _context.Update(ac);//
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.ErrorMessage2 = "لا يمكن تسجيل الدورة التدريبية لكون تاريخ الحصول عليها  قبل تاريخ التعين ";
                        return View(aCourcesMaster);
                        // ViewBag.Message = "تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!";
                        //return Content("<script language='javascript' type='text/javascript'>alert('تاريخ الدورة اقل من تاريخ التعيين بالدولة  ولن يتم الحفظ!');</script>");
                    }

                }


                //return RedirectToAction(nameof(Index));


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACourcesMasterExists(aCourcesMaster.CourcesIdmaster))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                //}



            }
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            //logs
            ACourcesLogs aa = new ACourcesLogs
            {
                requestid = Convert.ToString(aCourcesMaster.CourcesIdmaster),
                userr = HttpContext.Session.GetString("empid"),
                tt = DateTime.Now
            };

            _context.ACourcesLogs.Add(aa);//
            await _context.SaveChangesAsync();

            var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
            var empapproval1 = _context.Cemps.Where(h => h.Cempid == objuser1.Cempid).FirstOrDefault();
            var emprequestor = _context.Cemps.Where(h => h.Cempid == objuser1.Cempid).FirstOrDefault();


            WelcomeRequest request3 = new WelcomeRequest();
            request3.UserName = emprequestor.CEMPNAME;
            request3.header = "أرشفة الدورات التدريبة  ";
            request3.Details = "تم تعديل بيانات الدورة بعد اعتمادها  ,طلب رقم :" + aCourcesMaster.CourcesIdmaster + " بواسطة   : " + empapproval2.CEMPNAME;
            request3.ToEmail = emprequestor.mail;
            try
            {
                //await mailService.SendEmailAsync(m);
                await mailService.SendWelcomeEmailAsync(request3);
            }
            catch (Exception ex)
            {
                loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة أرشفة الدورات التدريبة بعد الاعتماد    " + emprequestor.Cempid + "اعتماد أرشفة الدورات التدريبة " + ex.Message);
            }


            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ApprovelAllCourses", "ACourcesMasters", new { area = "" });
            return View(aCourcesMaster);
        }

        // edit for user 
        // GET: ACourcesMasters/Edit/5
        [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit1110(string id)
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
            String cid = _protector.Unprotect(id);
            if (cid == null)
            {
                return NotFound();
            }


            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(Convert.ToInt32(cid));
            if (aCourcesMaster == null)
            {
                return NotFound();
            }


            //ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            //ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName", aCourcesMaster.CourcesId);
            ViewData["CourcesIdImagecert"] = new SelectList(_context.ACourcesCertImages, "CourcesIdImagecert", "CourcesIdImagecert", aCourcesMaster.CourcesIdImagecert);
            ViewData["ACourcesCertImagehr"] = new SelectList(_context.ACourcesCertImagehrs, "CourcesIdImagehr", "CourcesIdmaster");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1110(ACourcesMaster aCourcesMaster)
        {
            var objuser1 = _context.Cemps.Where(b => b.Cempid == aCourcesMaster.Cempid).FirstOrDefault();

            var ac = _context.ACourcesMasters.Find(aCourcesMaster.CourcesIdmaster);
            if (ac == null)
            {
                return NotFound();
            }
           
            try
            {
                ac.Cempid = "123";
                _context.Update(ac);//
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACourcesMasterExists(aCourcesMaster.CourcesIdmaster))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                //}



            }
            //logs
            ACourcesLogsD aa = new ACourcesLogsD
            {
                requestid = Convert.ToString(aCourcesMaster.CourcesIdmaster),
                userr = HttpContext.Session.GetString("empid"),
                tt = DateTime.Now
            };

            _context.ACourcesLogsD.Add(aa);//
            await _context.SaveChangesAsync();

            var empapproval2 = _context.Cemps.Where(h => h.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
            var empapproval1 = _context.Cemps.Where(h => h.Cempid == objuser1.Cempid).FirstOrDefault();
            var emprequestor = _context.Cemps.Where(h => h.Cempid == objuser1.Cempid).FirstOrDefault();


            WelcomeRequest request3 = new WelcomeRequest();
            request3.UserName = emprequestor.CEMPNAME;
            request3.header = "أرشفة الدورات التدريبة  ";
            request3.Details = "تم ازالة بيانات الدورة بعد اعتمادها  ,طلب رقم :" + aCourcesMaster.CourcesIdmaster + " بواسطة   : " + empapproval2.CEMPNAME;
            request3.ToEmail = emprequestor.mail;
            try
            {
                //await mailService.SendEmailAsync(m);
                await mailService.SendWelcomeEmailAsync(request3);
            }
            catch (Exception ex)
            {
                loggerx.Error(" خاص بالازالة  لم يتم ارسال الايميل للموظف ب خدمة أرشفة الدورات التدريبة بعد الاعتماد    " + emprequestor.Cempid + "اعتماد أرشفة الدورات التدريبة " + ex.Message);
            }


            //return RedirectToAction(nameof(Index));
                return RedirectToAction("ApprovelAllCourses", "ACourcesMasters", new { area = "" });
        }


        // GET: ACourcesMasters/Delete/5
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

            var aCourcesMaster = await _context.ACourcesMasters
                .Include(a => a.Cemp)
                .Include(a => a.Cources)
                .FirstOrDefaultAsync(m => m.CourcesIdmaster == id);
            if (aCourcesMaster == null)
            {
                return NotFound();
            }

            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(id);
            _context.ACourcesMasters.Remove(aCourcesMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesMasterExists(int id)
        {
            return _context.ACourcesMasters.Any(e => e.CourcesIdmaster == id);
        }
    }
}
