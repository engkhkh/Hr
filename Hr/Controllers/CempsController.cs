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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using System.Data;
//using AspNetCore.Reporting;
using jsreport.Types;
using jsreport.AspNetCore;
using Microsoft.Reporting.NETCore;
using System.Text;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Hr.Controllers
{
    public class CempsController : Controller
    {
        public IJsReportMVCService JsReportMVCService { get; }
        private readonly hrContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly IConfiguration Configuration;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        IDataProtector _protector;
        AEvaluationGoal av1, av2, av3, av4, av5, av6;
        AEvaluationCompetenciesM am1, am2, am3, am4, am5, am6, am7;
        AEvaluationCompetenciesD ad1, ad2, ad3, ad4, ad5, ad6, ad7,
            ad8, ad9, ad10, ad11, ad12, ad13, ad14, ad15, ad16, ad17, ad18, ad19,
            ad20, ad21, ad22, ad23;
        string TNS1 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.140)(PORT=1521)))(CONNECT_DATA=(SID=qassim)));User ID=MADCAP;Password=dba1435sjg*;";
        string TNS2 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.101)(PORT=1521)))(CONNECT_DATA= (SID=QSMSYS)));User ID=MORASLAT2;Password=MORASLAT2;";
        //string hader0 = "Data Source=QSMMPV-HADIR01;Initial Catalog=HadirDB;Integrated Security=False;User Id=erp;Password=Kh123456789$;MultipleActiveResultSets=True;";
        //string TNS3 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.13)(PORT=1521)))(CONNECT_DATA=(SID=sadad)));User ID=eservice;Password=eltizam_sjg";
        string USRNO = "1442910c";
        string EMPNAME = "test";
        string JOBNAME = "tester1";
        string ADPRTNO = "422150200";
        string DEP_NAME = "ادارة تطوير التطبيقات الالية";
        string CLSSNO;
        string MANAGERID = "4281001";
        string MANAGERID2 = "4431001";
        string MANAGERNAME = "باسل بن عبدالرحمن سليمان الحميضي";
        string MANAGERNAME2 = " test";
        string PARENTID = "422150000";
        string PARENTNAME = "الادارة العامة لتقنية المعلومات";
        string PASWRD = "00";
        string role = "3";
        string gender = "ذكر";
        string datebirth = "1442-01-01";
        string datehiring = "1442-01-01";
        string datelastupgrading = "1443-01-01";
        string NIDNO = "00000";
        DateTime checkin = DateTime.Now;
        DateTime checkout = DateTime.Now;
        string classe = "";
        string grade = "";
        string mobileno = "";
        public CempsController(hrContext context, IHostingEnvironment hosting, IConfiguration _configuration, IDataProtectionProvider provider, IJsReportMVCService jsReportMVCService)
        {
            _context = context;
            _hosting = hosting;
            _protector = provider.CreateProtector(GetType().FullName);
            JsReportMVCService = jsReportMVCService;
            Configuration = _configuration;

        }
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public ActionResult Print() {
            var dt = new DataTable();
        dt = GetEmployeeList();
        string mimetype = "application/pdf";
        string extension = "pdf";
            string renderformat = "pdf";
        
        //Dictionary<string, string> parameters = new Dictionary<string, string>();
        //parameters.Add("prm", "  ");
         LocalReport lr = new LocalReport();
        lr.DataSources.Add(new ReportDataSource("dsEmployee", dt));
        var parameters = new[] { new ReportParameter("prm"," ")};
        lr.ReportPath = $"{this._hosting.WebRootPath}\\Reports\\Employees.rdlc";
        lr.SetParameters(parameters);
        var pdf = lr.Render(renderformat);
         return File(pdf,mimetype,"Report."+extension);
            //var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            //return File(result.MainStream,"application/pdf");

                                   }
        private DataTable GetEmployeeList()
        {
            var dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("Department");
            dt.Columns.Add("BirthDate");
            dt.Columns.Add("hiring");
            dt.Columns.Add("class");
            dt.Columns.Add("grade");
            dt.Columns.Add("parent");
            dt.Columns.Add("phone");
            DataRow row;
            // for one employee
            //var Cemp = _context.Cemps.Where(xz => xz.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
            //row = dt.NewRow();
            //row["EmpId"] = Cemp.Cempid;
            //row["EmpName"] = Cemp.CEMPNAME;
            //row["Department"] = Cemp.DEP_NAME;
            //row["BirthDate"] =Convert.ToDateTime( Cemp.CEMPLASTUPGRADEHIJRA).ToString("yyyy-MM-dd");
            //dt.Rows.Add(row);

            List<Cemp> _Cemps = _context.Cemps.Where(x => x.CEMPADPRTNO == HttpContext.Session.GetString("empdepid") && x.MANAGERID == HttpContext.Session.GetString("username")&& x.CEMPPASSWRD.Length == 10&&x.CEMPPASSWRD1!=null && x.CEMPPASSWRD1 !="").Select(x => new Cemp
            {
                Cempid = x.Cempid,
                CEMPNAME = x.CEMPNAME,
                Cemphiringdate = x.Cemphiringdate,
                Cemplastupgrade = x.Cemplastupgrade,
                DEP_NAME=x.DEP_NAME,
                CEMPLASTUPGRADEHIJRA=x.CEMPLASTUPGRADEHIJRA,
                CEMPHIRINGDATEHIJRA=x.CEMPHIRINGDATEHIJRA,
                PARENTNAME=x.PARENTNAME,
                CLSSNO=x.CLSSNO,
                grade=x.grade,
                mobileno=x.mobileno,
                //RoleName = x.tblRole.Roles
            }).ToList();
            foreach(var cemp in _Cemps)
            {
                row = dt.NewRow();
                row["EmpId"] = cemp.Cempid;
                row["EmpName"] = cemp.CEMPNAME;
                row["Department"] = cemp.DEP_NAME;
                row["BirthDate"] = Convert.ToDateTime(cemp.CEMPLASTUPGRADEHIJRA).ToString("yyyy-MM-dd");
                row["hiring"] = Convert.ToDateTime(cemp.CEMPHIRINGDATEHIJRA).ToString("yyyy-MM-dd");
                row["class"] = cemp.CLSSNO;
                row["grade"] = cemp.grade;
                row["parent"] = cemp.PARENTNAME;
                row["phone"] = cemp.mobileno;

                dt.Rows.Add(row);
            }
            // test one 
            //for (int i = 1; i < 100; i++)
            //{
            //    row = dt.NewRow();
            //    row["EmpId"] = i;
            //    row["EmpName"] = i.ToString() + " Empl";
            //    row["Department"] = "XXYY";
            //    row["BirthDate"] = DateTime.Now.AddDays(-10000);
            //    dt.Rows.Add(row);
            //}

            return dt;
        }
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public IActionResult Cr()
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

        [Authorize(Roles = "Admin")]
        // GET: Cemps
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

            return View(await _context.Cemps.ToListAsync());
        }
        // Get MyInfo
        //[Authorize(Roles = "Admin, User")]
        //[Authorize(Roles ="Admin")]
        [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public async Task<IActionResult> MyInfo()
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
                mmodule=x.mmodule,
                treeroot = x.treeroot
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == HttpContext.Session.GetString("username"));
            if (cemp == null)
            {
                return NotFound();
            }
            List<Cemp> _Cemps = _context.Cemps.Where(x => x.CEMPADPRTNO ==HttpContext.Session.GetString("empdepid") && x.MANAGERID == HttpContext.Session.GetString("username") && x.CEMPPASSWRD.Length == 10 && x.CEMPPASSWRD1 != null && x.CEMPPASSWRD1 != "").Select(x => new Cemp
            {
               Cempid=x.Cempid,
               CEMPNAME=x.CEMPNAME,
               Cemphiringdate=x.Cemphiringdate,
               Cemplastupgrade=x.Cemplastupgrade
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["Cemps"] = JsonConvert.SerializeObject(_Cemps);
            var empnat = _context.Cemps.Where(x => x.CEMPNO == HttpContext.Session.GetString("username")).FirstOrDefault();
            string idc = "[ID]=" + empnat.CEMPPASSWRD;
            TempData["q"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(idc));
            //TempData["q"] = HttpUtility.UrlEncode(idc);
            //ViewData["Cempid"] = new SelectList(_context.Cemps.Where(c => c.CEMPADPRTNO == HttpContext.Session.GetString("empdepid") && c.MANAGERID == HttpContext.Session.GetString("username") || c.CEMPNO == HttpContext.Session.GetString("username")), "Cempid", "CEMPNAME");
            return View(cemp);
        }
        //public IActionResult Export()
        //{
        //    var dt = new DataTable();
        //    dt = GetEmployeeList();
        //    string mimetype = "";
        //    int extension = 1;
        //    var path = $"{this._hosting.WebRootPath}\\Reports\\Employees.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("prm", "RDLC report (Set as parameter)");
        //    LocalReport lr = new LocalReport(path);
        //    lr.AddDataSource("dsEmployee", dt);
        //    var result = lr.Execute(RenderType.Excel, extension, parameters, mimetype);
        //    return File(result.MainStream, "application/msexcel", "Export.xls");
        //}
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> Print1()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
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
            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == HttpContext.Session.GetString("username"));
            if (cemp == null)
            {
                return NotFound();
            }
            List<Cemp> _Cemps = _context.Cemps.Where(x => x.CEMPADPRTNO == HttpContext.Session.GetString("empdepid") && x.MANAGERID == HttpContext.Session.GetString("username") && x.CEMPPASSWRD.Length == 10 && x.CEMPPASSWRD1 != null && x.CEMPPASSWRD1 != "").Select(x => new Cemp
            {
                Cempid = x.Cempid,
                CEMPNAME = x.CEMPNAME,
                Cemphiringdate = x.Cemphiringdate,
                Cemplastupgrade = x.Cemplastupgrade
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["Cemps"] = JsonConvert.SerializeObject(_Cemps);

            return View(cemp);
        }

        // GET: Cemps/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
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

            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == id);
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        public void hader(int id,string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from&&x.CourcesIdmaster==id).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid=id,
                mestypetopic="  معالجة ايام الغياب اثناء الدورة  للموظف  "+ emp.CEMPNAME  +"/ ورقمه الوظيفي  "+emp.Cempid,
                redesc="فترة الدورة  "+course.CourcesStartDate.ToString("d") + "  :  " + course.CourcesEndDate.ToString("d"),
                Daterequest =DateTime.Now


            };


            _context.Add(messagesProcess);
            _context.SaveChanges();

            MessagesDetail OfferedDetailss = new MessagesDetail
                {
                    CourcesIdoffered = messagesProcess.Id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                    OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestTo = "4331051", // status in offerrequestto3  4291135
                    OfferedRequestTo2 = "",// status in offerrequestto4
                    OfferedRequestTo3 = "0",
                    OfferedRequestTo4 = "1",
                    OfferedRequestTo5 = "1",// status for  hrpersonapproval
                    OfferedRequestTypeSatus = 0,
                    OfferedRequestNotes = "",
                    Offeredoption = ""   // will srore hr person

                };
                _context.Add(OfferedDetailss);
                _context.SaveChanges();
            
             




            MessagesRequestTypeId OfferedRequestTypeIds = new MessagesRequestTypeId
            {
                CourcesIdoffered = messagesProcess.Id,
                Offercoursefrom = HttpContext.Session.GetString("empid"),
                OfferedRequestType = 0

            };
            _context.Add(OfferedRequestTypeIds);
            _context.SaveChanges();


            //return RedirectToAction(nameof(Search));

            //return View(aCourcesOffered1);


        }
        public void payroll(int id,  string from)
        {
            var emp = _context.Cemps.Where(x => x.Cempid == from).FirstOrDefault();
            var course = _context.ACourcesMasters.Where(x => x.Cempid == from && x.CourcesIdmaster == id).FirstOrDefault();

            MessagesProcess messagesProcess = new MessagesProcess
            {
                Fromr = HttpContext.Session.GetString("empid"),
                mestypereqid = id,
                mestypetopic = " احتساب الاستحقاقات المالية للدورة للموظف   " + emp.CEMPNAME + "  ورقمه الوظيفي " + emp.Cempid,
                redesc = "فترة الدورة " + course.CourcesStartDate.ToString("d") +"  :   "+ course.CourcesEndDate.ToString("d"),
                Daterequest = DateTime.Now


            };
            _context.Add(messagesProcess);
            _context.SaveChanges();

            MessagesDetail OfferedDetailss = new MessagesDetail
                {
                    CourcesIdoffered = messagesProcess.Id/*_context.ACourcesOffered.Max(u => u.CourcesOfferedId) + 1*/,
                    OfferedRequestFrom = HttpContext.Session.GetString("empid"),
                    OfferedRequestTo = "4291135",// status in offerrequestto3
                    OfferedRequestTo2 ="",// status in offerrequestto4
                    OfferedRequestTo3 = "0",
                    OfferedRequestTo4 = "1",
                    OfferedRequestTo5 = "1",// status for  hrpersonapproval
                    OfferedRequestTypeSatus = 0,
                    OfferedRequestNotes = "",
                    Offeredoption = ""   // will srore hr person

                };
                _context.Add(OfferedDetailss);
                _context.SaveChanges();
           
             




            MessagesRequestTypeId OfferedRequestTypeIds = new MessagesRequestTypeId
            {
                CourcesIdoffered = messagesProcess.Id,
                Offercoursefrom = HttpContext.Session.GetString("empid"),
                OfferedRequestType = 0

            };
            _context.Add(OfferedRequestTypeIds);
            _context.SaveChanges();



            //return RedirectToAction(nameof(Search));

            //return View(aCourcesOffered1);


        }

        // GET: Cemps/Create
        [Authorize(Roles = "Admin")]
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
            return View();
        }

        // POST: Cemps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(/*[Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] */Cemp cemp)
        {
            if (ModelState.IsValid)
            {
                cemp.Cempid = cemp.Cempid;
                cemp.CEMPUSERNO = cemp.CEMPUSERNO;
                cemp.CEMPPASSWRD= cemp.Cempid;
                cemp.CEMPNO= cemp.Cempid;
                cemp.CEMPNAME= cemp.Cempid;
                cemp.CEMPJOBNAME= cemp.Cempid;
                cemp.CEMPADPRTNO= cemp.Cempid;
                cemp.DEP_NAME= cemp.Cempid;
                cemp.CLSSNO= cemp.Cempid;
                cemp.MANAGERID= cemp.Cempid;
                cemp.MANAGERNAME= cemp.Cempid;
                cemp.PARENTID= cemp.Cempid;
                cemp.PARENTNAME= cemp.Cempid;
                cemp.login = '0';
                cemp.mobileno = cemp.Cempid;
                cemp.mail = cemp.Cempid;
                cemp.MANAGERID2 = cemp.Cempid;
                cemp.MANAGERID2id = cemp.Cempid;
                cemp.MANAGERNAME= cemp.Cempid;
                cemp.CEMPHIRINGDATEHIJRA = DateTime.Now.Date;
                cemp.Cemphiringdate = DateTime.Now;
                cemp.CEMPLASTUPGRADEHIJRA = DateTime.Now.Date;
                cemp.Cemplastupgrade = DateTime.Now;
                cemp.CROLEID = 3;
                cemp.imagepath = " ";
                cemp.cbrowser = " ";
                cemp.cip = " ";
                cemp.grade = " ";
                cemp.CEMPPASSWRD1 = " ";

                _context.Add(cemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cemp);
        }
        // GET: Cemps/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create0()
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
            ViewData["Cempid"] = new SelectList(_context.Cemps.ToList(), "Cempid", "CEMPNAME");
            return View();
        }

        // POST: Cemps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create0(/*[Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] */Cemp cemp,String ID0)
        {
            string x = ID0;
            var ci = CultureInfo.CreateSpecificCulture("ar-SA");
            // Cemp cemp0 ;
            OracleConnection Con = new OracleConnection(TNS1);
            DataTable tab = new DataTable();
            if (ModelState.IsValid)
            {
                List<Cemp> cemps0 = _context.Cemps.ToList();
                if (x == "00")
                {
                    foreach (var cemp0 in cemps0.ToList())
                    {
                        Con.Open();
                        OracleDataAdapter da = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO=" + cemp0.Cempid + " ", Con);
                        da.Fill(tab);
                        DataRow[] dr = tab.Select("USRNO=" + cemp0.Cempid + "");
                        if (dr.Count() > 0)
                        {

                            USRNO = dr[0]["USRNO"].ToString();
                            EMPNAME = dr[0]["EMPNAME"].ToString();
                            JOBNAME = dr[0]["JOBNAME"].ToString();
                            ADPRTNO = dr[0]["ADPRTNO"].ToString();
                            DEP_NAME = dr[0]["DEP_NAME"].ToString();
                            CLSSNO = dr[0]["CLSSNO"].ToString();
                            MANAGERID = dr[0]["MANAGERID"].ToString();
                            MANAGERNAME = dr[0]["MANAGERNAME"].ToString();
                            PARENTID = dr[0]["PARENTID"].ToString();
                            PARENTNAME = dr[0]["PARENTNAME"].ToString();
                            PASWRD = dr[0]["PASWRD"].ToString();


                        }
                        else
                        {
                            string conString = this.Configuration.GetConnectionString("hr");
                            using (SqlConnection con = new SqlConnection(conString))
                            {

                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "DELETE FROM [hr].[dbo].[CEMPS] WHERE [CEMPID] = @UserId AND [CEMPUSERNO]=@UserId2";
                                    cmd.Parameters.AddWithValue("@UserId", cemp0.Cempid);
                                    cmd.Parameters.AddWithValue("@UserId2", cemp0.Cempid);
                                    //cmd.Parameters.AddWithValue("@Status", 1);
                                    //cmd.Parameters.AddWithValue("@CommiteDe", ViewModelEvalwithother.c10);
                                    //cmd.Parameters.AddWithValue("@Announce", ViewModelEvalwithother.c11);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                           // break;
                        }
                            Con.Close();
                            //
                            Con.Open();
                            DataTable tab0 = new DataTable();
                            OracleDataAdapter da0 = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO = " + MANAGERID + " ", Con);
                            da0.Fill(tab0);
                            DataRow[] dr0 = tab0.Select("USRNO=" + MANAGERID + "");
                            if (dr0.Count() > 0)
                            {

                                //USRNO = dr[0]["USRNO"].ToString();
                                //EMPNAME = dr[0]["EMPNAME"].ToString();
                                //JOBNAME = dr[0]["JOBNAME"].ToString();
                                //ADPRTNO = dr[0]["ADPRTNO"].ToString();
                                //DEP_NAME = dr[0]["DEP_NAME"].ToString();
                                //CLSSNO = dr[0]["CLSSNO"].ToString();
                                MANAGERID2 = dr0[0]["MANAGERID"].ToString();
                                MANAGERNAME2 = dr0[0]["MANAGERNAME"].ToString();
                                //PARENTID = dr[0]["PARENTID"].ToString();
                                //PARENTNAME = dr[0]["PARENTNAME"].ToString();
                                //PASWRD = dr[0]["PASWRD"].ToString();


                            }
                            Con.Close();
                            Con.Open();
                            //
                            DataTable tab1 = new DataTable();
                            OracleDataAdapter da1 = new OracleDataAdapter("select * from MADCAP.A_VGET_EMP_DATA where EMPNO=" + cemp0.Cempid + " ", Con);
                            da1.Fill(tab1);
                            DataRow[] dr1 = tab1.Select("EMPNO=" + cemp0.Cempid + "");
                            if (dr1.Count() > 0)
                            {
                                var birthdate = dr1[0]["BIRTHDATE"].ToString() == "" ? "1442-01-01" : dr1[0]["BIRTHDATE"].ToString();
                                var hiringdate = dr1[0]["FAPPLDAT"].ToString() == "" ? "1442-01-01" : dr1[0]["FAPPLDAT"].ToString();
                                var lastupgradingdate = dr1[0]["CLASS_DATE"].ToString() == "" ? "14430101" : dr1[0]["CLASS_DATE"].ToString();
                                //var grade = dr1[0]["GRADE"].ToString();
                                NIDNO = dr1[0]["NIDNO"].ToString();
                                classe = dr1[0]["CLSSNO"].ToString();
                                grade = dr1[0]["GRADE"].ToString();
                                mobileno = dr1[0]["MOBILE_NO"].ToString();
                                role = dr1[0]["MANAGER"].ToString() == "1" ? "2" : "3";
                                gender = dr1[0]["SEX"].ToString() == "1" ? "ذكر" : "أنثي";
                               
                               var date00 = birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2);
                               //var date0 = Convert.ToDateTime(birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2));
                               var date = Convert.ToDateTime(hiringdate.Substring(0, 4) + "-" + hiringdate.Substring(4, 2) + "-" + hiringdate.Substring(6, 2));
                               var date1 = Convert.ToDateTime(lastupgradingdate.Substring(0, 4) + "-" + lastupgradingdate.Substring(4, 2) + "-" + lastupgradingdate.Substring(6, 2));

                               //date.ToString("dd/MM - MMMM d"); // 28/06 - June 28
                               //date.ToString("dd/MM/yyyy"); // 28/06/2013
                             datebirth = date00.ToString(ci);
                             if(datebirth.Contains("1400-02-29")||datebirth.Contains("1406-02-29")||datebirth.Contains("1399-02-30") || datebirth.Contains("1395-02-29"))
                              {
                               
                                datebirth = date.ToString("yyyy-MM-dd");
                            }
                                //datebirth = date0.ToString("yyyy-MM-dd");
                                datehiring = date.ToString("yyyy-MM-dd");
                                datelastupgrading = date1.ToString("yyyy-MM-dd");

                            }

                            Con.Close();
                           // Con.Dispose();


                            cemp = _context.Cemps.Where(z => z.Cempid == cemp0.Cempid).FirstOrDefault();
                           if (cemp != null)
                           {
                            cemp.Cempid = cemp.Cempid;
                            cemp.CEMPNAME = EMPNAME;
                            cemp.CEMPJOBNAME = JOBNAME;
                            cemp.CEMPPASSWRD = NIDNO;
                            //cemp0.CEMPPASSWRD1 = password;
                            cemp.CLSSNO = CLSSNO;
                            cemp.grade = grade;
                            cemp.mobileno = mobileno;
                            //cemp0.mail = userPrincipalName;
                            cemp.MANAGERNAME = MANAGERNAME;
                            cemp.CEMPADPRTNO = ADPRTNO;
                            cemp.DEP_NAME = DEP_NAME;
                            cemp.MANAGERID = MANAGERID;
                            cemp.MANAGERID2id = MANAGERID2;
                            cemp.MANAGERID2 = MANAGERNAME2;
                            cemp.MANAGERNAME = MANAGERNAME;
                            cemp.PARENTID = PARENTID;
                            cemp.PARENTNAME = PARENTNAME;
                            cemp.Cemphiringdate = checkin;
                            cemp.Cemplastupgrade = checkout;
                            cemp.CEMPHIRINGDATEHIJRA = Convert.ToDateTime(datehiring);
                            cemp.CEMPLASTUPGRADEHIJRA = Convert.ToDateTime(datelastupgrading);
                            //objuser.CROLEID = objuser.CROLEID == 2 ? Convert.ToInt32(role) : objuser.CROLEID == 3 ? Convert.ToInt32(role) : objuser.CROLEID == 5 ? 5 : objuser.CROLEID == 7 ? 7 : objuser.CROLEID == 1 ? 1 : 3;
                            cemp.gender = gender;
                            cemp.CEMPBIRTHDATEHIJRA =DateTime.Parse(datebirth, CultureInfo.InvariantCulture).Date;
                            //cemp.CLSSNO = cemp.Cempid;
                            //cemp.MANAGERID = cemp.Cempid;
                            //cemp.MANAGERNAME = cemp.Cempid;
                            //cemp.PARENTID = cemp.Cempid;
                            //cemp.PARENTNAME = cemp.Cempid;
                            //cemp.login = '0';
                            //cemp.mobileno = cemp.Cempid;
                            //cemp.mail = cemp.Cempid;
                            //cemp.MANAGERID2 = cemp.Cempid;
                            //cemp.MANAGERID2id = cemp.Cempid;
                            //cemp.MANAGERNAME = cemp.Cempid;
                            //cemp.CEMPHIRINGDATEHIJRA = DateTime.Now.Date;
                            //cemp.Cemphiringdate = DateTime.Now;
                            //cemp.CEMPLASTUPGRADEHIJRA = DateTime.Now.Date;
                            //cemp.Cemplastupgrade = DateTime.Now;
                            //cemp.CROLEID = 3;
                            //cemp.imagepath = " ";
                            //cemp.cbrowser = " ";
                            //cemp.cip = " ";
                            //cemp.grade = " ";
                            //cemp.CEMPPASSWRD1 = " ";
                            _context.Update(cemp);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                
                else
                {

                    Con.Open();
                    OracleDataAdapter da = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO=" + ID0 + " ", Con);
                    da.Fill(tab);
                    DataRow[] dr = tab.Select("USRNO=" + ID0 + "");
                    if (dr.Count() > 0)
                    {

                        USRNO = dr[0]["USRNO"].ToString();
                        EMPNAME = dr[0]["EMPNAME"].ToString();
                        JOBNAME = dr[0]["JOBNAME"].ToString();
                        ADPRTNO = dr[0]["ADPRTNO"].ToString();
                        DEP_NAME = dr[0]["DEP_NAME"].ToString();
                        CLSSNO = dr[0]["CLSSNO"].ToString();
                        MANAGERID = dr[0]["MANAGERID"].ToString();
                        MANAGERNAME = dr[0]["MANAGERNAME"].ToString();
                        PARENTID = dr[0]["PARENTID"].ToString();
                        PARENTNAME = dr[0]["PARENTNAME"].ToString();
                        PASWRD = dr[0]["PASWRD"].ToString();


                    }
                    Con.Close();
                    //
                    Con.Open();
                    DataTable tab0 = new DataTable();
                    OracleDataAdapter da0 = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO = " + MANAGERID + " ", Con);
                    da0.Fill(tab0);
                    DataRow[] dr0 = tab0.Select("USRNO=" + MANAGERID + "");
                    if (dr0.Count() > 0)
                    {

                        //USRNO = dr[0]["USRNO"].ToString();
                        //EMPNAME = dr[0]["EMPNAME"].ToString();
                        //JOBNAME = dr[0]["JOBNAME"].ToString();
                        //ADPRTNO = dr[0]["ADPRTNO"].ToString();
                        //DEP_NAME = dr[0]["DEP_NAME"].ToString();
                        //CLSSNO = dr[0]["CLSSNO"].ToString();
                        MANAGERID2 = dr0[0]["MANAGERID"].ToString();
                        MANAGERNAME2 = dr0[0]["MANAGERNAME"].ToString();
                        //PARENTID = dr[0]["PARENTID"].ToString();
                        //PARENTNAME = dr[0]["PARENTNAME"].ToString();
                        //PASWRD = dr[0]["PASWRD"].ToString();


                    }
                    Con.Close();
                    Con.Open();
                    //
                    DataTable tab1 = new DataTable();
                    OracleDataAdapter da1 = new OracleDataAdapter("select * from MADCAP.A_VGET_EMP_DATA where EMPNO=" + ID0 + " ", Con);
                    da1.Fill(tab1);
                    DataRow[] dr1 = tab1.Select("EMPNO=" + ID0 + "");
                    if (dr1.Count() > 0)
                    {
                        var birthdate = dr1[0]["BIRTHDATE"].ToString() == "" ? "1442-01-01" : dr1[0]["BIRTHDATE"].ToString();
                        var hiringdate = dr1[0]["FAPPLDAT"].ToString() == "" ? "1442-01-01" : dr1[0]["FAPPLDAT"].ToString();
                        var lastupgradingdate = dr1[0]["CLASS_DATE"].ToString() == "" ? "14430101" : dr1[0]["CLASS_DATE"].ToString();
                        //var grade = dr1[0]["GRADE"].ToString();
                        NIDNO = dr1[0]["NIDNO"].ToString();
                        classe = dr1[0]["CLSSNO"].ToString();
                        grade = dr1[0]["GRADE"].ToString();
                        mobileno = dr1[0]["MOBILE_NO"].ToString();
                        role = dr1[0]["MANAGER"].ToString() == "1" ? "2" : "3";
                        gender = dr1[0]["SEX"].ToString() == "1" ? "ذكر" : "أنثي";
                        var date0 = Convert.ToDateTime(birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2));
                        var date = Convert.ToDateTime(hiringdate.Substring(0, 4) + "-" + hiringdate.Substring(4, 2) + "-" + hiringdate.Substring(6, 2));
                        var date1 = Convert.ToDateTime(lastupgradingdate.Substring(0, 4) + "-" + lastupgradingdate.Substring(4, 2) + "-" + lastupgradingdate.Substring(6, 2));

                        //date.ToString("dd/MM - MMMM d"); // 28/06 - June 28
                        //date.ToString("dd/MM/yyyy"); // 28/06/2013
                        datebirth = date0.ToString("yyyy-MM-dd");
                        datehiring = date.ToString("yyyy-MM-dd");
                        datelastupgrading = date1.ToString("yyyy-MM-dd");

                    }

                    Con.Close();
                    Con.Dispose();


                    cemp = _context.Cemps.Where(z => z.Cempid == x).FirstOrDefault();
                    cemp.Cempid = cemp.Cempid;
                    cemp.CEMPNAME = EMPNAME;
                    cemp.CEMPJOBNAME = JOBNAME;
                    cemp.CEMPPASSWRD = NIDNO;
                    //cemp0.CEMPPASSWRD1 = password;
                    cemp.CLSSNO = CLSSNO;
                    cemp.grade = grade;
                    cemp.mobileno = mobileno;
                    //cemp0.mail = userPrincipalName;
                    cemp.MANAGERNAME = MANAGERNAME;
                    cemp.CEMPADPRTNO = ADPRTNO;
                    cemp.DEP_NAME = DEP_NAME;
                    cemp.MANAGERID = MANAGERID;
                    cemp.MANAGERID2id = MANAGERID2;
                    cemp.MANAGERID2 = MANAGERNAME2;
                    cemp.MANAGERNAME = MANAGERNAME;
                    cemp.PARENTID = PARENTID;
                    cemp.PARENTNAME = PARENTNAME;
                    cemp.Cemphiringdate = checkin;
                    cemp.Cemplastupgrade = checkout;
                    cemp.CEMPHIRINGDATEHIJRA = Convert.ToDateTime(datehiring);
                    cemp.CEMPLASTUPGRADEHIJRA = Convert.ToDateTime(datelastupgrading);
                    //objuser.CROLEID = objuser.CROLEID == 2 ? Convert.ToInt32(role) : objuser.CROLEID == 3 ? Convert.ToInt32(role) : objuser.CROLEID == 5 ? 5 : objuser.CROLEID == 7 ? 7 : objuser.CROLEID == 1 ? 1 : 3;
                    cemp.gender = gender;
                    cemp.CEMPBIRTHDATEHIJRA = Convert.ToDateTime(datebirth);
                    //cemp.CLSSNO = cemp.Cempid;
                    //cemp.MANAGERID = cemp.Cempid;
                    //cemp.MANAGERNAME = cemp.Cempid;
                    //cemp.PARENTID = cemp.Cempid;
                    //cemp.PARENTNAME = cemp.Cempid;
                    //cemp.login = '0';
                    //cemp.mobileno = cemp.Cempid;
                    //cemp.mail = cemp.Cempid;
                    //cemp.MANAGERID2 = cemp.Cempid;
                    //cemp.MANAGERID2id = cemp.Cempid;
                    //cemp.MANAGERNAME = cemp.Cempid;
                    //cemp.CEMPHIRINGDATEHIJRA = DateTime.Now.Date;
                    //cemp.Cemphiringdate = DateTime.Now;
                    //cemp.CEMPLASTUPGRADEHIJRA = DateTime.Now.Date;
                    //cemp.Cemplastupgrade = DateTime.Now;
                    //cemp.CROLEID = 3;
                    //cemp.imagepath = " ";
                    //cemp.cbrowser = " ";
                    //cemp.cip = " ";
                    //cemp.grade = " ";
                    //cemp.CEMPPASSWRD1 = " ";
                    _context.Update(cemp);
                    await _context.SaveChangesAsync();
                }

               
               
                return RedirectToAction(nameof(Index));
            }
            return View(cemp);
        }
        // update role in table 
        public IActionResult Role()
        {
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname");
            ViewData["Cemprole"] = new SelectList(_context.roless, "Id", "Roles");

            return View();
        }

        // POST: Cemps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Role([Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (ModelState.IsValid)
            {
                var cempss = _context.Cemps.Where(b => b.Cempid == cemp.Cempid).FirstOrDefault();

                //MasterRequestTypeIdsMasterRequestTypeIdserial = MasterRequestTypeIdsMasterRequestTypeIdserial2.MasterRequestTypeIdsMasterRequestTypeIdserial,

                cempss.Cempid = cemp.Cempid;
                cempss.CROLEID = cemp.CROLEID;
                
                _context.Update(cempss);
                //_context.Add(cemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cemp);
        }
        //role 1
         [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Role1(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "Cempname",cemp.Cempid);
            ViewData["Cemprole"] = new SelectList(_context.roless, "Id", "Roles");
            if (cemp == null)
            {
                return NotFound();
            }
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Role1(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.Cempid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cemp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CempExists(cemp.Cempid))
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
            return View(cemp);
        }
        [Authorize(Roles = "Admin")]
        // GET: Cemps/Edit/5
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
            if (id == null)
            {
                return NotFound();
            }

            var cemp = await _context.Cemps.FindAsync(id);
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.Cempid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();

                 

                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    emp2.Cempid = cemp.Cempid;
                    emp2.CROLEID = cemp.CROLEID;
                    
                    
                    _context.Update(emp2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CempExists(cemp.Cempid))
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
            return View(cemp);
        }
        [Authorize(Roles = "Admin")]
        // edit password 
        public async Task<IActionResult> Edit1(string id)
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

            var cemp = await _context.Cemps.FindAsync(id);
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID")] Cemp cemp)
        {
            if (id != cemp.Cempid)
            {
                return NotFound();
            }
            if (cemp.CEMPPASSWRD==null)
            {
                ViewBag.ErrorMessage = "ضع بيانات داخل خانة تغيير الرقم السري ";
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                    //m => m.Cempid == HttpContext.Session.GetString("username")


                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    emp2.Cempid = cemp.Cempid;
                    emp2.CEMPPASSWRD = cemp.CEMPPASSWRD;


                    _context.Update(emp2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CempExists(cemp.Cempid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyInfo));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

        }



       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public async Task<IActionResult> Edit3()
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
         

            var cemp = _context.Cemps.Where(b => b.Cempid == HttpContext.Session.GetString("username")).FirstOrDefault();
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            ViewData["Cempid"] = new SelectList(_context.Cemps, "Cempid", "CEMPNAME");
            return View(cemp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public async Task<IActionResult> Edit3(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,grade,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,CEMPHIRINGDATEHIJRA,Cemplastupgrade,PARENTNAME,CROLEID,imagepath,Fileimagepath")] Cemp cemp)
        {
            //if (id != cemp.CEMPNAME)
            //{
            //    return NotFound();
            //}
            string extension = Path.GetExtension(cemp.Fileimagepath.FileName);
            if (ModelState.IsValid)
            {
                try
                {
                    var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                    var emp22 = _context.Cemps.Where(b => b.Cempid == cemp.Cempid).FirstOrDefault();
                    if (cemp.Fileimagepath != null && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jfif" || extension == ".pdf"))
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\empsd");
                        string fullPath = Path.Combine(uploads, DateTime.Now.ToString("ddMMMyyhhmmsstt") + cemp.Fileimagepath.FileName);
                        cemp.Fileimagepath.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "*يرجي  ارفاق القرار (jpeg, jpg, png, gif, jfif,pdf)!";
                        return View(emp2);
                    }

                        TransferProcess TransferProcess = new TransferProcess
                    {
                        Olddepid=Convert.ToInt32(emp2.CEMPADPRTNO),
                        Olddepname=emp2.DEP_NAME,
                        Manageolddepid=Convert.ToInt32(emp2.MANAGERID),
                        Manageroldname=emp2.MANAGERNAME,
                        Newdepid=Convert.ToInt32(emp22.CEMPADPRTNO),
                        Newdepname=emp22.DEP_NAME,
                        Managernewid=Convert.ToInt32( emp22.MANAGERID),
                        Managernewname=emp22.MANAGERNAME,
                        Daterequest=DateTime.Now,
                        fromr= HttpContext.Session.GetString("username"),
                        //
                        decisionid=cemp.grade,
                        decisiondate= cemp.CEMPHIRINGDATEHIJRA,
                        decisionpath= DateTime.Now.ToString("ddMMMyyhhmmsstt") + cemp.Fileimagepath.FileName

                        };

                    _context.Add(TransferProcess);
                    _context.SaveChanges();

                    TransferDetail transferDetail = new TransferDetail
                    {
                        CourcesIdoffered= _context.TransferProcesss.Max(u => u.Id),
                        OfferedRequestFrom= HttpContext.Session.GetString("username"),
                        OfferedRequestTo= emp2.MANAGERID,
                        OfferedRequestTo2=emp22.MANAGERID,
                        OfferedRequestTo3="0",
                        OfferedRequestTo4 = "1",
                        OfferedRequestTo5 = "1",
                        OfferedRequestTypeSatus=0,
                        OfferedRequestNotes="",
                        Offeredoption= "4321031"



                    };
                    _context.Add(transferDetail);
                    TransferRequestTypeId transferRequestTypeId = new TransferRequestTypeId
                    {
                        CourcesIdoffered= _context.TransferProcesss.Max(u => u.Id),
                        Offercoursefrom= HttpContext.Session.GetString("username"),
                        OfferedRequestType=0

                    };
                    _context.Add(transferRequestTypeId);


                    _context.SaveChanges();

                    //m => m.Cempid == HttpContext.Session.GetString("username")


                    //emp2.CEMPNAME = cemp.CEMPNAME;
                    //emp2.Cempid = cemp.Cempid;
                    //emp2.CEMPPASSWRD = cemp.CEMPPASSWRD;


                    //_context.Update(emp2);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CempExists(cemp.Cempid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Search1));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

        }




       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        // edit image 
        public async Task<IActionResult> Edit2()
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
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var cemp = await _context.Cemps.FindAsync(HttpContext.Session.GetString("username"));
            if (cemp == null)
            {
                return NotFound();
            }
            ViewData["rolec"] = new SelectList(_context.roless, "roleid", "rolename");
            return View(cemp);
        }

        // POST: Cemps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(string id, [Bind("Cempid,CEMPUSERNO,CEMPPASSWRD,CEMPNO,CEMPNAME,CEMPJOBNAME,CEMPADPRTNO,DEP_NAME,CLSSNO,MANAGERID,MANAGERNAME,PARENTID,Cemphiringdate,Cemplastupgrade,PARENTNAME,CROLEID,imagepath,Fileimagepath")] Cemp cemp)
        {
            string extension = Path.GetExtension(cemp.Fileimagepath.FileName);
            //if (id != cemp.Cempid)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                if (cemp.Fileimagepath!= null&&(extension== ".jpeg" || extension == ".jpg" || extension == ".png" ||extension == ".gif"||extension== ".jfif"))
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\emps");
                    string fullPath = Path.Combine(uploads, DateTime.Now.ToString("ddMMMyyhhmmsstt")+cemp.Fileimagepath.FileName);
                    cemp.Fileimagepath.CopyTo(new FileStream(fullPath, FileMode.Create));
                    try
                    {
                        var emp2 = _context.Cemps.Where(b => b.CEMPNAME == cemp.CEMPNAME).FirstOrDefault();
                        //m => m.Cempid == HttpContext.Session.GetString("username")


                        //emp2.CEMPNAME = cemp.CEMPNAME;
                        emp2.Cempid = cemp.Cempid;
                        emp2.imagepath = DateTime.Now.ToString("ddMMMyyhhmmsstt") + cemp.Fileimagepath.FileName;


                        _context.Update(emp2);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CempExists(cemp.Cempid))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    ViewBag.ErrorMessage1 = "يرجي رفع الصورة(jpeg,jpg,png,gif,JFIF) !";
                    //return RedirectToAction(nameof(MyInfo));
                    //ModelState.AddModelError("uploadError", "يرجي رفع الصورة");
                    //return Content("<script language='javascript' type='text/javascript'>alert('يرجي رفع الصورة!');</script>");
                }
                
                return RedirectToAction(nameof(MyInfo));
                //return RedirectToAction("MyInfo", "Cemps", new { area = "" });
            }
            return View(cemp);

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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                           from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where f.OfferedRequestFrom== HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> approveduserm()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

        public async Task<IActionResult> canceluserm()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

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


            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0




                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);


        }

        public ActionResult IndexOffered4()
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


            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 0
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "0") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "0") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "0")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 0
                          //where e.Fromr== HttpContext.Session.GetString("empid")




                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);


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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "1") && (f.OfferedRequestFrom == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "1")
                          where f.OfferedRequestTypeSatus == 1
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

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

            List<TransferProcess> TransferProcess = _context.TransferProcesss.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<TransferDetail> TransferDetails = _context.TransferDetails.ToList();
            List<TransferRequestTypeId> TransferRequestTypeIds = _context.TransferRequestTypeIds.ToList();
            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in TransferProcess
                          join d in cemps on e.fromr equals d.Cempid into table1
                          from d in table1.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in TransferDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid") && f.OfferedRequestTo3 == "2") || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && f.OfferedRequestTo4 == "2") || (f.Offeredoption == HttpContext.Session.GetString("empid") && f.OfferedRequestTo5 == "2")

                          join h in TransferRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              TransferProcess = e,
                              cemp = d,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              TransferDetail = f,
                              TransferRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }


        public async Task<IActionResult> approveduser11()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (f.Offeredoption == HttpContext.Session.GetString("empid"))
                          where f.OfferedRequestTypeSatus == 1
                          //where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 1



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }
        public async Task<IActionResult> canceluser11()
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

            List<MessagesProcess> MessagesProcess = _context.MessagesProcesss.ToList();
            List<MessagesDetail> MessagesDetails = _context.MessagesDetailss.ToList();
            List<MessagesRequestTypeId> MessagesRequestTypeIds = _context.MessagesRequestTypeIds.ToList();
            List<Cemp> cemps = _context.Cemps.ToList();
            List<AEvaluationCompetenciesM> AEvaluationCompetenciesMs = _context.AEvaluationCompetenciesMs.ToList();
            List<AEvaluationCompetenciesD> AEvaluationCompetenciesDs = _context.AEvaluationCompetenciesDs.ToList();
            List<ACourcesMaster> aCourcesMasters = _context.ACourcesMasters.ToList();

            //List<Evalcomment> evalcommentss = _context.EvalComments.ToList();


            var Records = from e in MessagesProcess
                          join d in cemps on e.Fromr equals d.Cempid into table1
                          from d in table1.ToList()
                          join dd in aCourcesMasters on e.mestypereqid equals dd.CourcesIdmaster into table111
                          from dd in table111.ToList()
                              //join i in AEvaluationCompetenciesMs on e.Idd equals i.CovenantId into table2
                              //from i in table2.ToList() /*where i.Cempid== HttpContext.Session.GetString("empid")*/
                              //join j in AEvaluationCompetenciesDs on e.Idd equals j.CovenantId into table3
                              //from j in table3.ToList()
                          join f in MessagesDetails on e.Id equals f.CourcesIdoffered into table4
                          from f in table4.ToList()
                          where f.OfferedRequestTypeSatus == 2
                          //where f.OfferedRequestFrom == HttpContext.Session.GetString("username")
                          where (f.OfferedRequestTo == HttpContext.Session.GetString("empid")) || (f.OfferedRequestTo2 == HttpContext.Session.GetString("empid")) || (f.Offeredoption == HttpContext.Session.GetString("empid"))

                          join h in MessagesRequestTypeIds on e.Id equals h.CourcesIdoffered into table5
                          from h in table5.ToList()
                          where h.OfferedRequestType == 2



                          select new ViewModelTransferwithother
                          {
                              MessagesProcess = e,
                              cemp = d,
                              ACourcesMaster=dd,
                              //AEvaluationCompetenciesM = i,
                              //AEvaluationCompetenciesD = j,
                              MessagesDetail = f,
                              MessagesRequestTypeId = h,

                          };
            return View(Records);

            //return View(await _context.ViewModelEvalwithother.ToListAsync());
        }

        // GET: Cemps/Delete/5
        public async Task<IActionResult> Delete(string id)
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

            var cemp = await _context.Cemps
                .FirstOrDefaultAsync(m => m.Cempid == id);
            if (cemp == null)
            {
                return NotFound();
            }

            return View(cemp);
        }

        // POST: Cemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cemp = await _context.Cemps.FindAsync(id);
            _context.Cemps.Remove(cemp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CempExists(string id)
        {
            return _context.Cemps.Any(e => e.Cempid == id);
        }
    }
}
