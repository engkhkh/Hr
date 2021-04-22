using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
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
            if (username != null && password != null && username.Equals("123") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                //return View("ACourcesEstimates/Index");
                return RedirectToAction("Index", "ACourcesEstimates", new { area = "" });
                //    ViewBag.Name = HttpContext.Session.GetString(SessionName);
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Show");
                //return RedirectToAction("Index", "Account", new { area = "" });
            }
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
