using Devart.Data.Oracle;
using Hr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
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
            var objuser = _context.Cemps.Where(b => b.Cempid == "0").FirstOrDefault();
            // saved sesssions here 
            HttpContext.Session.SetString("empid", objuser.Cempid);
            HttpContext.Session.SetString("empname", objuser.CEMPNAME);
            HttpContext.Session.SetString("empjobname", objuser.CEMPJOBNAME);
            HttpContext.Session.SetString("empdepid", objuser.CEMPADPRTNO);
            HttpContext.Session.SetString("empdepname", objuser.DEP_NAME);
            HttpContext.Session.SetString("empmanagerid", objuser.MANAGERID);
            HttpContext.Session.SetString("empmanagername", objuser.MANAGERNAME);
            // admin
            if (username != null && password != null && username.Equals("123") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                ViewData["MenuItemActive"] = "disabled";
                ViewBag.ContentCssClass = "disabled";
               
                ViewData["ContentCssClass"] = "disabled";
               


                //return View("ACourcesEstimates/Index");
                return RedirectToAction("Create11","ACourcesMasters", new { area = "" });
                //    ViewBag.Name = HttpContext.Session.GetString(SessionName);
            }
            // will approve only
            else if(username != null && password != null && username.Equals("456") && password.Equals("456"))
            {
                HttpContext.Session.SetString("username", username);
                ViewBag.ContentCssClass = "";
                return RedirectToAction("Index","ViewModelMasterwithother", new { area = "" });
            }
            // will create request and search only
            else if (username != null && password != null && username.Equals("789") && password.Equals("789"))
            {
                HttpContext.Session.SetString("username", username);
                ViewBag.ContentCssClass = "";
                return RedirectToAction("Create","ACourcesMasters", new { area = "" });
            }
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
            HttpContext.Session.Remove("username");
            return RedirectToAction("Show");
            //return RedirectToAction("Index", "Account", new { area = "" });
        }
    }
}
