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
    public class ACourcesOfferedsController : Controller
    {
        private readonly hrContext _context;

        public ACourcesOfferedsController(hrContext context)
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
     //   [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
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
            List<ACourcesOptions> ACourcesOptions = _context.ACourcesOptions.ToList();
            var Records = from e in ACourcesOffereds
                          join d in ACoursesLocations on e.CourcesIdLocation equals d.id into table1
                          from d in table1.ToList()
                              join i in Cemps on e.Cempid equals i.Cempid into table2
                              from i in table2.ToList()
                              where i.Cempid == HttpContext.Session.GetString("empid")
                          join j in ACourcesIdManagements on e.CourcesIdManagement equals j.id into table3
                          from j in table3.ToList()
                              //join f in ACourcesDeptins on e.CourcesIdDeptin equals f.CourcesIdDeptin into table4
                              //from f in table4.ToList()
                          //join q in ACourcesOptions on e.Option equals q.id into table44
                          //from q in table44.ToList()
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
                              Cemps = i,
                              ACourcesIdManagement = j,
                              //ACourcesOptions=q,
                              //ACourcesDeptins = f,
                              ACourcesDeptouts = h,
                              ACourcesTrainingMethods = n,
                              //MasterRequestTypeIds = x,
                              //MasterDetails = y,
                              ACourcesNames = z
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
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesName");
            ViewData["CourcesIdLocation"] = new SelectList(_context.ACoursesLocation, "id", "name");
            ViewData["ACourcesIdManagement"] = new SelectList(_context.ACourcesIdManagement, "id", "name");
            ViewData["ACourcesDeptin"] = new SelectList(_context.ACourcesDeptins, "CourcesIdDeptin", "CourcesNameDeptin");
            ViewData["ACourcesDeptout"] = new SelectList(_context.ACourcesDeptouts, "CourcesIdDeptout", "CourcesNameDeptout");
            ViewData["ACourcesType"] = new SelectList(_context.ACourcesTypes, "CourcesIdType", "CourcesTypeName");
            ViewData["ACourcesTrainingMethod"] = new SelectList(_context.ACourcesTrainingMethods, "CourcesIdTraining", "CourcesNameTraining");
            ViewData["ACourcesEstimate"] = new SelectList(_context.ACourcesEstimates, "CourcesIdEstimate", "CourcesNameEstimate");
            return View();
        }

        // POST: ACourcesOffereds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourcesOfferedId,CourcesId,CourcesIdDeptout,CourcesIdLocation,CourcesIdManagement,CourcesIdperiodbydays,CourcesIdTime,CourcesStartDate,CourcesStartDateh,CourcesIdTraining,Cempid,available,timefrom,timeto")] ACourcesOffered aCourcesOffered)
        {



            if (ModelState.IsValid)
            {

                aCourcesOffered.Cempid = HttpContext.Session.GetString("username");
                aCourcesOffered.Option = 0;
                _context.Add(aCourcesOffered);
                await _context.SaveChangesAsync();
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
