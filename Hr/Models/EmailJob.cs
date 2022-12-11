using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using System.IO;
using Hr.Services;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Data.SqlClient;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class EmailJob: IJob
    {
        private readonly IMailService mailService;
        private readonly hrContext _context;
        private readonly IConfiguration Configuration;
        public EmailJob()
        {
        }
            public EmailJob(hrContext context, IMailService mailService, IConfiguration _configuration)
        {
            _context = context;
            this.mailService = mailService;
            Configuration = _configuration;
        }

        //public EmailJob(hrContext context, IHostingEnvironment hosting, IConfiguration _configuration/*, IDataProtectionProvider provider, IJsReportMVCService jsReportMVCService*/)
        //{
        //    _context = context;
        //    _hosting = hosting;
        //    //_protector = provider.CreateProtector(GetType().FullName);
        //    //JsReportMVCService = jsReportMVCService;
        //    Configuration = _configuration;

        //}

        public async void Execute(IJobExecutionContext context)
        {
            WelcomeRequest request3 = new WelcomeRequest();
            request3.UserName = "khalil";
            request3.header = "ألاداء الوظيفي وتقييم ألاداء ";
            request3.Details = "تم رفض اعتماد تقييم الأداء الوظيفي الخاص بك حسب دورة الأداء بالأمانة لعام 2021 ,طلب رقم ";
            request3.ToEmail ="khilel208@gmail.com";
            try
            {
                //await mailService.SendEmailAsync(m);
                await mailService.SendWelcomeEmailAsync(request3);
            }
            catch (Exception ex)
            {
                //loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "رفض  التقييم " + ex.Message);
            }
            //var task = Task.Run(() => logfile(DateTime.Now)); ;
            //return task;
        }
        public void logfile(DateTime time)
        {
            string path = "C:\\NLogErrors\\sample.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(time);
                writer.Close();
            }


        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            
            try
            {

                using (var message = new MailMessage("khilel208@gmail.com", "khilel208@hotmail.com"))
                {
                    message.Subject = "Test";
                    message.Body = "Test at " + DateTime.Now;
                    using (SmtpClient client = new SmtpClient
                    {
                        EnableSsl = false,
                        Host = "mail.qassim.gov.sa",
                        Port = 25,
                        Credentials = new NetworkCredential("HRService@qassim.gov.sa", "H00s%159753")
                    })
                    {
                        client.Send(message);
                    }


                }
                //string conString = this.Configuration.GetConnectionString("hr");
                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    using (SqlCommand cmd = new SqlCommand())
                //    {
                //        cmd.CommandType = CommandType.Text;
                //        cmd.Connection = con;
                //        cmd.Parameters.Clear();
                //        cmd.CommandText = "UPDATE [hr].[dbo].[CEMPS] SET [status]=@status WHERE [CEMPID] = @UserId AND [CEMPUSERNO]=@UserId2";
                //        cmd.Parameters.AddWithValue("@status", "1");
                //        cmd.Parameters.AddWithValue("@UserId", "4431001");
                //        cmd.Parameters.AddWithValue("@UserId2", "4431001");
                //        //cmd.Parameters.AddWithValue("@Status", 1);
                //        //cmd.Parameters.AddWithValue("@CommiteDe", ViewModelEvalwithother.c10);
                //        //cmd.Parameters.AddWithValue("@Announce", ViewModelEvalwithother.c11);
                //        con.Open();
                //        cmd.ExecuteNonQuery();
                //        con.Close();
                //    }
                //}


            }
            catch (Exception ex)
            {
                //loggerx.Error("  لم يتم ارسال الايميل للموظف ب خدمة تقييم الاداء   " + emprequestor.Cempid + "رفض  التقييم " + ex.Message);
            }
        }
    }
}
