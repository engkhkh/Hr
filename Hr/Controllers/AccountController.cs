using Devart.Data.Oracle;
using Hr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
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
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly hrContext _context;
      
        private readonly string _connectionString;
        public AccountController(hrContext context, IConfiguration _configuratio)
        {
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

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var objuser = _context.Cemps.Where(b => b.Cempid == username).FirstOrDefault();
            if(objuser==null)
            {
                ViewBag.error = "Invalid Account";
                return View("Show");
            }
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

            // admin
            if (username != null && password != null && username.Equals(objuser.Cempid) && password.Equals(objuser.CEMPPASSWRD))
            {
                HttpContext.Session.SetString("username", username);
                try
                {
                    objuser.Cempid = HttpContext.Session.GetString("empid");
                    objuser.login = '1';


                    _context.Update(objuser);
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



                var yy = from x in MasterRequestTypeIds
                         join n in masterdeatails on x.COURCES_IDMASTER equals n.COURCES_IDMASTER into table88
                         from n in table88.ToList().Distinct()
                         where (n.MasterRequestTo == HttpContext.Session.GetString("empid") || n.MasterRequestTo2 == HttpContext.Session.GetString("empid")) && x.MasterRequestType == 0 && n.MasterRequestTypeSatus == 0
                         select (x.COURCES_IDMASTER).ToString();
                TempData["MasterRequestTypeIds1"] = yy.ToList().Count();


                TempData["total"] = yy.ToList().Count() + xx.ToList().Count() + xx2.ToList().Count() + xx3.ToList().Count();

                //return View("ACourcesEstimates/Index");
                return RedirectToAction("MyInfo", "Cemps", new { area = "" });
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
                //ViewData["MenuItemActive"] = "";
                ViewBag.error = "Invalid Account";
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
                var objuser1 = _context.Cemps.Where(b => b.Cempid == HttpContext.Session.GetString("empid")).FirstOrDefault();
                objuser1.Cempid = HttpContext.Session.GetString("empid");
                objuser1.login = '0';


                _context.Update(objuser1);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            HttpContext.Session.Remove("username");
            return RedirectToAction("Show");
            //return RedirectToAction("Index", "Account", new { area = "" });
        }
    }
}
