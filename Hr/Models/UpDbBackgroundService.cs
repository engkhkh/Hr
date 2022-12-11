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
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class UpDbBackgroundService : BackgroundService
    {
        private Timer timer;
        private readonly hrContext _context;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration Configuration;
        public UpDbBackgroundService(IServiceScopeFactory serviceScopeFactory, IConfiguration _configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            Configuration = _configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //string path = "C:\\NLogErrors\\DbUpdate.txt";
                //using (StreamWriter writer = new StreamWriter(path, true))
                //{
                //    writer.WriteLine("Update Start at : " + DateTime.Now);
                //    writer.Close();
                //}
                ////string conString = this.Configuration.GetConnectionString("hr");
                ////using (SqlConnection con = new SqlConnection(conString))
                ////{

                ////    using (SqlCommand cmd = new SqlCommand())
                ////    {
                ////        cmd.CommandType = CommandType.Text;
                ////        cmd.Connection = con;
                ////        cmd.Parameters.Clear();
                ////        cmd.CommandText = "UPDATE [hr].[dbo].[CEMPS] SET [status]=@status WHERE [CEMPID] = @UserId AND [CEMPUSERNO]=@UserId2";
                ////        cmd.Parameters.AddWithValue("@status", "1");
                ////        cmd.Parameters.AddWithValue("@UserId", "4431001");
                ////        cmd.Parameters.AddWithValue("@UserId2", "4431001");
                ////        //cmd.Parameters.AddWithValue("@Status", 1);
                ////        //cmd.Parameters.AddWithValue("@CommiteDe", ViewModelEvalwithother.c10);
                ////        //cmd.Parameters.AddWithValue("@Announce", ViewModelEvalwithother.c11);
                ////        con.Open();
                ////        cmd.ExecuteNonQuery();
                ////        con.Close();
                ////    }
                ////}
                //using (var scope = _serviceScopeFactory.CreateScope())
                //{
                //    var dbcontext = scope.ServiceProvider.GetRequiredService<hrContext>();
                //    var cemps = dbcontext.Cemps;

                //    foreach (var cemps0 in cemps)
                //    {
                //        if (cemps0.Cempid == "4431001")
                //        {
                //            cemps0.Cempid = "4431001";
                //            cemps0.status = "0";
                //            dbcontext.Update(cemps0);
                //        }
                //    }
                //    dbcontext.SaveChanges();

                //}


                //using (StreamWriter writer = new StreamWriter(path, true))
                //{
                //    writer.WriteLine("Update End at : " + DateTime.Now);
                //    writer.Close();
                //}
                string path = "C:\\NLogErrors\\sample.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.Close();
                }
                await Task.Delay(60000,stoppingToken);
            }
        }


        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    timer = new Timer(checkAndRegenerateRights, null, 0, 1000);
        //    return Task.CompletedTask;
        //}

        //public Task StopAsync(CancellationToken cancellationToken) 
        //{
        //    //no stop 
        //    timer?.Change(Timeout.Infinite, 0);
        //    return Task.CompletedTask;

        //}

        //private void checkAndRegenerateRights(object state)
        //{

        //        string path = "C:\\NLogErrors\\DbUpdate.txt";
        //        using (StreamWriter writer = new StreamWriter(path, true))
        //        {
        //            writer.WriteLine("Update Start at : "+DateTime.Now);
        //            writer.Close();
        //        }
        //    //string conString = this.Configuration.GetConnectionString("hr");
        //    //using (SqlConnection con = new SqlConnection(conString))
        //    //{

        //    //    using (SqlCommand cmd = new SqlCommand())
        //    //    {
        //    //        cmd.CommandType = CommandType.Text;
        //    //        cmd.Connection = con;
        //    //        cmd.Parameters.Clear();
        //    //        cmd.CommandText = "UPDATE [hr].[dbo].[CEMPS] SET [status]=@status WHERE [CEMPID] = @UserId AND [CEMPUSERNO]=@UserId2";
        //    //        cmd.Parameters.AddWithValue("@status", "1");
        //    //        cmd.Parameters.AddWithValue("@UserId", "4431001");
        //    //        cmd.Parameters.AddWithValue("@UserId2", "4431001");
        //    //        //cmd.Parameters.AddWithValue("@Status", 1);
        //    //        //cmd.Parameters.AddWithValue("@CommiteDe", ViewModelEvalwithother.c10);
        //    //        //cmd.Parameters.AddWithValue("@Announce", ViewModelEvalwithother.c11);
        //    //        con.Open();
        //    //        cmd.ExecuteNonQuery();
        //    //        con.Close();
        //    //    }
        //    //}
        //    using (var scope = _serviceScopeFactory.CreateScope())
        //    {
        //        var dbcontext = scope.ServiceProvider.GetRequiredService<hrContext>();
        //        var cemps = dbcontext.Cemps;

        //        foreach (var cemps0 in cemps)
        //        {
        //            if (cemps0.Cempid == "4431001")
        //            {
        //                cemps0.Cempid = "4431001";
        //                cemps0.status = "0";
        //                dbcontext.Update(cemps0);
        //            }
        //        }
        //        dbcontext.SaveChanges();

        //    }


        //    using (StreamWriter writer = new StreamWriter(path, true))
        //    {
        //        writer.WriteLine("Update End at : " + DateTime.Now);
        //        writer.Close();
        //    }

        //}




    }
}
