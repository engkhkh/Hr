using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;

namespace Hr.Controllers
{
    public class ViewModelMasterwithotherController : Controller
    {
        private readonly hrContext _context;
        private readonly IDataProtector _protector;

        public ViewModelMasterwithotherController(hrContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector("Hr.ViewModelMasterwithotherController");
        }
      
            // GET: ViewModelMasterwithotherController
        public ActionResult Index(string search)

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
                              from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
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
                              from y in table8.ToList() where y.MasterRequestTo== HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid") || y.MasterRequestTo3 == HttpContext.Session.GetString("empid") || y.MasterRequestTo4 == HttpContext.Session.GetString("empid") || y.MasterRequestTo5 == HttpContext.Session.GetString("empid")
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
                              from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
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
                              where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid") || y.MasterRequestTo3 == HttpContext.Session.GetString("empid") || y.MasterRequestTo4 == HttpContext.Session.GetString("empid") || y.MasterRequestTo5 == HttpContext.Session.GetString("empid")
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList() where z.CourcesName.Contains(search)


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
        }

        public ActionResult IndexOffered(string search)
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
                List<ACourcesOffered> ACourcesOffered = _context.ACourcesOffered.ToList();
                List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
                List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
                List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
                List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered
                          //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          //    from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                              join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                              from x in table7.ToList()
                              where x.OfferedRequestType == 0
                              join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                              from y in table8.ToList() where y.OfferedRequestTypeSatus==0
                              where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "0") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "0") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0") 
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id  into table99
                              from nn in table99.ToList()
                             join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                              from nnn in table999.ToList()
                              
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()
                              

                              select new ViewModelMasterwithother
                              {
                                  ACourcesOffered = e,
                                  //ACourcesTypes = d,
                                  Cemps = i,
                                  //ACourcesEstimates = j,
                                  //ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  OfferedRequestTypeId = x,
                                  OfferedDetails = y,
                                  ACourcesIdManagement=nn,
                                  ACoursesLocation=nnn,
                                  ACourcesNames = z
                              };
                return View(Records);
            
        }



        public ActionResult IndexOffered2(string search)
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
            List<ACourcesOffered2> ACourcesOffered2 = _context.ACourcesOffered2.ToList();
            List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();
            //List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered2
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId2 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 0
                          join y in OfferedDetails2 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 0
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "0") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "0") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")
                          //join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          //from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered2 = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId2 = x,
                              OfferedDetails2 = y,
                              //ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }



        public ActionResult IndexOffered3(string search)
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
            TempData["user"] = HttpContext.Session.GetString("username");

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 0
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 0
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "0") /*|| (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "0") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };
            //TempData["hhgg"] = Records.ToList();

            return View(Records);
        }

        public ActionResult IndexOffered33(string search)
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
            TempData["user"] = HttpContext.Session.GetString("username");

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") && (/*y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") &&*/ y.OfferedRequestTo4 == "0") /*|| (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);
        }
        public ActionResult IndexOffered4(string search)
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

            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                              //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 0
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 0
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);
        }

        public ActionResult IndexOffered5(string search)
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

            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //    //from h in table5.ToList()
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 0
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 0
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")



                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);
        }

        public ActionResult approvedoffered()
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
            List<ACourcesOffered> ACourcesOffered = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);


        }


        public ActionResult approvedoffered2()
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
            List<ACourcesOffered2> ACourcesOffered2 = _context.ACourcesOffered2.ToList();
            List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();
            //List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered2
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId2 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails2 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")
                          //join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          //from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered2 = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId2= x,
                              OfferedDetails2 = y,
                              //ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);


        }


        public ActionResult approvedoffered3()
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

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") /*|| (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "0") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);

        }

        public ActionResult approvedoffered33()
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

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") && (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") /*|| (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);

        }

        public ActionResult approvedoffered4()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                              //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") ) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);
        }

        public ActionResult approvedoffered5()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //    //from h in table5.ToList()
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")



                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);
        }

        public ActionResult approvedalloffered4()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                              //where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                              //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);
        }

        public ActionResult approvedalloffered5()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                              //where i.Cempid == HttpContext.Session.GetString("empid")
                              //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                              //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //    //from h in table5.ToList()
                              //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")



                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);
        }

        [HttpPost]
        public ActionResult Canceloffered()
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
            List<ACourcesOffered> ACourcesOffered = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "2")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);


        }



        public ActionResult Canceloffered2()
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
            List<ACourcesOffered2> ACourcesOffered = _context.ACourcesOffered2.ToList();
            List<OfferedDetails2> OfferedDetails = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId = _context.OfferedRequestTypeId2.ToList();
            //List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "2")
                          //join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          //from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered2 = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId2 = x,
                              OfferedDetails2 = y,
                              //ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);


        }


        public ActionResult Canceloffered3()
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

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") /*|| (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "0") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);


        }

        public ActionResult Canceloffered33()
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

            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();

            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();


            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId3 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") && (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") /*|| (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()

                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);


        }

        public ActionResult Canceloffered4()
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
            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                              //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);


        }

        public ActionResult Canceloffered5()
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
            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //    //from h in table5.ToList()
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo3 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo4 == HttpContext.Session.GetString("empid")) || (y.OfferedRequestTo5 == HttpContext.Session.GetString("empid"))
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")



                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);

        }
        [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public ActionResult Inbox()
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

            // archiving
            List<MasterDetails> masterdeatails= _context.MasterDetailss.ToList();
            List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();


            // offer1
            List<OfferedDetails> OfferedDetails= _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();


            // offer2
            List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();

            //offer3
            List<OfferedDetails3> OfferedDetails3 = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId3 = _context.OfferedRequestTypeId3.ToList();


            //Needed1
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();


            //Needed2
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();

            //Eval 
            
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();

            List<EvalRequestTypeId> EvalRequestTypeId = _context.EvalRequestTypeIds.ToList();
            //Eval 2

            List<EvalDetail2> EvalDetails2 = _context.EvalDetailss2.ToList();

            List<EvalRequestTypeId2> EvalRequestTypeId2= _context.EvalRequestTypeIds2.ToList();

            //Transfer 

            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();

            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //Messages 

            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();

            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();


            //Support 

            List<SupportDetail> SupportDetails = _context.SupportDetails.ToList();

            List<SupportRequestTypeId> SupportRequestTypeIds = _context.SupportRequestTypeIds.ToList();


            var yy = from x in MasterRequestTypeIds
                     join n in masterdeatails on x.COURCES_IDMASTER equals n.COURCES_IDMASTER into table88
                     from n in table88.ToList().Distinct()
                     where (n.MasterRequestTo == HttpContext.Session.GetString("empid") || n.MasterRequestTo2 == HttpContext.Session.GetString("empid") || n.MasterRequestTo3 == HttpContext.Session.GetString("empid") || n.MasterRequestTo4 == HttpContext.Session.GetString("empid") || n.MasterRequestTo5 == HttpContext.Session.GetString("empid")) && x.MasterRequestType == 0 && n.MasterRequestTypeSatus == 0
                     select (x.COURCES_IDMASTER).ToString();
            TempData["MasterRequestTypeIds1"] = yy.ToList().Count();

            var xx = from e in OfferedRequestTypeId
                     join m in OfferedDetails on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                     from m in table77.ToList().Distinct()
                     where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3=="0" ) || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0 
                     select (e.COURCES_IDOffered).ToString();
            TempData["OfferedRequestTypeId1"] = xx.ToList().Count();

            var xx2 = from e in OfferedRequestTypeId2
                      join m in OfferedDetails2 on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                      select (e.COURCES_IDOffered).ToString();
            TempData["OfferedRequestTypeId2"] = xx2.ToList().Count();



            var xx3 = from e in OfferedRequestTypeId3
                      join m in OfferedDetails3 on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") /*|| (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0")*/ && e.OfferedRequestType == 0
                      select (e.COURCES_IDOffered).ToString();
            TempData["OfferedRequestTypeId3"] = xx3.ToList().Count();

            var xx4 = from e in NeededRequestTypeId
                      join m in NeededDetails on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") || m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo3 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo4 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo5 == HttpContext.Session.GetString("empid")) && e.OfferedRequestType == 0 && m.OfferedRequestTypeSatus==0
                      select (e.COURCES_IDOffered).ToString();
            TempData["OfferedRequestTypeId4"] = xx4.ToList().Count();

            //
            var xx5 = from e in Needed1RequestTypeId
                      join m in Needed1Details on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") || m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo3 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo4 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo5 == HttpContext.Session.GetString("empid")) && e.OfferedRequestType == 0 && m.OfferedRequestTypeSatus == 0
                      select (e.COURCES_IDOffered).ToString();
            TempData["OfferedRequestTypeId5"] = xx5.ToList().Count();

            //

            var xx6 = from e in EvalRequestTypeId
                      join m in EvalDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                      select (e.CourcesIdoffered).ToString();
            TempData["OfferedRequestTypeId6"] = xx6.ToList().Count();

            //

            var xx7 = from e in TransferRequestTypeIds
                      join m in TransferDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                      select (e.CourcesIdoffered).ToString();
            TempData["OfferedRequestTypeId7"] = xx7.ToList().Count();
            //
            var xx8 = from e in MessagesRequestTypeIds
                      join m in MessagesDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                      select (e.CourcesIdoffered).ToString();
            TempData["OfferedRequestTypeId8"] = xx8.ToList().Count();

            //
            var xx9 = from e in SupportRequestTypeIds
                      join m in SupportDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                      select (e.CourcesIdoffered).ToString();
            TempData["OfferedRequestTypeId9"] = xx9.ToList().Count();
            //

            var xx10 = from e in EvalRequestTypeId2
                       join m in EvalDetails2 on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                      from m in table77.ToList().Distinct()
                      where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                       join hh in EvalRequestTypeId on e.CourcesIdoffered equals hh.CourcesIdoffered into table5h
                       from hh in table5h.ToList()
                       where hh.OfferedRequestType == 1 && m.OfferedRequestTypeSatus != 2022
                       select (e.CourcesIdoffered).ToString();
            TempData["OfferedRequestTypeId10"] = xx10.ToList().Count();



            TempData["total"]= yy.ToList().Count()+ xx.ToList().Count()+xx2.ToList().Count() + xx3.ToList().Count() + xx4.ToList().Count()+ xx5.ToList().Count() + xx6.ToList().Count()+ xx7.ToList().Count()+ xx8.ToList().Count()+ xx9.ToList().Count()+ xx10.ToList().Count();



            var Records = from e in OfferedRequestTypeId
                          join m in OfferedDetails on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                          from m in table77.ToList().Distinct()
                          where m.OfferedRequestTo == HttpContext.Session.GetString("empid") || m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && e.OfferedRequestType == 0

                          //join x in MasterRequestTypeIds on e.OfferedRequestType equals x.MasterRequestType into table7
                          //from x in table7.ToList().Distinct()
                          //where x.MasterRequestType == 0 
                          from x in MasterRequestTypeIds
                          join n in masterdeatails on x.COURCES_IDMASTER equals n.COURCES_IDMASTER into table88
                          from n in table88.ToList().Distinct()
                          where n.MasterRequestTo== HttpContext.Session.GetString("empid") || n.MasterRequestTo2 == HttpContext.Session.GetString("empid")  && x.MasterRequestType ==n.MasterRequestTypeSatus && x.MasterRequestType==0


                          select new ViewModelMasterwithother
                          {
                              OfferedRequestTypeId = e,
                              MasterRequestTypeIds=x,
                              MasterDetails=n,
                              OfferedDetails=m
                             
                          };
            return View(Records.Distinct());

        }

        [HttpPost]
        public ActionResult approved()
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
            var Records = from e in ACourcesMasters
                          join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
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
                          join  y in MasterDetailss on e.CourcesIdmaster equals  y.COURCES_IDMASTER into table8
                          from y in table8.Distinct().ToList() where y.MasterRequestTypeSatus==1
                          where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid") || y.MasterRequestTo3 == HttpContext.Session.GetString("empid") || y.MasterRequestTo4 == HttpContext.Session.GetString("empid") || y.MasterRequestTo5 == HttpContext.Session.GetString("empid")
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

        [HttpPost]
        public ActionResult Cancel()
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
            var Records = from e in ACourcesMasters
                          join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          //where i.Cempid == HttpContext.Session.GetString("empid")
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
                          where x.MasterRequestType == 2
                          join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          from y in table8.ToList()
                          where y.MasterRequestTypeSatus == 2
                          where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid") || y.MasterRequestTo3 == HttpContext.Session.GetString("empid") || y.MasterRequestTo4 == HttpContext.Session.GetString("empid") || y.MasterRequestTo5 == HttpContext.Session.GetString("empid")
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


        [HttpPost]
        public ActionResult approveduser()
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
            var Records = from e in ACourcesMasters
                          join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() 
                              where i.Cempid == HttpContext.Session.GetString("empid")
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
                          from y in table8.Distinct().ToList()
                          where y.MasterRequestTypeSatus == 1
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
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


        public ActionResult approveduser3()
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


            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId = _context.OfferedRequestTypeId3.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();

            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") /*&& (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);

        }


        public ActionResult approveduser2()
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
            List<ACourcesOffered2> ACourcesOffered2 = _context.ACourcesOffered2.ToList();
            List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();
            //List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered2
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId2 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails2 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")
                          //join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          //from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered2 = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId2 = x,
                              OfferedDetails2 = y,
                              //ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }
        public ActionResult approveduser1()
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
            List<ACourcesOffered> ACourcesOffereds = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
            List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
           
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffereds
                          //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()
                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                           
                        
                              Cemps = i,
                              ACourcesTrainingMethods = n,
                               ACourcesOffered = e,
                              //ACourcesTypes = d,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }


        public ActionResult approveduser1n()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                          //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);



        }


        public ActionResult approveduser1n1()
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


            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //    //from h in table5.ToList()
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          ////where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          //join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          //from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);



        }
        public ActionResult approveduser1h()
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
            List<ACourcesOffered> ACourcesOffereds = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
            List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();

            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffereds
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 1
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 1
                          //where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "1") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "1") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()
                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {


                              Cemps = i,
                              ACourcesTrainingMethods = n,
                              ACourcesOffered = e,
                              //ACourcesTypes = d,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }

        [HttpPost]
        public ActionResult Canceluser()
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
            var Records = from e in ACourcesMasters
                          join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                              where i.Cempid == HttpContext.Session.GetString("empid")
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
                          where x.MasterRequestType == 2
                          join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          from y in table8.ToList()
                          where y.MasterRequestTypeSatus == 2
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
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


        public ActionResult Canceluser1()
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
            List<ACourcesOffered> ACourcesOffereds = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
            List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();

            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffereds
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "2")
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()
                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {


                              Cemps = i,
                              ACourcesTrainingMethods = n,
                              ACourcesOffered = e,
                              //ACourcesTypes = d,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }


        public ActionResult Canceluser1h()
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
            List<ACourcesOffered> ACourcesOffereds = _context.ACourcesOffered.ToList();
            List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();
            List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
            List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();

            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffereds
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          //where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "2")
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()
                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {


                              Cemps = i,
                              ACourcesTrainingMethods = n,
                              ACourcesOffered = e,
                              //ACourcesTypes = d,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              OfferedRequestTypeId = x,
                              OfferedDetails = y,
                              ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);

        }


        public ActionResult Canceluser1n()
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
            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded> ACourcesNeeded = _context.ACourcesNeeded.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<NeededRequestTypeId> NeededRequestTypeId = _context.NeededRequestTypeId.ToList();
            List<NeededDetails> NeededDetails = _context.NeededDetails.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            var Records = from e in ACourcesNeeded
                          join d in AJobsNames on e.jobsid equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                          join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          from f in table4.ToList()
                              //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              //from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in NeededRequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in NeededDetails on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          //where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded = e,
                              AJobsNames = d,
                              Cemps = i,
                              ACourcesIdManagement = j,
                              ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              NeededRequestTypeIds = x,
                              NeededDetails = y,
                              ACourcesPrograms = z
                          };
            return View(Records);


        }
        public ActionResult Canceluser1n1()
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
            List<AJobsNames> AJobsNames = _context.AJobsNames.ToList();
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACourcesNeeded1> ACourcesNeeded = _context.ACourcesNeeded1.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<Needed1RequestTypeId> Needed1RequestTypeId = _context.Needed1RequestTypeId.ToList();
            List<Needed1Details> Needed1Details = _context.Needed1Details.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
            List<ACourcesPrograms1> ACourcesPrograms1 = _context.ACourcesPrograms1.ToList();
            var Records = from e in ACourcesNeeded
                          join d in ACourcesPrograms1 on e.CourcesId equals d.CourcesId into table1
                          from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagement on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //    //join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          //    //from h in table5.ToList()
                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          join x in Needed1RequestTypeId on e.CourcesNeededId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in Needed1Details on e.CourcesNeededId equals y.COURCES_IDOffered into table8
                          from y in table8.Distinct().ToList()
                          where y.OfferedRequestTypeSatus == 2
                          ////where y.MasterRequestTo == HttpContext.Session.GetString("empid") || y.MasterRequestTo2 == HttpContext.Session.GetString("empid")
                          //join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          //from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesNeeded1 = e,
                              //AJobsNames = d,
                              Cemps = i,
                              //ACourcesIdManagement = j,
                              //ACourcesDeptins = f,
                              //ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              Needed1RequestTypeIds = x,
                              Needed1Details = y,
                              ACourcesPrograms1 = d
                          };
            return View(Records);



        }

        public ActionResult Canceluser3()
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
            List<Cemp> Cemps = _context.Cemps.ToList();
            List<ACourcesOffered3> ACourcesOffereds3 = _context.ACourcesOffered3.ToList();
            List<OfferedDetails3> OfferedDetails = _context.OfferedDetails3.ToList();
            List<OfferedRequestTypeId3> OfferedRequestTypeId = _context.OfferedRequestTypeId3.ToList();
            List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
            List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
            List<ACourcesPrograms> ACourcesPrograms = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms2 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms3 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms4 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms5 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms6 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms7 = _context.ACourcesPrograms.ToList();
            List<ACourcesPrograms> ACourcesPrograms8 = _context.ACourcesPrograms.ToList();

            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation2 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation3 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation4 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation5 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation6 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation7 = _context.ACoursesLocation.ToList();
            List<ACoursesLocation> ACoursesLocation8 = _context.ACoursesLocation.ToList();

            var Records = from e in ACourcesOffereds3
                              //join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              //from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList()
                          where i.Cempid == HttpContext.Session.GetString("empid")
                          //join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          //from j in table3.ToList()
                          //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                          //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join x in OfferedRequestTypeId on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") && (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") /*&& (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "1")*/

                          //join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          //from n in table6.ToList()
                          //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                          //from x in table7.ToList()
                          //where x.MasterRequestType != 0
                          //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                          //from y in table8.ToList()
                          join z in ACourcesPrograms on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()
                          join z2 in ACourcesPrograms2 on e.CourcesId2 equals z2.CourcesId into table9z2
                          from z2 in table9z2.ToList()
                          join z3 in ACourcesPrograms3 on e.CourcesId3 equals z3.CourcesId into table9z3
                          from z3 in table9z3.ToList()
                          join z4 in ACourcesPrograms4 on e.CourcesId4 equals z4.CourcesId into table9z4
                          from z4 in table9z4.ToList()
                          join z5 in ACourcesPrograms5 on e.CourcesId5 equals z5.CourcesId into table9z5
                          from z5 in table9z5.ToList()
                          join z6 in ACourcesPrograms6 on e.CourcesId6 equals z6.CourcesId into table9z6
                          from z6 in table9z6.ToList()
                          join z7 in ACourcesPrograms7 on e.CourcesId7 equals z7.CourcesId into table9z7
                          from z7 in table9z7.ToList()
                          join z8 in ACourcesPrograms8 on e.CourcesId8 equals z8.CourcesId into table9z8
                          from z8 in table9z8.ToList()
                          join z00 in ACoursesLocation on e.CourcesId01 equals z00.id into table900
                          from z00 in table900.ToList()
                          join z200 in ACoursesLocation2 on e.CourcesId02 equals z200.id into table9z200
                          from z200 in table9z200.ToList()
                          join z300 in ACoursesLocation3 on e.CourcesId03 equals z300.id into table9z300
                          from z300 in table9z300.ToList()
                          join z400 in ACoursesLocation4 on e.CourcesId04 equals z400.id into table9z400
                          from z400 in table9z400.ToList()
                          join z500 in ACoursesLocation5 on e.CourcesId05 equals z500.id into table9z500
                          from z500 in table9z500.ToList()
                          join z600 in ACoursesLocation6 on e.CourcesId06 equals z600.id into table9z600
                          from z600 in table9z600.ToList()
                          join z700 in ACoursesLocation7 on e.CourcesId07 equals z700.id into table9z700
                          from z700 in table9z700.ToList()
                          join z800 in ACoursesLocation8 on e.CourcesId08 equals z800.id into table9z800
                          from z800 in table9z800.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered3 = e,
                              //ACoursesLocation = d,
                              Cemps = i,
                              OfferedRequestTypeId3 = x,
                              OfferedDetails3 = y,
                              //ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              //ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesPrograms = z,
                              ACourcesPrograms2 = z2,
                              ACourcesPrograms3 = z3,
                              ACourcesPrograms4 = z4,
                              ACourcesPrograms5 = z5,
                              ACourcesPrograms6 = z6,
                              ACourcesPrograms7 = z7,
                              ACourcesPrograms8 = z8,
                              ACoursesLocation = z00,
                              ACoursesLocation2 = z200,
                              ACoursesLocation3 = z300,
                              ACoursesLocation4 = z400,
                              ACoursesLocation5 = z500,
                              ACoursesLocation6 = z600,
                              ACoursesLocation7 = z700,
                              ACoursesLocation8 = z800
                          };

            return View(Records);

        }




        public ActionResult Canceluser2()
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
            List<ACourcesOffered2> ACourcesOffered2 = _context.ACourcesOffered2.ToList();
            List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
            List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();
            //List<ACourcesIdManagement> ACourcesIdManagement = _context.ACourcesIdManagement.ToList();
            List<ACoursesLocation> ACoursesLocation = _context.ACoursesLocation.ToList();
            var Records = from e in ACourcesOffered2
                              //join d in ACourcesTypes on e.CourcesIdType equals d.CourcesIdType into table1
                              //    from d in table1.ToList()
                          join i in Cemps on e.Cempid equals i.Cempid into table2
                          from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in ACourcesEstimates on e.CourcesIdEstimate equals j.CourcesIdEstimate into table3
                              //from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                          from h in table5.ToList()
                          join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                          from n in table6.ToList()
                          join x in OfferedRequestTypeId2 on e.CourcesOfferedId equals x.COURCES_IDOffered into table7
                          from x in table7.ToList()
                          where x.OfferedRequestType == 2
                          join y in OfferedDetails2 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 2
                          where (y.OfferedRequestTo == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "2") || (y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && y.OfferedRequestTo4 == "2") || (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "2")
                          //join nn in ACourcesIdManagement on e.CourcesIdManagement equals nn.id into table99
                          //from nn in table99.ToList()
                          join nnn in ACoursesLocation on e.CourcesIdLocation equals nnn.id into table999
                          from nnn in table999.ToList()

                          join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                          from z in table9.ToList()


                          select new ViewModelMasterwithother
                          {
                              ACourcesOffered2 = e,
                              //ACourcesTypes = d,
                              Cemps = i,
                              //ACourcesEstimates = j,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              OfferedRequestTypeId2 = x,
                              OfferedDetails2 = y,
                              //ACourcesIdManagement = nn,
                              ACoursesLocation = nnn,
                              ACourcesNames = z
                          };
            return View(Records);
        }


        // GET: ViewModelMasterwithotherController/Details/5
        public ActionResult Details(int ?id)
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
            List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
            List<ACourcesMaster> ACourcesMasters = _context.ACourcesMasters.ToList();
            var record = from e in ACourcesMasters
                                       join d in MasterDetailss on e.CourcesIdmaster equals d.COURCES_IDMASTER into table1
                                       from d in table1.ToList()
                         select new ViewModelMasterwithother
                         {
                             MasterDetails = d,
                             
                         };
            var x=record.Where(e => e.MasterDetails.COURCES_IDMASTER == id)
                .SingleOrDefault();
            var MasterDetailssss = _context.MasterDetailss
                .Where(e => e.MasterDetailsSerial == id)
                .SingleOrDefault();
            if (x == null)
            {
                return NotFound();
            }
            return View(MasterDetailssss);
          
        }

        // GET: ViewModelMasterwithotherController/Create
        public ActionResult Create()
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

        // POST: ViewModelMasterwithotherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ViewModelMasterwithotherController/Edit/5
        public ActionResult Edit(int ?id)
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

            var MasterDetailssss = _context.MasterDetailss
                .Where(e => e.COURCES_IDMASTER == id )
                .SingleOrDefault();
            if (MasterDetailssss == null)
            {
                return NotFound();
            }
            return View(MasterDetailssss);
            //return RedirectToAction("Edit", "ViewModelMasterwithother", new { area = "" });
        }

        // POST: ViewModelMasterwithotherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("MasterRequestTypeSatus", "MasterRequestTo", "MasterRequestFrom", "COURCES_IDMASTER", "MasterRequestNotes")] MasterDetails MasterDetailsss)
        {
          
            if (id != MasterDetailsss.COURCES_IDMASTER)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    MasterDetails MasterDetails = new MasterDetails
                    {
                        COURCES_IDMASTER = MasterDetailsss.COURCES_IDMASTER,
                        MasterRequestFrom = MasterDetailsss.MasterRequestFrom,
                        MasterRequestTo = MasterDetailsss.MasterRequestTo,
                        MasterRequestTypeSatus = 1,
                        MasterRequestNotes = MasterDetailsss.MasterRequestNotes
                    };
                MasterRequestTypeId MasterRequestTypeIds = new MasterRequestTypeId
                {
                    COURCES_IDMASTER = MasterDetailsss.COURCES_IDMASTER,
                    MasterRequestType = 1
                };
                    _context.Add(MasterDetails);
                    _context.Update(MasterRequestTypeIds);
                    _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(MasterDetailsss);
        }

        // GET: ViewModelMasterwithotherController/Delete/5
        public ActionResult Delete(int id)
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

        // POST: ViewModelMasterwithotherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


     
        public void Create6(int i,int s)
        {
            
                var OfferDetailssss = _context.OfferedDetails3
               .Where(e => e.COURCES_IDOffered ==i && e.OfferedDetailsSerial == s)
                .SingleOrDefault();
                 if (/*OfferDetailssss.OfferedRequestTo2 == HttpContext.Session.GetString("empid") &&*/ OfferDetailssss.OfferedRequestTo4 == "0")
                {
                    //OfferDetailssss.OfferedRequestTo3 = "1";
                    OfferDetailssss.OfferedRequestTo4 = "1";
                    OfferDetailssss.OfferedRequestTo5 = "0";
                    OfferDetailssss.OfferedDetailsSerial = s;
                    OfferDetailssss.OfferedRequestTo2 = HttpContext.Session.GetString("empid");
                    _context.Update(OfferDetailssss);
                    _context.SaveChangesAsync();

                    OfferComments3 offerComments = new OfferComments3
                    {
                        id = s,
                        offerapproval = HttpContext.Session.GetString("empid"),
                        comments = HttpContext.Session.GetString("empid").ToString()
                    };

                    _context.Add(offerComments);
                    _context.SaveChangesAsync();

                }
              
            }
       
      



    }
}
