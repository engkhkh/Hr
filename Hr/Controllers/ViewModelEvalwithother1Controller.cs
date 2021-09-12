using Hr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
    public class ViewModelEvalwithother1Controller : Controller
    {
        private readonly hrContext _context;
        AEvaluationGoal av1, av2, av3, av4, av5, av6;
        AEvaluationCompetenciesM  am1, am2, am3, am4, am5, am6,am7;
        AEvaluationCompetenciesD ad1, ad2, ad3, ad4, ad5, ad6, ad7,
            ad8,ad9,ad10,ad11,ad12,ad13,ad14,ad15,ad16,ad17,ad18,ad19,
            ad20,ad21,ad22,ad23;


        public ViewModelEvalwithother1Controller(hrContext context)
        {
            _context = context;
        }



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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                          //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                          //from d in table1.ToList()
                          //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                          //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                          //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                          //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0
                          


                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,
                          
                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0



                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                         
                          where (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "1")
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

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
            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "2") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "2") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "2")
                        
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }


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

            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "CEMPNAME");

            



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ViewModelEvalwithother1 ViewModelEvalwithother1)
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


            if (ModelState.IsValid)
            {
                AEvaluationEmp aEvaluationEmp = new AEvaluationEmp
                {
                    Empno = ViewModelEvalwithother1.AEvaluationEmpEmpno,
                    Empname = HttpContext.Session.GetString("empname"),
                    Jobname= HttpContext.Session.GetString("empjobname"),
                    DepName= HttpContext.Session.GetString("pname"),
                    SubDepName = HttpContext.Session.GetString("empdepname"),
                    ManagerName = HttpContext.Session.GetString("empmanagername"),
                    CovenantDate=DateTime.Now,
                    CovenantId=0,
                    CovenantYear=DateTime.Now.Year,
                    Managerid=Convert.ToInt32( HttpContext.Session.GetString("empmanagerid")),
                    Parentid=Convert.ToInt32( HttpContext.Session.GetString("manageid")),
                    Adprtno= Convert.ToInt32(HttpContext.Session.GetString("empdepid")),
                    EmpIdEnter= Convert.ToInt32(HttpContext.Session.GetString("empid")),
                    EvaEmpnoNameOut= "4211001",
                    EvaEmpnoOut= 4211001,
                    EvaEmpnoNameOut1=null,
                    Notes= "تم المراجعة",
                    TypeNo=5

                };
                _context.Add(aEvaluationEmp);
                await _context.SaveChangesAsync();
             

                List<AEvaluationGoal> aEvaluationGoals = new List<AEvaluationGoal>()
                  {
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=1,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName1,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria1,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight1,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=2,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName2,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria2,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight2,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=3,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName3,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria3,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight3,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=4,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName4,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria4,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight4,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput4,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=5,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName5,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria5,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight5,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput5,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},
                      new AEvaluationGoal{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,EmpType="مدير",CovenantGoalsSeq=6,CovenantGoalsName=ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName6,CovenantMeasurementCriteria=ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria6,CovenantPercentageWeight=ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight6,CovenantTargetedOutput=ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput6,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd),CovenantDate=DateTime.Now,EvaluationActualOutput=null,EvaluationDate=null,EvaluationDifferenceOutputs=null,EvaluationEquilibrium=null,EvaluationId=null,EvaluationResult=null,EvaluationTotal=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,EmpIdEnter=Convert.ToInt32(HttpContext.Session.GetString("empid"))},

                  };
                foreach (AEvaluationGoal AEvaluationGoal in aEvaluationGoals)
                {
                    _context.AEvaluationGoals.Add(AEvaluationGoal);
                }
                await _context.SaveChangesAsync();


                List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = new List<AEvaluationCompetenciesM>()
                {
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=1,CovenantCompetencyName="حس المسؤولية",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight1,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=2,CovenantCompetencyName="التعاون",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight2,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=3,CovenantCompetencyName="التواصل",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight3,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=4,CovenantCompetencyName="تحقيق النتائج",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight4,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=5,CovenantCompetencyName="التطوير ",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight5,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=6,CovenantCompetencyName="الارتباط الوظيفي",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight6,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesM{CovenantCompetenciesSeq=7,CovenantCompetencyName="القيادة",CovenantWeight=ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight7,EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantWeightSum=100,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},

                };
                foreach (AEvaluationCompetenciesM AEvaluationCompetenciesM in AEvaluationCompetenciesMs)
                {
                    _context.AEvaluationCompetenciesMs.Add(AEvaluationCompetenciesM);
                }
                await _context.SaveChangesAsync();
                //
                List<AEvaluationCompetenciesD> aEvaluationCompetenciesDs = new List<AEvaluationCompetenciesD>()
                {
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=1,CovenantCompetenciesDDesc="يتحمل مسؤولية أعماله و قراراته، ولا يلقى اللوم على الآخرين.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel1,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=1,CovenantCompetenciesDDesc="يفهم دوره، و كيفية ارتباطه بالأهداف العامة لجهة عمله.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel2,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=1,CovenantCompetenciesDDesc="يفصح عن ما يواجهة من تحديات بشفافية.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel3,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=2,CovenantCompetenciesDDesc="يشارك المعلومات بانفتاح وفق متطلبات العمل.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel4,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=2,CovenantCompetenciesDDesc="يسعى الى الاستفادة من اراء الأخرين من خارج ادارته ،و تهيئة الأخرين لدعم الأعمال التي يقوم بها من خلال بناء علاقات داعمة معهم  .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel5,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=2,CovenantCompetenciesDDesc="يستجيب لطلبات الدعم و المساندة من الوحدات التنظيمية في جهة عمله.يستجيب لطلبات الدعم و المساندة من الوحدات التنظيمية في جهة عمله  .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel6,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=3,CovenantCompetenciesDDesc="يستخدم التواصل المكتوب الواضح والفعال  .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel7,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=3,CovenantCompetenciesDDesc="يستخدم التواصل الشفهي الواضح والفعال.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel8,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=3,CovenantCompetenciesDDesc="ينصت للآخرين بعناية .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel9,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=4,CovenantCompetenciesDDesc="يستطيع القيام بمهام متعددة و تحديد أولوياتها  حسب اهميتها النسبية.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel10,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=4,CovenantCompetenciesDDesc="يمكن الاعتماد عليه , وينفذ مهامه في وقتها بمستوى عال من الجودة .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel11,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=4,CovenantCompetenciesDDesc="مبادر ويعمل بدون توجيه من رئيسه عند تنفيذه لمهامه.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel12,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=5,CovenantCompetenciesDDesc="يسعى إلى التعلم وتطوير نفسه باستمرار .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel13,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=5,CovenantCompetenciesDDesc="يساعد الأخرين على تطوير انفسهم .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel14,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=6,CovenantCompetenciesDDesc="لدية الاستعداد لمواجهة تحديات العمل .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel15,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=6,CovenantCompetenciesDDesc="يتطلُّع إلى مستوى أعلى من الإنجاز والابتكار عند تنفيذ العمل.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel16,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=6,CovenantCompetenciesDDesc="يلتزم بمواعيد العمل و يكون متواجدا عند الحاجة اليه .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel17,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=6,CovenantCompetenciesDDesc="يركز على خدمة العملاء عند تنفيذ اعماله",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel18,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=4,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=7,CovenantCompetenciesDDesc="مرن وقادر على تنفيذ أعمال هامة فى ظروف تنطوى على قدر كبير من المخاطرة وعدم اليقين .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel19,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=1,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=7,CovenantCompetenciesDDesc="يدعم و يشجع فريقه على تحقيق اهدافه، حتى في الظروف الصعبة  .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel20,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=2,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=7,CovenantCompetenciesDDesc="يفكر بمنطقية و ابداع دون التأثر بتحيزاته الشخصية.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel21,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=3,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=7,CovenantCompetenciesDDesc="يفوض الصلاحيات و يتابع النتائج  .",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel22,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=4,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},
                    new AEvaluationCompetenciesD{EmpId=ViewModelEvalwithother1.AEvaluationEmpEmpno,CovenantCompetenciesDSeq=7,CovenantCompetenciesDDesc="يوفر ويدعم فرص تطوير المرؤوسين.",CovenantCompetenciecDLevel=ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel23,EvaluationOutputCompetency=null,EvaluationResults=null,EvaluationTotal=null,CovenantCompetenciesDSeqD=5,CovenantId=_context.AEvaluationEmps.Max(u => u.Idd)},





                };
                foreach (AEvaluationCompetenciesD AEvaluationCompetenciesD in aEvaluationCompetenciesDs)
                {
                    _context.AEvaluationCompetenciesDs.Add(AEvaluationCompetenciesD);
                }
                await _context.SaveChangesAsync();
                //

                var objuser = _context.Cemps.Where(b => b.CEMPNO==Convert.ToString(ViewModelEvalwithother1.AEvaluationEmpEmpno)).FirstOrDefault();

                var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefault(m => m.CEMPADPRTNO == objuser.CEMPADPRTNO);
             
                if (depwithmangforemp != null)
                {
                   

                    EvalDetail OfferedDetailss = new EvalDetail
                    {
                        CourcesIdoffered = aEvaluationEmp.Idd,
                        OfferedRequestFrom =Convert.ToString( ViewModelEvalwithother1.AEvaluationEmpEmpno),
                        OfferedRequestTo = depwithmangforemp.MANAGERID,
                        OfferedRequestTo2 = depwithmangforemp.PARENTMANAGERID,
                        OfferedRequestTo3 = "0",
                        OfferedRequestTo4 = "1",
                        OfferedRequestTo5 = "1",
                        OfferedRequestTypeSatus = 0,
                        OfferedRequestNotes = "",
                        Offeredoption = "4056001"   

                    };
                    _context.Add(OfferedDetailss);
                     
                    await _context.SaveChangesAsync();
                }
                else
                {
                   
                }




                EvalRequestTypeId OfferedRequestTypeIds = new EvalRequestTypeId
                {
                    CourcesIdoffered = aEvaluationEmp.Idd,
                    Offercoursefrom = Convert.ToString(ViewModelEvalwithother1.AEvaluationEmpEmpno),
                    OfferedRequestType = 0

                };
                _context.Add(OfferedRequestTypeIds);
               await _context.SaveChangesAsync();


                //





                return RedirectToAction(nameof(Search1));
            }
            return View(ViewModelEvalwithother1);
        }



        // get 
        public ActionResult Edit(int? id)
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

            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "CEMPNAME");

            if (id == null)
            {
                return NotFound();
            }
            var vAEvaluationEmps1 = _context.AEvaluationEmps.Where(d=>d.Idd==id).FirstOrDefault();
            //var  vAEvaluationGoals1 = _context.AEvaluationGoals.Where(d => d.CovenantId == id).OrderBy(d => d.CovenantGoalsSeq).FirstOrDefault();
            List<AEvaluationGoal> vAEvaluationGoals = _context.AEvaluationGoals.Where(d => d.CovenantId == id).OrderBy(d=>d.CovenantGoalsSeq).ToList();
            av1 = vAEvaluationGoals[0];
            av2 = vAEvaluationGoals[1];
            av3 = vAEvaluationGoals[2];
            av4 = vAEvaluationGoals[3];
            av5 = vAEvaluationGoals[4];
            av6 = vAEvaluationGoals[5];
            List<AEvaluationCompetenciesM> vAEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.Where(d => d.CovenantId == id).OrderBy(d => d.CovenantCompetenciesSeq).ToList();
            am1 = vAEvaluationCompetenciesMs[0];
            am2 = vAEvaluationCompetenciesMs[1];
            am3 = vAEvaluationCompetenciesMs[2];
            am4 = vAEvaluationCompetenciesMs[3];
            am5 = vAEvaluationCompetenciesMs[4];
            am6 = vAEvaluationCompetenciesMs[5];
            am7 = vAEvaluationCompetenciesMs[6];

            List<AEvaluationCompetenciesD> vAEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.Where(d => d.CovenantId == id).OrderBy(d=>d.CovenantCompetenciesDSeq).ThenBy(d => d.CovenantCompetenciesDSeqD).ToList();
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
            ad19 = vAEvaluationCompetenciesDs[18];
            ad20 = vAEvaluationCompetenciesDs[19];
            ad21 = vAEvaluationCompetenciesDs[20];
            ad22 = vAEvaluationCompetenciesDs[21];
            ad23 = vAEvaluationCompetenciesDs[22];


            ViewModelEvalwithother1 ViewModelEvalwithother1 = new ViewModelEvalwithother1
            {
            AEvaluationEmpIdd= vAEvaluationEmps1.Idd,
            AEvaluationEmpEmpno = vAEvaluationEmps1.Empno,
            AEvaluationEmpEmpname=vAEvaluationEmps1.Empname,
            AEvaluationGoalCovenantId=av1.CovenantId,
            AEvaluationGoalCovenantGoalsName1 = av1.CovenantGoalsName,
            AEvaluationGoalCovenantGoalsName2 = av2.CovenantGoalsName,
            AEvaluationGoalCovenantGoalsName3 = av3.CovenantGoalsName,
            AEvaluationGoalCovenantGoalsName4 = av4.CovenantGoalsName,
            AEvaluationGoalCovenantGoalsName5 = av5.CovenantGoalsName,
            AEvaluationGoalCovenantGoalsName6 = av6.CovenantGoalsName,
            AEvaluationGoalCovenantMeasurementCriteria1 = av1.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantMeasurementCriteria2 = av2.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantMeasurementCriteria3 = av3.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantMeasurementCriteria4 = av4.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantMeasurementCriteria5 = av5.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantMeasurementCriteria6 = av6.CovenantMeasurementCriteria,
            AEvaluationGoalCovenantPercentageWeight1 = av1.CovenantPercentageWeight,
            AEvaluationGoalCovenantPercentageWeight2 = av2.CovenantPercentageWeight,
            AEvaluationGoalCovenantPercentageWeight3 = av3.CovenantPercentageWeight,
            AEvaluationGoalCovenantPercentageWeight4 = av4.CovenantPercentageWeight,
            AEvaluationGoalCovenantPercentageWeight5 = av5.CovenantPercentageWeight,
            AEvaluationGoalCovenantPercentageWeight6 = av6.CovenantPercentageWeight,
            AEvaluationGoalCovenantTargetedOutput1 = av1.CovenantTargetedOutput,
            AEvaluationGoalCovenantTargetedOutput2 = av2.CovenantTargetedOutput,
            AEvaluationGoalCovenantTargetedOutput3 = av3.CovenantTargetedOutput,
            AEvaluationGoalCovenantTargetedOutput4 = av4.CovenantTargetedOutput,
            AEvaluationGoalCovenantTargetedOutput5 = av5.CovenantTargetedOutput,
            AEvaluationGoalCovenantTargetedOutput6 = av6.CovenantTargetedOutput,
            AEvaluationCompetenciesMCovenantWeight1= am1.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight2 = am2.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight3 = am3.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight4 = am4.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight5 = am5.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight6 = am6.CovenantWeight,
            AEvaluationCompetenciesMCovenantWeight7 = am7.CovenantWeight,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel1=ad1.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel2 = ad2.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel3 = ad3.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel4 = ad4.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel5 = ad5.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel6 = ad6.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel7 = ad7.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel8 = ad8.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel9 = ad9.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel10 = ad10.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel11 = ad11.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel12 = ad12.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel13 = ad13.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel14 = ad14.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel15 = ad15.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel16 = ad16.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel17 = ad17.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel18 = ad18.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel19 = ad19.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel20 = ad20.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel21 = ad21.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel22 = ad22.CovenantCompetenciecDLevel,
            AEvaluationCompetenciesDCovenantCompetenciecDLevel23 = ad23.CovenantCompetenciecDLevel,





            };
           
            return View(ViewModelEvalwithother1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEvalwithother1 ViewModelEvalwithother1)
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
            //if (ViewModelEvalwithother1.AEvaluationEmpIdd == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {

                List<AEvaluationGoal> vAEvaluationGoals = _context.AEvaluationGoals.Where(d => d.CovenantId == ViewModelEvalwithother1.AEvaluationEmpIdd).ToList();
                av1 = vAEvaluationGoals[0];
                av2 = vAEvaluationGoals[1];
                av3 = vAEvaluationGoals[2];
                av4 = vAEvaluationGoals[3];
                av5 = vAEvaluationGoals[4];
                av6 = vAEvaluationGoals[5];
                av1.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av1.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName1;
                av1.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria1;
                av1.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight1;
                av1.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput1;
                av2.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av2.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName2;
                av2.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria2;
                av2.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight2;
                av2.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput2;
                av3.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av3.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName3;
                av3.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria3;
                av3.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight3;
                av3.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput3;
                av4.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av4.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName4;
                av4.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria4;
                av4.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight4;
                av4.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput4;
                av5.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av5.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName5;
                av5.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria5;
                av5.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight5;
                av5.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput5;
                av6.CovenantId = ViewModelEvalwithother1.AEvaluationGoalCovenantId;
                av6.CovenantGoalsName = ViewModelEvalwithother1.AEvaluationGoalCovenantGoalsName6;
                av6.CovenantMeasurementCriteria = ViewModelEvalwithother1.AEvaluationGoalCovenantMeasurementCriteria6;
                av6.CovenantPercentageWeight = ViewModelEvalwithother1.AEvaluationGoalCovenantPercentageWeight6;
                av6.CovenantTargetedOutput = ViewModelEvalwithother1.AEvaluationGoalCovenantTargetedOutput6;
                _context.Update(av1);
                _context.Update(av2);
                _context.Update(av3);
                _context.Update(av4);
                _context.Update(av5);
                _context.Update(av6);
                List<AEvaluationCompetenciesM> vAEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.Where(d => d.CovenantId == ViewModelEvalwithother1.AEvaluationEmpIdd).OrderBy(d => d.CovenantCompetenciesSeq).ToList();
                am1 = vAEvaluationCompetenciesMs[0];
                am2 = vAEvaluationCompetenciesMs[1];
                am3 = vAEvaluationCompetenciesMs[2];
                am4 = vAEvaluationCompetenciesMs[3];
                am5 = vAEvaluationCompetenciesMs[4];
                am6 = vAEvaluationCompetenciesMs[5];
                am7 = vAEvaluationCompetenciesMs[6];
                am1.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight1;
                am2.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight2;
                am3.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight3;
                am4.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight4;
                am5.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight5;
                am6.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight6;
                am7.CovenantWeight = ViewModelEvalwithother1.AEvaluationCompetenciesMCovenantWeight7;
                _context.Update(am1);
                _context.Update(am2);
                _context.Update(am3);
                _context.Update(am4);
                _context.Update(am5);
                _context.Update(am7);

                List<AEvaluationCompetenciesD> vAEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.Where(d => d.CovenantId == ViewModelEvalwithother1.AEvaluationEmpIdd).OrderBy(d => d.CovenantCompetenciesDSeq).ThenBy(d => d.CovenantCompetenciesDSeqD).ToList();
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
                ad19 = vAEvaluationCompetenciesDs[18];
                ad20 = vAEvaluationCompetenciesDs[19];
                ad21 = vAEvaluationCompetenciesDs[20];
                ad22 = vAEvaluationCompetenciesDs[21];
                ad23 = vAEvaluationCompetenciesDs[22];
                ad1.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel1;
                ad2.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel2;
                ad3.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel3;
                ad4.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel4;
                ad5.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel5;
                ad6.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel6;
                ad7.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel7;
                ad8.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel8;
                ad9.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel9;
                ad10.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel10;
                ad11.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel11;
                ad12.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel12;
                ad13.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel13;
                ad14.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel14;
                ad15.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel15;
                ad16.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel16;
                ad17.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel17;
                ad18.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel18;
                ad19.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel19;
                ad20.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel20;
                ad21.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel21;
                ad22.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel22;
                ad23.CovenantCompetenciecDLevel = ViewModelEvalwithother1.AEvaluationCompetenciesDCovenantCompetenciecDLevel23;
                _context.Update(ad1);
                _context.Update(ad2);
                _context.Update(ad3);
                _context.Update(ad4);
                _context.Update(ad5);

                _context.Update(ad6);
                _context.Update(ad7);
                _context.Update(ad8);
                _context.Update(ad9);
                _context.Update(ad10);
                _context.Update(ad11);

                _context.Update(ad12);
                _context.Update(ad13);
                _context.Update(ad14);
                _context.Update(ad15);
                _context.Update(ad16);
                _context.Update(ad17);
                _context.Update(ad18);
                _context.Update(ad19);

                _context.Update(ad20); 
                _context.Update(ad21);
                _context.Update(ad22);
                _context.Update(ad23);



                _context.SaveChanges();





                return RedirectToAction(nameof(Search1));
            }
            return View(ViewModelEvalwithother1);



        }

       //get
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


            List<AEvaluationEmp> AEvaluationEmps = _context.AEvaluationEmps.ToList();
            List<AEvaluationGoal> AEvaluationGoals = _context.AEvaluationGoals.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<EvalDetail> EvalDetails = _context.EvalDetailss.ToList();
            List<EvalRequestTypeId> EvalRequestTypeIds = _context.EvalRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in AEvaluationEmps
                              //join d in AEvaluationGoals on e.Idd equals d.CovenantId into table1
                              //from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in EvalDetails on e.Idd equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in EvalRequestTypeIds on e.Idd equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0




                          select new ViewModelEvalwithother
                          {
                              AEvaluationEmp = e,
                              //AEvaluationGoal = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              evalDetail = f,
                              evalRequestTypeId = h,

                          };
            return View(Records);


        }


    }
}
