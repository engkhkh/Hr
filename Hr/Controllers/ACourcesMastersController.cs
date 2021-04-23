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

namespace Hr.Controllers
{
    public class ACourcesMastersController : Controller
    {
        private readonly hrContext _context;
        private readonly IHostingEnvironment _hosting;

        public ACourcesMastersController(hrContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        // GET: ACourcesMasters
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
            return View(await hrContext.ToListAsync());
        }
        public ActionResult Search(string search)
        {
            if(search == null)
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
                              from i in table2.ToList()
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
                              from i in table2.ToList()
                              where i.CEMPNAME.Contains(search)
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
                              //where z.CourcesName.Contains(search)


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

        // GET: ACourcesMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: ACourcesMasters/Create
        public IActionResult Create()
        {
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
        public async Task<IActionResult> Create([Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid,Filecer,Filehr")] ACourcesMaster aCourcesMaster)
        {
            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath = Path.Combine(uploads, aCourcesMaster.Filecer.FileName);
                aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath, FileMode.Create));
                //
                string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                //
                ACourcesMaster aCourcesMasteritems = new ACourcesMaster
                {
                    CourcesId= aCourcesMaster.CourcesId,
                    CourcesIdType= aCourcesMaster.CourcesIdType,
                    CourcesIdDeptin= aCourcesMaster.CourcesIdDeptin,
                    CourcesIdTraining= aCourcesMaster.CourcesIdTraining,
                    CourcesIdDeptout= aCourcesMaster.CourcesIdDeptout,
                    CourcesIdEstimate= aCourcesMaster.CourcesIdEstimate,
                    CourcesIdImagecert= aCourcesMaster.Filecer.FileName,
                    CourcesIdImagehr= aCourcesMaster.Filehr.FileName,
                    CourcesStartDate= aCourcesMaster.CourcesStartDate,
                    CourcesEndDate= aCourcesMaster.CourcesEndDate,
                    CourcesNumberofdays=Convert.ToInt32((aCourcesMaster.CourcesEndDate- aCourcesMaster.CourcesStartDate).TotalDays),
                    CourcesPassRate= aCourcesMaster.CourcesPassRate,
                    Cempid="0"


                };
                MasterRequestTypeId MasterRequestTypeIds = new MasterRequestTypeId
                {
                    COURCES_IDMASTER = _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestType = 0

                };
                MasterDetails MasterDetailss = new MasterDetails
                {
                    COURCES_IDMASTER= _context.ACourcesMasters.Max(u => u.CourcesIdmaster) + 1,
                    MasterRequestFrom="0",
                    MasterRequestTo="0",
                    MasterRequestTypeSatus=0,
                    MasterRequestNotes=""

                };
                _context.Add(aCourcesMasteritems);
                _context.Add(MasterRequestTypeIds);
                _context.Add(MasterDetailss);
                await _context.SaveChangesAsync();
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

        // GET: ACourcesMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aCourcesMaster = await _context.ACourcesMasters.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid,Filecer,Filehr")] ACourcesMaster aCourcesMaster)
        {
            if (id != aCourcesMaster.CourcesIdmaster)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uploads1 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath1 = Path.Combine(uploads1, aCourcesMaster.Filecer.FileName);
                    aCourcesMaster.Filecer.CopyTo(new FileStream(fullPath1, FileMode.Create));
                    //
                    string uploads2 = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath2 = Path.Combine(uploads2, aCourcesMaster.Filehr.FileName);
                    aCourcesMaster.Filehr.CopyTo(new FileStream(fullPath2, FileMode.Create));
                    aCourcesMaster.CourcesIdImagecert = aCourcesMaster.Filecer.FileName;
                    aCourcesMaster.CourcesIdImagehr = aCourcesMaster.Filehr.FileName;
                    //
                    _context.Update(aCourcesMaster);
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
                }
                return RedirectToAction(nameof(Index));
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

        // GET: ACourcesMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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
