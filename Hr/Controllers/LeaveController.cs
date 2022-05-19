using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using NLog;
using Hr.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Hr.Controllers
{
    //[Route("Leave")]
    public class LeaveController : Controller
    {
        string TNS1 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.140)(PORT=1521)))(CONNECT_DATA=(SID=qassim)));User ID=MADCAP;Password=dba1435sjg*;";
        OracleConnection Con;
        NLog.Logger loggerx = LogManager.GetCurrentClassLogger();
        private readonly hrContext _context;
        LeaveDetails objuser = new LeaveDetails();
        DataSet ds = new DataSet();
        public LeaveController(hrContext context)
        {
            _context = context;
        }
       [Authorize(Roles = "Admin,Manager,User,HR-Admin,HR-Operation")]
        public IActionResult Index()
        {
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




            OracleConnection Con = new OracleConnection(TNS1);
            Con.Open();
            DataTable tab = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("select * from MADCAP.VAC_HADER where EMPLOYEEID="+Convert.ToInt32( HttpContext.Session.GetString("username")) + "", Con);
            da.Fill(ds);
            List<LeaveDetails> userlist = new List<LeaveDetails>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                LeaveDetails uobj = new LeaveDetails();
                uobj.id = Convert.ToInt32(ds.Tables[0].Rows[i]["EMPLOYEEID"].ToString());
                var sdate = ds.Tables[0].Rows[i]["STARTDATE"].ToString();
                var edate = ds.Tables[0].Rows[i]["ENDDATE"].ToString();
                var date1 = Convert.ToDateTime(sdate.Substring(0, 4) + "-" + sdate.Substring(4, 2) + "-" + sdate.Substring(6, 2));
                var date2 = Convert.ToDateTime(edate.Substring(0, 4) + "-" + edate.Substring(4, 2) + "-" + edate.Substring(6, 2));
                uobj.start = date1.ToString("yyyy-MM-dd"); 
                uobj.end = date2.ToString("yyyy-MM-dd");
                uobj.NUMOFDAYS = ds.Tables[0].Rows[i]["VACDAYS"].ToString();
                uobj.typeid= ds.Tables[0].Rows[i]["TYPE"].ToString();
                uobj.typestring= ds.Tables[0].Rows[i]["VACTYP"].ToString();
                uobj.lastmodified= ds.Tables[0].Rows[i]["LAST_UPDATE"].ToString();
                uobj.reqid= ds.Tables[0].Rows[i]["REQUEST_ID"].ToString();
                userlist.Add(uobj);
            }
            objuser.usersinfo = userlist;

            Con.Close();
            return View(userlist);
        }
    }
}
