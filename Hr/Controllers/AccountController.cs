using Devart.Data.Oracle;
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
        [Route("~/")]
        public IActionResult Show()
        {
            return View();
            //return RedirectToAction("Index", "Account", new { area = "" });
        }
        private static ILdapConnection _conn;
        private static ILdapConnection _conn2;

        static ILdapConnection GetConnection()
        {
            LdapConnection ldapConn = _conn as LdapConnection;

            if (ldapConn == null)
            {
                // Creating an LdapConnection instance 
                ldapConn = new LdapConnection() /*{ SecureSocketLayer = false }*/;

                //Connect function will create a socket connection to the server - Port 389 for insecure and 3269 for secure    
                ldapConn.Connect("10.18.1.14", 389);

                //Bind function with null user dn and password value will perform anonymous bind to LDAP server 
                ldapConn.Bind(@"Qassim\ldap","admin@123");

                //

                // -- Code to get current address of the LDAP----  
                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
                var defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value;

                //--- Code to use the current address for the LDAP and query it for the user---                  
                DirectorySearcher dssearch = new DirectorySearcher("LDAP://" + defaultNamingContext);
                dssearch.Filter = "(sAMAccountName=1442910)";
                SearchResult sresult = dssearch.FindOne();
                DirectoryEntry dsresult = sresult.GetDirectoryEntry();

                //--- Code for getting the properties of the logged in user from AD  
                var FirstName = dsresult.Properties["givenName"][0].ToString();
                var LastName = dsresult.Properties["sn"][0].ToString();
                var Email = dsresult.Properties["mail"][0].ToString();
                var Department = dsresult.Properties["department"][0].ToString();
                var Manager = dsresult.Properties["manager"][0].ToString();

                //string groupName = "1442910";
                //var groups = new HashSet<string>();
                ////CN=خليل ابراهيم لملوم سعداوي,OU=ادارة تطوير التطبيقات الألية-الادارة العامة لتقنية المعلومات,OU=الادارة العامة لتقنية المعلومات,OU=امانة منطقة القصيم,DC=qassim,DC=gov,DC=sa

                //var searchBase = string.Empty;
                //var filter = $"(&(objectClass=user)(CN=خليل ابراهيم لملوم سعداوي,OU=ادارة تطوير التطبيقات الألية-الادارة العامة لتقنية المعلومات,OU=الادارة العامة لتقنية المعلومات,OU=امانة منطقة القصيم,DC=qassim,DC=gov,DC=sa)";
                //var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
                //while (search.HasMore())
                //{
                //    var nextEntry = search.Next();
                //    groups.Add(nextEntry.Dn);
                //    var childGroups = GetChildren(string.Empty, nextEntry.Dn);
                //    foreach (var child in childGroups)
                //    {
                //        groups.Add(child);
                //    }
                //}


                //
                // Searches in the Marketing container and return all child entries
                //just below this container i.e Single level search
                //                string searchBase = "ou=development,o=acme";
                //                int searchScope = LdapConnection.ScopeBase;
                //                string searchFilter = "(title=engineer)";
                //                LdapSearchQueue queue = ldapConn.Search(searchBase,
                //LdapConnection.ScopeOne, searchFilter, null, false, (LdapSearchQueue)
                //null, (LdapSearchConstraints)null);
                //                LdapMessage message;
                //                while ((message = queue.GetResponse()) != null)
                //                {
                //                    if (message is LdapSearchResult)
                //                    {
                //                        LdapEntry entry = (LdapSearchResult)message.Entry;
                //                        System.Console.Out.WriteLine("\n" + entry.Dn);
                //                        System.Console.Out.WriteLine("\tAttributes: ");

                //                        // Get the attribute set of the entry
                //                        LdapAttributeSet attributeSet = entry.GetAttributeSet();
                //                        System.Collections.IEnumerator ienum =
                //              attributeSet.GetEnumerator();

                //                        // Parse through the attribute set to get the attributes and
                //                        //the corresponding values
                //                           while (ienum.MoveNext())
                //                        {
                //                            LdapAttribute attribute = (LdapAttribute)ienum.Current;
                //                            string attributeName = attribute.Name;
                //                            string attributeVal = attribute.StringValue;
                //                            Console.WriteLine(attributeName + "value:" +
                //           attributeVal);
                //                        }
                //                    }
                //                }

                //Procced 

                //While all the required entries are parsed, disconnect   

                // Searches in the Marketing container and return all child entries
                //just below this container i.e.Single level search

                //LdapSearchResults lsc = (LdapSearchResults)ldapConn.Search("ou=امانة منطقة القصيم,o=*", LdapConnection.ScopeOne, "objectClass=*", null, false);
                //while (lsc.HasMore())
                //{
                //    LdapEntry nextEntry = null;
                //    try
                //    {
                //        nextEntry = lsc.Next();
                //    }
                //    catch (LdapException e)
                //    {
                //        Console.WriteLine("Error: " + e.LdapErrorMessage);
                //        //Exception is thrown, go for next entry
                //        continue;
                //    }

                //    Console.WriteLine("\n" + nextEntry.Dn);

                //    // Get the attribute set of the entry
                //    LdapAttributeSet attributeSet = nextEntry.GetAttributeSet();
                //    System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();

                //    // Parse through the attribute set to get the attributes and the
                //    //corresponding values
                //  while (ienum.MoveNext())
                //    {
                //        LdapAttribute attribute = (LdapAttribute)ienum.Current;
                //        string attributeName = attribute.Name;
                //        string attributeVal = attribute.StringValue;
                //        Console.WriteLine(attributeName + "value:" + attributeVal);
                //    }
                //}

                ////Procced 

                ////While all the entries are parsed, disconnect   
                //ldapConn.Disconnect();

                //     // Searches in the Marketing container and return all child entries
                //     string searchBase = "ou=development,o=acme";
                //     int searchScope = LdapConnection.ScopeBase;
                //     string searchFilter = "(title=engineer)";

                //     LdapSearchQueue queue = ldapConn.Search(searchBase,
                //              LdapConnection.ScopeOne, searchFilter, null, false, (LdapSearchQueue)
                //           null, (LdapSearchConstraints)null);
                //      LdapMessage message;
                //     while ((message = queue.GetResponse()) != null)
                //     {
                //         if (message is LdapSearchResult)
                //         {
                //             LdapEntry entry = (LdapSearchResult)message.Entry;
                //             System.Console.Out.WriteLine("\n" + entry.Dn);
                //             System.Console.Out.WriteLine("\tAttributes: ");

                //             // Get the attribute set of the entry
                //             LdapAttributeSet attributeSet = entry.GetAttributeSet();
                //             System.Collections.IEnumerator ienum =
                //   attributeSet.GetEnumerator();

                //             // Parse through the attribute set to get the attributes and

                //                while (ienum.MoveNext())
                //             {
                //                 LdapAttribute attribute = (LdapAttribute)ienum.Current;
                //                 string attributeName = attribute.Name;
                //                 string attributeVal = attribute.StringValue;
                //                 Console.WriteLine(attributeName + "value:" +
                //attributeVal);
                //             }
                //         }
                //     }

                //     //Procced 

                //While all the required entries are parsed, disconnect   
                ldapConn.Disconnect();


                //LdapAttributeSet attributeSet = new LdapAttributeSet();
                //attributeSet.Add(new LdapAttribute("objectclass","user"));
                //attributeSet.Add(new LdapAttribute("sAMAccountName","myuser"));
                //attributeSet.Add(new LdapAttribute("userPRincipalName", "myuser"));
                //attributeSet.Add(new LdapAttribute("userAccountControl", (66080).ToString()));
                //attributeSet.Add(new LdapAttribute("userPassword", "userPassword"));

                //string dn ="CN=myuser,CN=Users,DC=qassim,DC=gov,DC=com";
                //LdapEntry newEntry = new LdapEntry(dn, attributeSet);
                //ldapConn.Add(newEntry);

                //string groupName = "";
                //var groups = new HashSet<string>();

                //var searchBase = string.Empty;
                //var filter = $"(&(objectClass=group)(cn={groupName}))";
                //var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
                //while (search.HasMore())
                //{
                //    var nextEntry = search.Next();
                //    groups.Add(nextEntry.Dn);
                //    var childGroups = GetChildren(string.Empty, nextEntry.Dn);
                //    foreach (var child in childGroups)
                //    {
                //        groups.Add(child);
                //    }
                //}

                //var users = new HashSet<string>();

                ////string groupFilter = (groups?.Count ?? 0) > 0 ?
                ////    $"(|{string.Join("", groups.Select(x => $"(memberOf={x})").ToList())})" :
                ////    string.Empty;
                //string c = "sudan";
                //string filter2 ="(&(objectClass=user)(objectCategory=person)(l=" + c.Contains(c) + ")(cn=*))";

                //var searchBase = string.Empty;
                //string filter = $"(&(objectClass=user)(objectCategory=person)(company=OU=امانة منطقة القصيم,DC=qassim,DC=gov,DC=sa))";
                //var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter2, null, false);

                //while (search.HasMore())
                //{
                //    var nextEntry = search.Next();
                //    nextEntry.GetAttributeSet();
                //    users.Add(nextEntry.Dn);
                //}


                //
                //var groups = new HashSet<string>();

                //var searchBase = string.Empty;
                //var filter = $"(&(objectClass=person)(OU=امانة منطقة القصيم,DC=qassim,DC=gov,DC=sa))";
                //var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
                //while (search.HasMore())
                //{
                //    var nextEntry = search.Next();
                //    groups.Add(nextEntry.Dn);
                //    var childGroups = GetChildren(string.Empty, nextEntry.Dn);
                //    foreach (var child in childGroups)
                //    {
                //        groups.Add(child);
                //    }
                //}

            }

            return ldapConn;
        }
        //static HashSet<string> GetChildren(string searchBase, string groupDn, string objectClass = "group")
        //{
        //    var ldapConn = GetConnection();
        //    var listNames = new HashSet<string>();

        //    var filter = $"(&(objectClass={objectClass})(memberOf={groupDn}))";
        //    var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);

        //    while (search.HasMore())
        //    {
        //        var nextEntry = search.Next();
        //        listNames.Add(nextEntry.Dn);
        //        var children = GetChildren(string.Empty, nextEntry.Dn);
        //        foreach (var child in children)
        //        {
        //            listNames.Add(child);
        //        }
        //    }

        //    return listNames;
        //}
      
        static HashSet<string> GetChildren(string searchBase, string groupDn, string objectClass = "group")
        {
            var ldapConn = GetConnection();
            var listNames = new HashSet<string>();

            var filter = $"(&(objectClass={objectClass})(memberOf={groupDn}))";
            var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);

            while (search.HasMore())
            {
                var nextEntry = search.Next();
                listNames.Add(nextEntry.Dn);
                var children = GetChildren(string.Empty, nextEntry.Dn);
                foreach (var child in children)
                {
                    listNames.Add(child);
                }
            }

            return listNames;
        }

        void SearchForUser(string company, HashSet<string> groups = null)
        {
            var ldapConn = GetConnection();
            var users = new HashSet<string>();

            string groupFilter = (groups?.Count ?? 0) > 0 ?
                $"(|{string.Join("", groups.Select(x => $"(memberOf={x})").ToList())})" :
                string.Empty;
            var searchBase = string.Empty;
            string filter = $"(&(objectClass=user)(objectCategory=person)(company={company}){groupFilter})";
            var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);

            while (search.HasMore())
            {
                var nextEntry = search.Next();
                nextEntry.GetAttributeSet();
                users.Add(nextEntry.Dn);
            }
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

            _conn2 = GetConnection();
            //SearchForUser("ou", "");

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
                loggerx.Error("خطيء برقم المستخدم ");
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
                loggerx.Error("غير مطابق كمابالصورة ");
                return View("Show");
            }
          
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


            // saved sesssions here 
            HttpContext.Session.SetString("empid", objuser.Cempid);
            HttpContext.Session.SetString("empidpass", objuser.CEMPPASSWRD);
            HttpContext.Session.SetString("empname", objuser.CEMPNAME);
            HttpContext.Session.SetString("empjobname", objuser.CEMPJOBNAME);
            HttpContext.Session.SetString("empdepid", objuser.CEMPADPRTNO);
            HttpContext.Session.SetString("empdepname", objuser.DEP_NAME);
            HttpContext.Session.SetString("empmanagerid", objuser.MANAGERID);
            HttpContext.Session.SetString("empmanagername", objuser.MANAGERNAME);
            HttpContext.Session.SetString("manageid", objuser.PARENTID);
            HttpContext.Session.SetString("pname", objuser.PARENTNAME);
            HttpContext.Session.SetInt32("emprole",objuser.CROLEID);
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
         
            // admin
            if (username != null && password != null && username.Equals(objuser.Cempid) && password.Equals(objuser.CEMPPASSWRD))
            {

                HttpContext.Session.SetString("username", username);


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
                else 
                {
                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Else")
                }, "Sys Identity");

                    isAuthenticated = true;

                }



                try
                {
                    // savelogin time and ip 
                    logind logind = new logind();
                    logind.userid = HttpContext.Session.GetString("empid");
                    logind.dtimelogin = DateTime.Now;
                    logind.dtimelogout = null;
                    logind.ip = clientIp.ToString();

                    objuser.Cempid = HttpContext.Session.GetString("empid");
                    objuser.login = '1';


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
                         where (n.MasterRequestTo == HttpContext.Session.GetString("empid") || n.MasterRequestTo2 == HttpContext.Session.GetString("empid")) && x.MasterRequestType == 0 && n.MasterRequestTypeSatus == 0
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
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                          select (e.COURCES_IDOffered).ToString();
                TempData["OfferedRequestTypeId3"] = xx3.ToList().Count();


                //

                var xx4 = from e in NeededRequestTypeId
                          join m in NeededDetails on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
                          select (e.COURCES_IDOffered).ToString();
                TempData["OfferedRequestTypeId4"] = xx4.ToList().Count();

                //
                var xx5 = from e in Needed1RequestTypeId
                          join m in Needed1Details on e.COURCES_IDOffered equals m.COURCES_IDOffered into table77
                          from m in table77.ToList().Distinct()
                          where (m.OfferedRequestTo == HttpContext.Session.GetString("empid") && m.OfferedRequestTo3 == "0") || (m.OfferedRequestTo2 == HttpContext.Session.GetString("empid") && m.OfferedRequestTo4 == "0") || (m.Offeredoption == HttpContext.Session.GetString("empid") && m.OfferedRequestTo5 == "0") && e.OfferedRequestType == 0
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
                loggerx.Error("خطيء بكلمة السر ");
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
