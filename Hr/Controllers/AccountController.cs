//using Devart.Data.Oracle;
using DNTCaptcha.Core;
using Hr.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.DirectoryServices.AccountManagement;
//using System.DirectoryServices;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Globalization;
using Novell.Directory.Ldap;
using System.DirectoryServices;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace Hr.Controllers
{
    //[Authorize]
    public static class SessionExtensions
    {
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }

    //[Authorize]
    //[AllowAnonymous]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("account")]
    public class AccountController : Controller
    {
       // string TNS = "Data Source=(DESCRIPTION =" +
       //"(ADDRESS = (PROTOCOL = TCP)(HOST = 10.18.1.140)(PORT = 1521))" +
       //"(CONNECT_DATA =" +
       //"(SERVER = DEDICATED)" +
       //"(SERVICE_NAME = ORCL)));" +
       //"User Id= hr;Password=hr";
        string TNS1 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.140)(PORT=1521)))(CONNECT_DATA=(SID=qassim)));User ID=MADCAP;Password=dba1435sjg*;";
        string TNS2 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.101)(PORT=1521)))(CONNECT_DATA= (SID=QSMSYS)));User ID=MORASLAT2;Password=MORASLAT2;";
        string hader = "Data Source=QSMMPV-HADIR01;Initial Catalog=HadirDB;Integrated Security=False;User Id=erp;Password=Kh123456789$;MultipleActiveResultSets=True;";
        //string TNS3 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.13)(PORT=1521)))(CONNECT_DATA=(SID=sadad)));User ID=eservice;Password=eltizam_sjg";
        string USRNO = "1442910c";
        string EMPNAME ="test";
        string JOBNAME= "tester1";
        string ADPRTNO= "422150200";
        string DEP_NAME= "ادارة تطوير التطبيقات الالية";
        string CLSSNO;
        string MANAGERID= "4281001";
        string MANAGERID2 = "4431001";
        string MANAGERNAME= "باسل بن عبدالرحمن سليمان الحميضي";
        string MANAGERNAME2 = " test";
        string PARENTID= "422150000";
        string PARENTNAME= "الادارة العامة لتقنية المعلومات";
        string PASWRD ="00";
        string role ="3";
        string datehiring = "1442-01-01";
        string datelastupgrading = "1443-01-01";
        string NIDNO = "00000";
        DateTime checkin = DateTime.Now;
        DateTime checkout = DateTime.Now;
        string classe = "";
        string grade = "";
        string mobileno = "";

        OracleConnection Con;


        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;
        private readonly hrContext _context;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();
        //Here can be implemented checking logic from the database  
        ClaimsIdentity identity = null;
        bool isAuthenticated = false;
        //
        private static int cntAttemps = 0;

        private readonly string _connectionString;

        public AccountController(hrContext context, IConfiguration _configuratio, IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options)
        {
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
            _connectionString = _configuratio.GetConnectionString("ora");
            _context = context;
        }

       
        const string SessionName = "_Name";

       
        [Route("")]
        [Route("Show")]
        [Route("login")]
        [Route("~/")]
        //[Route("~/account/index")]
        //[Route("/account")]
        public IActionResult Show()
        {
            return View();
            //return RedirectToAction("Index", "Account", new { area = "" });
        }
        private static ILdapConnection _conn;
        private static ILdapConnection _conn2;

        public static string userPrincipalName { get; private set; }

        static ILdapConnection GetConnection(string username)
        {
            LdapConnection ldapConn = _conn as LdapConnection;

            if (ldapConn == null)
            {
                // Creating an LdapConnection instance 
                ldapConn = new LdapConnection() /*{ SecureSocketLayer = false }*/;

                //Connect function will create a socket connection to the server - Port 389 for insecure and 3269 for secure    
                //ldapConn.Connect("10.18.1.14", 389);

                ////Bind function with null user dn and password value will perform anonymous bind to LDAP server 
                //ldapConn.Bind(@"Qassim\ldap","admin@123");

                //

                // -- Code to get current address of the LDAP----  
                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
                var defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value;

                //--- Code to use the current address for the LDAP and query it for the user---                  
                DirectorySearcher dssearch = new DirectorySearcher("LDAP://" + defaultNamingContext);
                dssearch.Filter = "(sAMAccountName="+username+")";
                SearchResult sresult = dssearch.FindOne();
                //
                DirectoryEntry dsresult = sresult.GetDirectoryEntry();

                //--- Code for getting the properties of the logged in user from AD  
                //var FirstName = dsresult.Properties["givenName"][0].ToString();
                //var LastName = dsresult.Properties["sn"][0].ToString();
                //var displayName = dsresult.Properties["displayName"][0].ToString();
               
               
                //var CN= dsresult.Properties["CN"][0].ToString();
                 userPrincipalName= dsresult.Properties["userPrincipalName"][0].ToString();
            
                //var sAMAccountName = dsresult.Properties["sAMAccountName"][0].ToString();
                //var badpwdcount = dsresult.Properties["badpwdcount"][0].ToString();





                //  ldapConn.Disconnect();




            }

            return ldapConn;
        }
        [Route("AuthenticateUser")]
        public bool AuthenticateUser(string domainName, string userName, string password)
        {
            bool ret = false;

            try
            {
              
               
                DirectoryEntry de = new DirectoryEntry("LDAP://" + domainName, userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                SearchResult results = null;

                results = dsearch.FindOne();

                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
       

        public static string GetClientIPAddress(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                ip = context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
            }
            return ip;
        }
  
        [Route("login")]
        [HttpPost]
        [ValidateDNTCaptcha(
            ErrorMessage = "ضع  كمابالصورة ",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public IActionResult Login(string username, string password)
        {

            
            string domain = "qassim.gov.sa";
            
            


            string clientIp = GetClientIPAddress(HttpContext);
            var objuser = _context.Cemps.Where(b => b.Cempid == username).FirstOrDefault();
            if(objuser==null)
            {
                // savelogin time and ip 
                loginc loginc = new loginc();
                loginc.userid = username.ToString();
                loginc.dtimelogin = DateTime.Now;

                loginc.ip = clientIp.ToString();
                loginc.comment = "خطيء برقم المستخدم: "+username.ToString();
                _context.Add(loginc);
                _context.SaveChanges();
                ViewBag.error = "خطيء برقم المستخدم ";
                loggerx.Error("خطيء برقم المستخدم "+ username);
                return View("Show");
            }

         

            if (!ModelState.IsValid) // If `ValidateDNTCaptcha` fails, it will set a `ModelState.AddModelError`.
            {
                //TODO: Save data
                ViewBag.error = "غير مطابق كمابالصورة ";
                // savelogin time and ip 
                loginc loginc = new loginc();
                loginc.userid = username.ToString();
                loginc.dtimelogin = DateTime.Now;

                loginc.ip = clientIp.ToString();
                loginc.comment = "غير مطابق كمابالصورة";
                _context.Add(loginc);
                _context.SaveChanges();
               // loggerx.ErrorException("Error occured in Login controller");
                loggerx.Error("غير مطابق كمابالصورة "+ username);
                return View("Show");
            }
            
            bool d = AuthenticateUser(domain, username, password);

         

            //if (cntAttemps == 3)
            //{
            //    ViewBag.error = "باقي لك 2 محاولة  ";

            //    return View("Show");
            //}
            //if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.SumOfTwoNumbersToWords))
            //{
            //    this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please enter the security code as a number.");
            //    //ViewBag.error = "Invalid Captcha";

            //    return View("Show");
            //    //return View(nameof(Index));
            //}



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
                treeroot=x.treeroot
                //RoleName = x.tblRole.Roles
            }).ToList(); //Get the Menu details from entity and bind it in MenuModels list. 
            //ViewBag.MenuMaster = _menus;
            TempData["MenuMaster"] = JsonConvert.SerializeObject(_menus);
            //ViewData["menuemaster"] = _menus;
            //HttpContext.Session.SetComplexData("MenuMaster",_menus); //Bind the _menus list to MenuMaster session 
            // Save
            //var key = "MenuMaster";
            //var str = JsonConvert.SerializeObject(_menus);
            //HttpContext.Session.SetString("MenuMaster", str);

            //// Retrieve
            //var str2 = HttpContext.Session.GetString("MenuMaster");
            //var obj2 = JsonConvert.DeserializeObject<MenuModels>(str2);
            // Code for validating the CAPTCHA  
            //OracleConnection Con5 = new OracleConnection(TNS3);
            //Con5.Open();
            //DataTable tab5 = new DataTable();
            //OracleDataAdapter da5 = new OracleDataAdapter("select * from MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO", Con);
            //da5.Fill(tab5);

            //OracleConnection Con5 = new OracleConnection(TNS3);
            //Con5.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.CommandText = "INSERT INTO MCS_ELTEZAM.EMPLOYEEAPPRAISALINFO (NATIONALID,EMPLOYEEID,APPRAISALID,STARTDATE,ENDDATE,APPRAISALTYPECODE,TRANSACTIONTYPE,RESULT,RATINGCODE) VALUES  ('2430713111', '4431001','30' ,'17-05-1442','27-05-1443', 'AnnualPerformanceEvaluation', 'Add', '60', 1) ";
            ////cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + student.Id + ",'" + student.Name + "','" + student.Email + "'')";
            //cmd.Connection = Con5;
            //cmd.ExecuteNonQuery();
            //Con5.Close();
            // admin
            if (username != null && password != null && d==true /*username.Equals(objuser.Cempid) && password.Equals(objuser.CEMPPASSWRD)*/)
            {

                OracleConnection Con = new OracleConnection(TNS1);
                Con.Open();
                DataTable tab = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO=" + username + " ", Con);
                da.Fill(tab);
                DataRow[] dr = tab.Select("USRNO=" + username + "");
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
                OracleDataAdapter da1 = new OracleDataAdapter("select * from MADCAP.A_VGET_EMP_DATA where EMPNO=" + username + " ", Con);
                da1.Fill(tab1);
                DataRow[] dr1 = tab1.Select("EMPNO=" + username + "");
                if (dr1.Count() > 0)
                {
                    var hiringdate = dr1[0]["FAPPLDAT"].ToString()==""?"1442-01-01": dr1[0]["FAPPLDAT"].ToString();
                    var lastupgradingdate = dr1[0]["CLASS_DATE"].ToString()==""?"14430101": dr1[0]["CLASS_DATE"].ToString();
                    //var grade = dr1[0]["GRADE"].ToString();
                    NIDNO= dr1[0]["NIDNO"].ToString();
                    classe= dr1[0]["CLSSNO"].ToString();
                    grade= dr1[0]["GRADE"].ToString();
                    mobileno = dr1[0]["MOBILE_NO"].ToString();
                    role = dr1[0]["MANAGER"].ToString() == "1" ? "2" : "3";
                    var date = Convert.ToDateTime(hiringdate.Substring(0,4)+"-"+hiringdate.Substring(4,2)+"-"+hiringdate.Substring(6,2));
                    var date1 = Convert.ToDateTime(lastupgradingdate.Substring(0, 4) + "-" + lastupgradingdate.Substring(4, 2) + "-" + lastupgradingdate.Substring(6, 2));

                    //date.ToString("dd/MM - MMMM d"); // 28/06 - June 28
                    //date.ToString("dd/MM/yyyy"); // 28/06/2013
                    datehiring = date.ToString("yyyy-MM-dd");
                    datelastupgrading = date1.ToString("yyyy-MM-dd");

                }

                Con.Close();
                Con.Dispose();


                // 
                if (username == "4431001")
                {
                    SqlConnection connection = new SqlConnection(hader);
                    connection.Open();
                    DataTable tab2 = new DataTable();
                    DataTable tab3 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(" SELECT TOP 1 * FROM [HadirDB].[dbo].[Transaction]  where [EmployeeID]='2430713111' and [Type]='OUT' ORDER BY [DateTime] DESC ", connection);
                    SqlDataAdapter da3 = new SqlDataAdapter(" SELECT TOP 1 * FROM [HadirDB].[dbo].[Transaction]  where [EmployeeID]='2430713111' and [Type]='IN' ORDER BY [DateTime] DESC ", connection);
                    SqlDataAdapter da4 = new SqlDataAdapter(" SELECT * FROM [HadirDB].[dbo].[Transaction] where [EmployeeID]='2430713111'   ORDER BY [DateTime] DESC ", connection);
                    da2.Fill(tab2);
                    da3.Fill(tab3);
                    DataRow[] dr2 = tab2.Select("EmployeeID=2430713111");
                    checkout = Convert.ToDateTime(dr2[0]["DateTime"].ToString());

                    DataRow[] dr3 = tab3.Select("EmployeeID=2430713111");
                    checkin = Convert.ToDateTime(dr3[0]["DateTime"].ToString());
                    connection.Close();
                    connection.Dispose();


                }
                else
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(hader);
                        connection.Open();
                        DataTable tab2 = new DataTable();
                        DataTable tab3 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(" SELECT TOP 1 * FROM [HadirDB].[dbo].[Transaction]  where [EmployeeID]='" + username + "' and [Type]='OUT' ORDER BY [DateTime] DESC ", connection);
                        SqlDataAdapter da3 = new SqlDataAdapter(" SELECT TOP 1 * FROM [HadirDB].[dbo].[Transaction]  where [EmployeeID]='" + username + "' and [Type]='IN' ORDER BY [DateTime] DESC ", connection);
                        SqlDataAdapter da4 = new SqlDataAdapter(" SELECT * FROM [HadirDB].[dbo].[Transaction] where [EmployeeID]='" + username + "'   ORDER BY [DateTime] DESC ", connection);
                        da2.Fill(tab2);
                        da3.Fill(tab3);
                        DataRow[] dr2 = tab2.Select("EmployeeID=" + username + "");
                        checkout = Convert.ToDateTime(dr2[0]["DateTime"].ToString());

                        DataRow[] dr3 = tab3.Select("EmployeeID=" + username + "");
                        checkin = Convert.ToDateTime(dr3[0]["DateTime"].ToString());
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        loggerx.Error("حاضر لايرجع بيانات للموظف   "+username);
                    }
                   
                      
                    
                   
                }

                //
                //OracleConnection Con2 = new OracleConnection(TNS2);
                //Con2.Open();
                //DataTable tab4 = new DataTable();
                //OracleDataAdapter da5 = new OracleDataAdapter("select * from QASIM_BRANCH_MV@MOMMRA_GSERV_NEW", Con2);
                //da5.Fill(tab4);

                //
                _conn2 = GetConnection(username);
                HttpContext.Session.SetString("mail", userPrincipalName);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"authenticatedUser"),
                new Claim("Sys-Id","YES")
            };

                //var identity = new ClaimsIdentity(claims, "College Identity");

                //var userPrincipal = new ClaimsPrincipal(new[] { identity });

                //HttpContext.SignInAsync(userPrincipal);

                if (objuser.CROLEID == 1)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }, "Sys Identity");

                    isAuthenticated = true;

                }
                else if (objuser.CROLEID == 2)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Manager")
                }, "Sys Identity");

                    isAuthenticated = true;

                }
                else if (objuser.CROLEID == 3)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "User")
                }, "Sys Identity");

                    isAuthenticated = true;

                }
                else if (objuser.CROLEID == 5)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "HR-Admin")
                }, "Sys Identity");

                    isAuthenticated = true;

                }

                else if (objuser.CROLEID == 7)
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "HR-Operation")
                }, "Sys Identity");

                    isAuthenticated = true;

                }

                try
                {
                    // savelogin time and ip 
                    logind logind = new logind();
                    logind.userid = username;
                    logind.dtimelogin = DateTime.Now;
                    logind.dtimelogout = null;
                    logind.ip = clientIp.ToString();
                    logind.comment = "Sucessful Login to HR Gate By //"+username + "//" +"browser"+ Request.Headers["User-Agent"].ToString();
                    HttpContext.Session.SetString("username", username);
                    // saved sesssions here 
                    HttpContext.Session.SetString("empid", objuser.Cempid);
                    HttpContext.Session.SetString("empidpass", objuser.CEMPPASSWRD);
                    HttpContext.Session.SetString("empname", objuser.CEMPNAME);
                    HttpContext.Session.SetString("empjobname", objuser.CEMPJOBNAME);
                    HttpContext.Session.SetString("empdepid", objuser.CEMPADPRTNO);
                    HttpContext.Session.SetString("empdepname", objuser.DEP_NAME);
                    HttpContext.Session.SetString("empmanagerid", objuser.MANAGERID);
                    HttpContext.Session.SetString("empmanagerid2", objuser.MANAGERID2id);
                    HttpContext.Session.SetString("empmanagername", objuser.MANAGERNAME);
                    HttpContext.Session.SetString("manageid", objuser.PARENTID);
                    HttpContext.Session.SetString("pname", objuser.PARENTNAME);
                    HttpContext.Session.SetInt32("emprole", objuser.CROLEID);

                    objuser.Cempid = username;
                    objuser.login = '1';
                    objuser.cbrowser = Request.Headers["User-Agent"].ToString();
                    objuser.cip= clientIp.ToString(); 
                    objuser.CEMPNAME = EMPNAME;
                    objuser.CEMPJOBNAME = JOBNAME;
                    objuser.CEMPPASSWRD = NIDNO;
                    objuser.CEMPPASSWRD1 = password;
                    objuser.CLSSNO = CLSSNO;
                    objuser.grade = grade;
                    objuser.mobileno = mobileno;
                    objuser.mail = userPrincipalName;
                    objuser.MANAGERNAME = MANAGERNAME;
                    objuser.CEMPADPRTNO = ADPRTNO;
                    objuser.DEP_NAME = DEP_NAME;
                    objuser.MANAGERID = MANAGERID;
                    objuser.MANAGERID2id = MANAGERID2;
                    objuser.MANAGERID2 = MANAGERNAME2;
                    objuser.MANAGERNAME = MANAGERNAME;
                    objuser.PARENTID = PARENTID;
                    objuser.PARENTNAME = PARENTNAME;
                    objuser.Cemphiringdate = checkin;
                    objuser.Cemplastupgrade = checkout;
                    objuser.CEMPHIRINGDATEHIJRA = Convert.ToDateTime(datehiring);
                    objuser.CEMPLASTUPGRADEHIJRA = Convert.ToDateTime(datelastupgrading);
                    objuser.CROLEID = objuser.CROLEID==2?Convert.ToInt32(role):objuser.CROLEID == 3 ? Convert.ToInt32(role) : objuser.CROLEID == 5 ? 5 : objuser.CROLEID == 7 ? 7 : objuser.CROLEID == 1 ? 1 : 3;
                    
                    var reqevalfor = _context.EvalDetailss2.Where(h => h.OfferedRequestFrom == HttpContext.Session.GetString("username")).FirstOrDefault();
                    if(reqevalfor != null)
                    {
                        reqevalfor.OfferedRequestTo = MANAGERID;
                        reqevalfor.OfferedRequestTo2 = MANAGERID2;

                        _context.Update(reqevalfor);
                    }
                  
                    else
                    {
                        loggerx.Error("ليس له طلب ميثاق او تقييم  للموظف   " + username);
                    }
                    _context.Update(objuser);
                    _context.Add(logind);


                    _context.SaveChanges();

                }
                catch(Exception ex)
                {

                }
                finally
                {

                }
                TempData["user"] = HttpContext.Session.GetString("username");
                //TempData["eval2emp"] = "0";
                ViewData["MenuItemActive"] = "disabled";
                ViewBag.ContentCssClass = "disabled";


                ViewData["ContentCssClass"] = "disabled";

                List<MasterDetails> masterdeatails = _context.MasterDetailss.ToList();
                List<MasterRequestTypeId> MasterRequestTypeIds = _context.MasterRequestTypeIds.ToList();


                List<OfferedDetails> OfferedDetails = _context.OfferedDetails.ToList();

                List<OfferedRequestTypeId> OfferedRequestTypeId = _context.OfferedRequestTypeId.ToList();




                List<OfferedDetails2> OfferedDetails2 = _context.OfferedDetails2.ToList();
              
                List<OfferedRequestTypeId2> OfferedRequestTypeId2 = _context.OfferedRequestTypeId2.ToList();


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

                //Eval2 
                List<EvalDetail2> EvalDetails2 = _context.EvalDetailss2.ToList();

                List<EvalRequestTypeId2> EvalRequestTypeId2 = _context.EvalRequestTypeIds2.ToList();
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
                         where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption==HttpContext.Session.GetString("empid")&& m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                         select (e.COURCES_IDOffered).ToString();
                TempData["OfferedRequestTypeId1"] = xx.ToList().Count();
                //
                var xx2 = from e in OfferedRequestTypeId2
                         join m in OfferedDetails2 on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                         from m in table77.ToList().Distinct()
                         where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                         select (e.COURCES_IDOffered).ToString();
                TempData["OfferedRequestTypeId2"] = xx2.ToList().Count();


                //

                var xx3 = from e in OfferedRequestTypeId3
                          join m in OfferedDetails3 on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") /*|| (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0")*/ && e.OfferedRequestType == 0
                          select (e.COURCES_IDOffered).ToString();
                TempData["OfferedRequestTypeId3"] = xx3.ToList().Count();


                //

                var xx4 = from e in NeededRequestTypeId
                          join m in NeededDetails on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") || m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo3 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo4 == HttpContext.Session.GetString("empid") || m.OfferedRequestTo5 == HttpContext.Session.GetString("empid")) && e.OfferedRequestType == 0 && m.OfferedRequestTypeSatus == 0
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
                //
                var xx6 = from e in EvalRequestTypeId
                          join m in EvalDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                          select (e.CourcesIdoffered).ToString();
                TempData["OfferedRequestTypeId6"] = xx6.ToList().Count();
                //
                //

                var xx7 = from e in TransferRequestTypeIds
                          join m in TransferDetails on e.CourcesIdoffered equals m.CourcesIdoffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                          select (e.CourcesIdoffered).ToString();
                TempData["OfferedRequestTypeId7"] = xx7.ToList().Count();
                //
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
                           where hh.OfferedRequestType == 1 && m.OfferedRequestTypeSatus!=2022
                           select (e.CourcesIdoffered).ToString();
                TempData["OfferedRequestTypeId10"] = xx10.ToList().Count();




                TempData["total"] = yy.ToList().Count() + xx.ToList().Count() + xx2.ToList().Count() + xx3.ToList().Count()+ xx4.ToList().Count()+ xx5.ToList().Count()+xx6.ToList().Count()+xx7.ToList().Count()+ xx8.ToList().Count()+ xx9.ToList().Count()+ xx10.ToList().Count();


                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(principal);

                    return RedirectToAction("MyInfo", "Cemps", new { area = "" });
                }
                //return View("ACourcesEstimates/Index");
                return RedirectToAction("MyInfo", "Cemps", new { area = "" });
                //return View();
                //    ViewBag.Name = HttpContext.Session.GetString(SessionName);
            }
            //// will approve only
            //else if(username != null && password != null && username.Equals("456") && password.Equals("456"))
            //{
            //    HttpContext.Session.SetString("username", username);
            //    ViewBag.ContentCssClass = "";
            //    return RedirectToAction("Index","ViewModelMasterwithother", new { area = "" });
            //}
            //// will create request and search only
            //else if (username != null && password != null && username.Equals("789") && password.Equals("789"))
            //{
            //    HttpContext.Session.SetString("username", username);
            //    ViewBag.ContentCssClass = "";
            //    return RedirectToAction("Create","ACourcesMasters", new { area = "" });
            //}
            else
            {
                cntAttemps++;
                // savelogin time and ip 
                loginc loginc = new loginc();
                loginc.userid = username.ToString();
                loginc.dtimelogin = DateTime.Now;
              
                loginc.ip = clientIp.ToString();
                loginc.comment = "خطيْ بكلمة السر: "+password.ToString();
                _context.Add(loginc);

                _context.SaveChanges();

                //ViewData["MenuItemActive"] = "";
                ViewBag.error = "خطيء بكلمة السر";
                loggerx.Error("خطيء بكلمة السر "+ username);
                return View("Show");
                //return RedirectToAction("Index", "Account", new { area = "" });
            }



            ////List<Cemp> studentList = new List<Cemp>();
            //using (OracleConnection con = new OracleConnection(_connectionString) { 

            //    using (OracleCommand cmd = con.CreateCommand())
            //{
            //    con.Open();
            //    cmd.CommandText = "Select ID, FirstName,LastName,EmailId,Mobile,Course from Student";
            //    OracleDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        //Student stu = new Student
            //        //{
            //        //    Id = Convert.ToInt32(rdr["Id"]),
            //        //    Name = rdr["Name"].ToString(),
            //        //    Email = rdr["Email"].ToString()
            //        //};
            //        //studentList.Add(stu);
            //    }
            //}
            //return studentList;
        }






        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                var result = _context.logind.Where(t => t.userid == HttpContext.Session.GetString("empid")).OrderByDescending(t => t.dtimelogin).First();
             


                var objuser1 = _context.Cemps.Where(b => b.Cempid == HttpContext.Session.GetString("empid")).FirstOrDefault();
                objuser1.Cempid = HttpContext.Session.GetString("empid");
                objuser1.login = '0';
                ///////////
                result.userid= HttpContext.Session.GetString("empid");
                result.dtimelogout = DateTime.Now;


                _context.Update(objuser1);
                _context.Update(result);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            HttpContext.Session.Remove("username");
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignOutAsync("Sys-Id");
           
            return RedirectToAction("Show");
            //return RedirectToAction("Index", "Account", new { area = "" });
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
