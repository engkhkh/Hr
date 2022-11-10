
using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using System.IO;
using Quartz.Impl;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class SchedulerTask 
    {
        private static readonly string ScheduleCronExpression = "0 * * ? * *";


        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                //var job1 = JobBuilder.Create<EmailJob>().WithIdentity("ExecuteTaskServiceCallJob1", "group1").Build();
                //var trigger1 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger1", "group1").WithCronSchedule(ScheduleCronExpression).Build();
                //  Second Task
                var job2 = JobBuilder.Create<Task2>().WithIdentity("ExecuteTaskServiceCallJob2", "group2").Build();
                var trigger2 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger2", "group2").WithCronSchedule(ScheduleCronExpression).Build();
                //await scheduler.ScheduleJob(job1, trigger1);
                await scheduler.ScheduleJob(job2, trigger2);
            }
            catch (Exception ex) {
            
            }
        }


    }
}
