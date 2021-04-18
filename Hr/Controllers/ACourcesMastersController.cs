using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr.Models;

namespace Hr.Controllers
{
    public class ACourcesMastersController : Controller
    {
        private readonly hrContext _context;

        public ACourcesMastersController(hrContext context)
        {
            _context = context;
        }

        // GET: ACourcesMasters
        public async Task<IActionResult> Index()
        {
           
            var hrContext = _context.ACourcesMasters.Include(a => a.Cemp).Include(a => a.Cources);
            return View(await hrContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid")] ACourcesMaster aCourcesMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aCourcesMaster);
                await _context.SaveChangesAsync();
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
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
            return View(aCourcesMaster);
        }

        // POST: ACourcesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourcesIdmaster,CourcesId,CourcesIdType,CourcesIdDeptin,CourcesIdTraining,CourcesIdDeptout,CourcesIdEstimate,CourcesIdImagecert,CourcesIdImagehr,CourcesStartDate,CourcesEndDate,CourcesNumberofdays,CourcesPassRate,Cempid")] ACourcesMaster aCourcesMaster)
        {
            if (id != aCourcesMaster.CourcesIdmaster)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempid", aCourcesMaster.Cempid);
            ViewData["CourcesId"] = new SelectList(_context.ACourcesNames, "CourcesId", "CourcesId", aCourcesMaster.CourcesId);
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
