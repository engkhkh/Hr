using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class Task2 : IJob
    {
        private readonly hrContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly IConfiguration Configuration;
        private string TNS11 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.140)(PORT=1521)))(CONNECT_DATA=(SID=qassim)));User ID=MADCAP;Password=dba1435sjg*;";
        private string TNS2 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.101)(PORT=1521)))(CONNECT_DATA= (SID=QSMSYS)));User ID=MORASLAT2;Password=MORASLAT2;";
        //string hader0 = "Data Source=QSMMPV-HADIR01;Initial Catalog=HadirDB;Integrated Security=False;User Id=erp;Password=Kh123456789$;MultipleActiveResultSets=True;";
        //string TNS3 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.13)(PORT=1521)))(CONNECT_DATA=(SID=sadad)));User ID=eservice;Password=eltizam_sjg";
        private string USRNO = "1442910c";
        private string EMPNAME = "test";
        private string JOBNAME = "tester1";
        private string ADPRTNO = "422150200";
        private string DEP_NAME = "ادارة تطوير التطبيقات الالية";
        private string CLSSNO;
        private string MANAGERID = "4281001";
        private string MANAGERID2 = "4431001";
        private string MANAGERNAME = "باسل بن عبدالرحمن سليمان الحميضي";
        private string MANAGERNAME2 = " test";
        private string PARENTID = "422150000";
        private string PARENTNAME = "الادارة العامة لتقنية المعلومات";
        private string PASWRD = "00";
        private string role = "3";
        private string gender = "ذكر";
        private string datebirth = "1442-01-01";
        private string datehiring = "1442-01-01";
        private string datelastupgrading = "1443-01-01";
        private string NIDNO = "00000";
        private DateTime checkin = DateTime.Now;
        private DateTime checkout = DateTime.Now;
        private string classe = "";
        private string grade = "";
        private string mobileno = "";


        
        protected string path = "C:\\NLogErrors\\sample2.txt";
        protected Cemp cemp;
        protected OracleConnection Con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.18.1.140)(PORT=1521)))(CONNECT_DATA=(SID=qassim)));User ID=MADCAP;Password=dba1435sjg*;");
        protected DataTable tab = new DataTable();
        public Task2()
        {

        }

        public Task2(hrContext context, IHostingEnvironment hosting, IConfiguration _configuration/*, IDataProtectionProvider provider, IJsReportMVCService jsReportMVCService*/)
        {
            _context = context;
            _hosting = hosting;
            //_protector = provider.CreateProtector(GetType().FullName);
            //JsReportMVCService = jsReportMVCService;
            Configuration = _configuration;

        }

        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() => logfile(DateTime.Now)); ;
            return task;
        }
        public  void logfile(DateTime time)
        {

            string path = "C:\\NLogErrors\\sample2.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(time);
                writer.Close();
            }
            // Cemp cemp0 ;


            //List<Cemp> cemps0 = _context.Cemps.ToList();
            //var ci = CultureInfo.CreateSpecificCulture("ar-SA");
            //foreach (var cemp0 in cemps0.ToList())
            //        {
            //            Con.Open();
            //            OracleDataAdapter da = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO=" + cemp0.Cempid + " ", Con);
            //            da.Fill(tab);
            //            DataRow[] dr = tab.Select("USRNO=" + cemp0.Cempid + "");
            //            if (dr.Count() > 0)
            //            {

            //                USRNO = dr[0]["USRNO"].ToString();
            //                EMPNAME = dr[0]["EMPNAME"].ToString();
            //                JOBNAME = dr[0]["JOBNAME"].ToString();
            //                ADPRTNO = dr[0]["ADPRTNO"].ToString();
            //                DEP_NAME = dr[0]["DEP_NAME"].ToString();
            //                CLSSNO = dr[0]["CLSSNO"].ToString();
            //                MANAGERID = dr[0]["MANAGERID"].ToString();
            //                MANAGERNAME = dr[0]["MANAGERNAME"].ToString();
            //                PARENTID = dr[0]["PARENTID"].ToString();
            //                PARENTNAME = dr[0]["PARENTNAME"].ToString();
            //                PASWRD = dr[0]["PASWRD"].ToString();


            //            }
            //            else
            //            {
            //                string conString = this.Configuration.GetConnectionString("hr");
            //                using (SqlConnection con = new SqlConnection(conString))
            //                {

            //                    using (SqlCommand cmd = new SqlCommand())
            //                    {
            //                        cmd.CommandType = CommandType.Text;
            //                        cmd.Connection = con;
            //                        cmd.Parameters.Clear();
            //                        cmd.CommandText = "DELETE FROM [hr].[dbo].[CEMPS] WHERE [CEMPID] = @UserId AND [CEMPUSERNO]=@UserId2";
            //                        cmd.Parameters.AddWithValue("@UserId", cemp0.Cempid);
            //                        cmd.Parameters.AddWithValue("@UserId2", cemp0.Cempid);
            //                        //cmd.Parameters.AddWithValue("@Status", 1);
            //                        //cmd.Parameters.AddWithValue("@CommiteDe", ViewModelEvalwithother.c10);
            //                        //cmd.Parameters.AddWithValue("@Announce", ViewModelEvalwithother.c11);
            //                        con.Open();
            //                        cmd.ExecuteNonQuery();
            //                        con.Close();
            //                    }
            //                }
            //                // break;
            //            }
            //            Con.Close();
            //            //
            //            Con.Open();
            //            DataTable tab0 = new DataTable();
            //            OracleDataAdapter da0 = new OracleDataAdapter("select * from MADCAP.AV_GETPASS where USRNO = " + MANAGERID + " ", Con);
            //            da0.Fill(tab0);
            //            DataRow[] dr0 = tab0.Select("USRNO=" + MANAGERID + "");
            //            if (dr0.Count() > 0)
            //            {

            //                //USRNO = dr[0]["USRNO"].ToString();
            //                //EMPNAME = dr[0]["EMPNAME"].ToString();
            //                //JOBNAME = dr[0]["JOBNAME"].ToString();
            //                //ADPRTNO = dr[0]["ADPRTNO"].ToString();
            //                //DEP_NAME = dr[0]["DEP_NAME"].ToString();
            //                //CLSSNO = dr[0]["CLSSNO"].ToString();
            //                MANAGERID2 = dr0[0]["MANAGERID"].ToString();
            //                MANAGERNAME2 = dr0[0]["MANAGERNAME"].ToString();
            //                //PARENTID = dr[0]["PARENTID"].ToString();
            //                //PARENTNAME = dr[0]["PARENTNAME"].ToString();
            //                //PASWRD = dr[0]["PASWRD"].ToString();


            //            }
            //            Con.Close();
            //            Con.Open();
            //            //
            //            DataTable tab1 = new DataTable();
            //            OracleDataAdapter da1 = new OracleDataAdapter("select * from MADCAP.A_VGET_EMP_DATA where EMPNO=" + cemp0.Cempid + " ", Con);
            //            da1.Fill(tab1);
            //            DataRow[] dr1 = tab1.Select("EMPNO=" + cemp0.Cempid + "");
            //            if (dr1.Count() > 0)
            //            {
            //                var birthdate = dr1[0]["BIRTHDATE"].ToString() == "" ? "1442-01-01" : dr1[0]["BIRTHDATE"].ToString();
            //                var hiringdate = dr1[0]["FAPPLDAT"].ToString() == "" ? "1442-01-01" : dr1[0]["FAPPLDAT"].ToString();
            //                var lastupgradingdate = dr1[0]["CLASS_DATE"].ToString() == "" ? "14430101" : dr1[0]["CLASS_DATE"].ToString();
            //                //var grade = dr1[0]["GRADE"].ToString();
            //                NIDNO = dr1[0]["NIDNO"].ToString();
            //                classe = dr1[0]["CLSSNO"].ToString();
            //                grade = dr1[0]["GRADE"].ToString();
            //                mobileno = dr1[0]["MOBILE_NO"].ToString();
            //                role = dr1[0]["MANAGER"].ToString() == "1" ? "2" : "3";
            //                gender = dr1[0]["SEX"].ToString() == "1" ? "ذكر" : "أنثي";

            //                var date00 = birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2);
            //                //var date0 = Convert.ToDateTime(birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2));
            //                var date = Convert.ToDateTime(hiringdate.Substring(0, 4) + "-" + hiringdate.Substring(4, 2) + "-" + hiringdate.Substring(6, 2));
            //                var date1 = Convert.ToDateTime(lastupgradingdate.Substring(0, 4) + "-" + lastupgradingdate.Substring(4, 2) + "-" + lastupgradingdate.Substring(6, 2));

            //                //date.ToString("dd/MM - MMMM d"); // 28/06 - June 28
            //                //date.ToString("dd/MM/yyyy"); // 28/06/2013
            //                datebirth = date00.ToString(ci);
            //                if (datebirth.Contains("1400-02-29") || datebirth.Contains("1406-02-29") || datebirth.Contains("1399-02-30") || datebirth.Contains("1395-02-29"))
            //                {

            //                    datebirth = date.ToString("yyyy-MM-dd");
            //                }
            //                //datebirth = date0.ToString("yyyy-MM-dd");
            //                datehiring = date.ToString("yyyy-MM-dd");
            //                datelastupgrading = date1.ToString("yyyy-MM-dd");

            //            }

            //            Con.Close();
            //            // Con.Dispose();


            //            cemp = _context.Cemps.Where(z => z.Cempid == cemp0.Cempid).FirstOrDefault();
            //            if (cemp != null)
            //            {
            //                cemp.Cempid = cemp.Cempid;
            //                cemp.CEMPNAME = EMPNAME;
            //                cemp.CEMPJOBNAME = JOBNAME;
            //                cemp.CEMPPASSWRD = NIDNO;
            //                //cemp0.CEMPPASSWRD1 = password;
            //                cemp.CLSSNO = CLSSNO;
            //                cemp.grade = grade;
            //                cemp.mobileno = mobileno;
            //                //cemp0.mail = userPrincipalName;
            //                cemp.MANAGERNAME = MANAGERNAME;
            //                cemp.CEMPADPRTNO = ADPRTNO;
            //                cemp.DEP_NAME = DEP_NAME;
            //                cemp.MANAGERID = MANAGERID;
            //                cemp.MANAGERID2id = MANAGERID2;
            //                cemp.MANAGERID2 = MANAGERNAME2;
            //                cemp.MANAGERNAME = MANAGERNAME;
            //                cemp.PARENTID = PARENTID;
            //                cemp.PARENTNAME = PARENTNAME;
            //                cemp.Cemphiringdate = checkin;
            //                cemp.Cemplastupgrade = checkout;
            //                cemp.CEMPHIRINGDATEHIJRA = Convert.ToDateTime(datehiring);
            //                cemp.CEMPLASTUPGRADEHIJRA = Convert.ToDateTime(datelastupgrading);
            //                //objuser.CROLEID = objuser.CROLEID == 2 ? Convert.ToInt32(role) : objuser.CROLEID == 3 ? Convert.ToInt32(role) : objuser.CROLEID == 5 ? 5 : objuser.CROLEID == 7 ? 7 : objuser.CROLEID == 1 ? 1 : 3;
            //                cemp.gender = gender;
            //                cemp.CEMPBIRTHDATEHIJRA = DateTime.Parse(datebirth, CultureInfo.InvariantCulture).Date;
            //                //cemp.CLSSNO = cemp.Cempid;
            //                //cemp.MANAGERID = cemp.Cempid;
            //                //cemp.MANAGERNAME = cemp.Cempid;
            //                //cemp.PARENTID = cemp.Cempid;
            //                //cemp.PARENTNAME = cemp.Cempid;
            //                //cemp.login = '0';
            //                //cemp.mobileno = cemp.Cempid;
            //                //cemp.mail = cemp.Cempid;
            //                //cemp.MANAGERID2 = cemp.Cempid;
            //                //cemp.MANAGERID2id = cemp.Cempid;
            //                //cemp.MANAGERNAME = cemp.Cempid;
            //                //cemp.CEMPHIRINGDATEHIJRA = DateTime.Now.Date;
            //                //cemp.Cemphiringdate = DateTime.Now;
            //                //cemp.CEMPLASTUPGRADEHIJRA = DateTime.Now.Date;
            //                //cemp.Cemplastupgrade = DateTime.Now;
            //                //cemp.CROLEID = 3;
            //                //cemp.imagepath = " ";
            //                //cemp.cbrowser = " ";
            //                //cemp.cip = " ";
            //                //cemp.grade = " ";
            //                //cemp.CEMPPASSWRD1 = " ";
            //               // writer.WriteLine(time+cemp.Cempid);
            //                //writer.Close();
            //                _context.Update(cemp);
            //                _context.SaveChanges();

            //        }

            //}


        }
    }
}
