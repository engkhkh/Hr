using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hr.Models;

namespace Hr.Controllers
{
    public class ViewModelMasterwithotherController : Controller
    {
        private readonly hrContext _context;

        public ViewModelMasterwithotherController(hrContext context)
        {
            _context = context;
        }
      
            // GET: ViewModelMasterwithotherController
            public ActionResult Index(string search)
        {
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
                              where x.MasterRequestType == 0
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
                return View(Records);

            }
        }

        // GET: ViewModelMasterwithotherController/Details/5
        public ActionResult Details(int ?id)
        {
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
               
                    MasterDetails masterDetails = new MasterDetails
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
                    _context.Add(masterDetails);
                    _context.Update(MasterRequestTypeIds);
                    _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(MasterDetailsss);
        }

        // GET: ViewModelMasterwithotherController/Delete/5
        public ActionResult Delete(int id)
        {
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
    }
}
