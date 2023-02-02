using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using System.IO;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class Task1 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() => logfile(DateTime.Now)); ;
            return task;
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
    }
}
