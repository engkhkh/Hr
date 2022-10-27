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
using System.Globalization;

namespace Hr.Controllers
{
    public class ACourcesOffereds3Controller : Controller
    {
        private readonly hrContext _context;

        public ACourcesOffereds3Controller(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesOffereds
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
                mmodule = x.mmodule
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);

            return View(await _context.ACourcesOffered.ToListAsync());
        }
        [HttpGet]

        // GET: ACourcesOffereds/Search
        public ActionResult Search()
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
            CultureInfo arSA = new CultureInfo("ar-SA");
            arSA.DateTimeFormat.Calendar = new HijriCalendar();
            var dateValue = DateTime.ParseExact("29/08/1434", "dd/MM/yyyy", arSA);
            ViewData["ACourcesOfferedoption"] = new SelectList(_context.ACourcesOptions, "id", "name");
         
                List<ACoursesLocation> ACoursesLocations = _context.ACoursesLocation.ToList();
                List<Cemp> Cemps = _context.Cemps.ToList();
                List<ACourcesIdManagement> ACourcesIdManagements = _context.ACourcesIdManagement.ToList();
                List<ACourcesOffered> ACourcesOffereds = _context.ACourcesOffered.ToList();
                List<ACourcesDeptin> ACourcesDeptins = _context.ACourcesDeptins.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();
                List<MasterDetails> MasterDetailss = _context.MasterDetailss.ToList();
                List<ACourcesDeptout> ACourcesDeptouts = _context.ACourcesDeptouts.ToList();
                List<ACourcesTrainingMethod> ACourcesTrainingMethods = _context.ACourcesTrainingMethods.ToList();
                List<ACourcesName> ACourcesNames = _context.ACourcesNames.ToList();
                var Records = from e in ACourcesOffereds
                              join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                              from d in table1.ToList()
                                 // join i in Cemps on e.Cempid equals i.Cempid into table2
                                 // from i in table2.ToList()
                                 //where i.Cempid == HttpContext.Session.GetString("empid") && e.CourcesIdManagement==Convert.ToInt32(HttpContext.Session.GetString("manageid"))
                              join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                              from j in table3.ToList() where  e.CourcesIdManagement== j.id  && j.newcode!=null && e.CourcesIdManagement == Convert.ToInt32(HttpContext.Session.GetString("manageid")) && DateTime.ParseExact(e.CourcesStartDate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", arSA) >= DateTime.Now
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                              join h in ACourcesDeptouts on e.CourcesIdDeptout equals h.CourcesIdDeptout into table5
                              from h in table5.ToList()
                              join n in ACourcesTrainingMethods on e.CourcesIdTraining equals n.CourcesIdTraining into table6
                              from n in table6.ToList()
                                  //join x in MasterRequestTypeIds on e.CourcesIdmaster equals x.COURCES_IDMASTER into table7
                                  //from x in table7.ToList()
                                  //where x.MasterRequestType != 0
                                  //join y in MasterDetailss on e.CourcesIdmaster equals y.COURCES_IDMASTER into table8
                                  //from y in table8.ToList()
                              join z in ACourcesNames on e.CourcesId equals z.CourcesId into table9
                              from z in table9.ToList()


                              select new ViewModelOfferedwithother
                              {
                                  ACourcesOffered = e,
                                  ACoursesLocation = d,
                                  //Cemps = i,
                                  ACourcesIdManagement = j,
                                  //ACourcesDeptins = f,
                                  ACourcesDeptouts = h,
                                  ACourcesTrainingMethods = n,
                                  //MasterRequestTypeIds = x,
                                  //MasterDetails = y,
                                  ACourcesNames = z
                              };
               
                return View(Records);
              
            

        }
       
        public void SomeAction(int id, [Bind("CourcesOfferedId,CourcesId,CourcesIdDeptout,CourcesIdLocation,CourcesIdManagement,CourcesIdperiodbydays,CourcesIdTime,CourcesStartDate,CourcesStartDateh,CourcesIdTraining,Cempid,Option")] ACourcesOffered aCourcesOffered1)
        {
            //Do work here.

            //var depwithmangforemps = _context.DepartWithMnagement.Where(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"))
            //                      .ToList<DepartWithMnagement>();

            var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefault(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));
            //int count = depwithmangforemps.Count;
            //int count = 1;
            if (depwithmangforemp  != null)
            {
                //var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefaultAsync(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));

                OfferedDetails OfferedDetailss = new OfferedDetails
                {
                    COURCES_IDOffered = id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
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




                OfferedRequestTypeId OfferedRequestTypeIds = new OfferedRequestTypeId
                {
                    COURCES_IDOffered = id,
                    Offercoursefrom= HttpContext.Session.GetString("empid"),
                    OfferedRequestType = 0

                };
                _context.Add(OfferedRequestTypeIds);
                _context.SaveChanges();


                //return RedirectToAction(nameof(Search));
            
            //return View(aCourcesOffered1);

           
        }
        public void send(int id, [Bind("CourcesOfferedId,CourcesId,CourcesIdDeptout,CourcesIdLocation,CourcesIdManagement,CourcesIdperiodbydays,CourcesIdTime,CourcesStartDate,CourcesStartDateh,CourcesIdTraining,Cempid,Option")] ACourcesOffered aCourcesOffered1)
        {
            //Do work here.
            if (ModelState.IsValid)
            {
                //var depwithmangforemps = _context.DepartWithMnagement.Where(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"))
                //                      .ToList<DepartWithMnagement>();
                //int count = depwithmangforemps.Count;
                int count = 1;
                if (count == 1)
                {
                    //var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefaultAsync(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));

                    OfferedDetails OfferedDetailss = new OfferedDetails
                    {
                        COURCES_IDOffered = 1/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                        OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                        OfferedRequestTo ="",
                        OfferedRequestTo2 = "5",
                        OfferedRequestTo3 = null,
                        OfferedRequestTo4 = null,
                        OfferedRequestTo5 = null,
                        OfferedRequestTypeSatus = 0,
                        OfferedRequestNotes = "",
                        Offeredoption = "4321031"

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




                OfferedRequestTypeId OfferedRequestTypeIds = new OfferedRequestTypeId
                {
                    COURCES_IDOffered = 1,
                    OfferedRequestType = 0

                };
                _context.Add(OfferedRequestTypeIds);
                _context.SaveChanges();


                //return RedirectToAction(nameof(Search));
            }
            //return View(aCourcesOffered1);


        }
        
        
        
        
        
        public async Task<IActionResult> Search(int id, [Bind("CourcesOfferedId,CourcesId,CourcesIdDeptout,CourcesIdLocation,CourcesIdManagement,CourcesIdperiodbydays,CourcesIdTime,CourcesStartDate,CourcesStartDateh,CourcesIdTraining,Cempid,Option")] ACourcesOffered aCourcesOffered1)
        {
            if (id != aCourcesOffered1.CourcesOfferedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var depwithmangforemps = _context.DepartWithMnagement.Where(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"))
                                      .ToList<DepartWithMnagement>();
                int count = depwithmangforemps.Count;
                if (count == 1)
                {
                    var depwithmangforemp = await _context.DepartWithMnagement.FirstOrDefaultAsync(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));

                    OfferedDetails OfferedDetailss = new OfferedDetails
                    {
                        COURCES_IDOffered = aCourcesOffered1.CourcesOfferedId/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                        OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                        OfferedRequestTo = depwithmangforemp.MANAGERID,
                        OfferedRequestTo2 = depwithmangforemp.PARENTMANAGERID,
                        OfferedRequestTo3 = null,
                        OfferedRequestTo4 = null,
                        OfferedRequestTo5 = null,
                        OfferedRequestTypeSatus = 0,
                        OfferedRequestNotes = "",
                        Offeredoption = "4321031"

                    };
                    _context.Add(OfferedDetailss);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    foreach (var item in depwithmangforemps)
                    {
                        string x = item.MANAGERID;

                    }
                }




                OfferedRequestTypeId OfferedRequestTypeIds = new OfferedRequestTypeId
                {
                    COURCES_IDOffered = _context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1,
                    OfferedRequestType = 0

                };


                return RedirectToAction(nameof(Search));
            }
            return View(aCourcesOffered1);
        }


        public ActionResult search1()
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
                          where x.OfferedRequestType == 0
                          join y in OfferedDetails3 on e.CourcesOfferedId equals y.COURCES_IDOffered into table8
                          from y in table8.ToList()
                          where y.OfferedRequestTypeSatus == 0
                          where (y.OfferedRequestFrom == HttpContext.Session.GetString("empid") && y.OfferedRequestTo3 == "0") && (/*y.OfferedRequestTo2 == HttpContext.Session.GetString("empid") &&*/ y.OfferedRequestTo4 == "1") /*|| (y.Offeredoption == HttpContext.Session.GetString("empid") && y.OfferedRequestTo5 == "0")*/

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

        // GET: ACourcesOffereds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesOffered = await _context.ACourcesOffered
                .FirstOrDefaultAsync(m => m.CourcesOfferedId == id);
            if (aCourcesOffered == null)
            {
                return NotFound();
            }

            return View(aCourcesOffered);
        }

        // GET: ACourcesOffereds/Create
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


            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["CourcesId"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId2"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId3"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId4"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId5"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId6"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId7"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");
            ViewData["CourcesId8"] = new SelectList(_context.ACourcesPrograms, "CourcesId", "CourcesName");

            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts.Where(c=>c.CourcesIdDeptout==1||c.CourcesIdDeptout==11), "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesLocation"] = new SelectList(_context.ACoursesLocation, "id", "name");

            return View();
        }

        // POST: ACourcesOffereds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("CourcesOfferedId,CourcesId,CourcesId2,CourcesId3,CourcesId4,CourcesId5,CourcesId6,CourcesId7,CourcesId8,CourcesIdDeptout,workdue,CourcesStartDate1,CourcesStartDate2,CourcesStartDate3,CourcesStartDate4,CourcesStartDate5,CourcesStartDate6,CourcesStartDate7,CourcesStartDate8,CourcesStartDateh,Cempid")]*/ ACourcesOffered3 aCourcesOffered)
        {



            if (ModelState.IsValid)
            {
                ACourcesPrograms newcourcename = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate1

                };
                if (aCourcesOffered.CourcesPassRate1 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate1)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage3 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId = newcourcename.CourcesId;
                    }

                }

                ACourcesPrograms newcourcename2 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate2

                };
                if (aCourcesOffered.CourcesPassRate2 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate2)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage33 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename2);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId2 = newcourcename2.CourcesId;
                    }

                }
                ACourcesPrograms newcourcename3 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate3

                };
                if (aCourcesOffered.CourcesPassRate3 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate3)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename3);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId3 = newcourcename3.CourcesId;
                    }

                }

                ACourcesPrograms newcourcename4 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate4

                };
                if (aCourcesOffered.CourcesPassRate4 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate4)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage3333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename4);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId = newcourcename4.CourcesId;
                    }

                }

                ACourcesPrograms newcourcename5 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate5

                };
                if (aCourcesOffered.CourcesPassRate5 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate5)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage33333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename5);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId5 = newcourcename5.CourcesId;
                    }

                }
                ACourcesPrograms newcourcename6 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate6

                };
                if (aCourcesOffered.CourcesPassRate6 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate6)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage333333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename6);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId6 = newcourcename6.CourcesId;
                    }

                }

                ACourcesPrograms newcourcename7 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate7

                };
                if (aCourcesOffered.CourcesPassRate7 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate7)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage3333333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename7);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId7 = newcourcename7.CourcesId;
                    }

                }

                ACourcesPrograms newcourcename8 = new ACourcesPrograms
                {


                    CourcesName = aCourcesOffered.CourcesPassRate8

                };
                if (aCourcesOffered.CourcesPassRate8 != null)
                {
                    var newcourcename1 = _context.ACourcesPrograms.Where(b => b.CourcesName.Equals(aCourcesOffered.CourcesPassRate8)).FirstOrDefault();
                    if (newcourcename1 != null)
                    {
                        ViewBag.ErrorMessage33333333 = "اسم الدورة موجود مسبقا ويرجي اختياره من القائمة   ";
                        return View(aCourcesOffered);
                    }
                    else
                    {
                        _context.Add(newcourcename8);
                        await _context.SaveChangesAsync();
                        aCourcesOffered.CourcesId8 = newcourcename8.CourcesId;
                    }

                }

                aCourcesOffered.Cempid = HttpContext.Session.GetString("username");
                //aCourcesOffered.Option = 0;
                _context.Add(aCourcesOffered);
                await _context.SaveChangesAsync();

                //Do work here.

                //var depwithmangforemps = _context.DepartWithMnagement.Where(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"))
                //                      .ToList<DepartWithMnagement>();

                var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefault(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));
                var manageremp = _context.Cemps.Where(x => x.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
                //int count = depwithmangforemps.Count;
                //int count = 1;
                if (depwithmangforemp != null)
                {
                    //var depwithmangforemp = _context.DepartWithMnagement.FirstOrDefaultAsync(m => m.CEMPADPRTNO == HttpContext.Session.GetString("empdepid"));

                    OfferedDetails3 OfferedDetailss = new OfferedDetails3
                    {
                        COURCES_IDOffered = aCourcesOffered.CourcesOfferedId/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                        OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                        OfferedRequestTo = manageremp.MANAGERID,// status in offerrequestto3
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




                OfferedRequestTypeId3 OfferedRequestTypeIds = new OfferedRequestTypeId3
                {
                    COURCES_IDOffered = aCourcesOffered.CourcesOfferedId,
                    Offercoursefrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestType = 0

                };
                _context.Add(OfferedRequestTypeIds);
                _context.SaveChanges();


                //return RedirectToAction(nameof(Search));

                //return View(aCourcesOffered1);


                return RedirectToAction(nameof(search1));
            }
            return View(aCourcesOffered);
        }

        // GET: ACourcesOffereds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesOffered = await _context.ACourcesOffered.FindAsync(id);
            if (aCourcesOffered == null)
            {
                return NotFound();
            }
            return View(aCourcesOffered);
        }

        // POST: ACourcesOffereds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesOfferedId,CourcesId,CourcesIdDeptout,CourcesIdLocation,CourcesIdManagement,CourcesIdperiodbydays,CourcesIdTime,CourcesStartDate,CourcesStartDateh,CourcesIdTraining,Cempid")] ACourcesOffered aCourcesOffered)
        {
            if (id != aCourcesOffered.CourcesOfferedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCourcesOffered);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACourcesOfferedExists(aCourcesOffered.CourcesOfferedId))
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
            return View(aCourcesOffered);
        }

        // GET: ACourcesOffereds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesOffered = await _context.ACourcesOffered
                .FirstOrDefaultAsync(m => m.CourcesOfferedId == id);
            if (aCourcesOffered == null)
            {
                return NotFound();
            }

            return View(aCourcesOffered);
        }

        // POST: ACourcesOffereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aCourcesOffered = await _context.ACourcesOffered.FindAsync(id);
            _context.ACourcesOffered.Remove(aCourcesOffered);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ACourcesOfferedExists(int id)
        {
            return _context.ACourcesOffered.Any(e => e.CourcesOfferedId == id);
        }
    }
}
