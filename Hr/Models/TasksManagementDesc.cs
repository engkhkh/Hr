using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class TasksManagementDesc
    {

        public int TaskMSerial{get; set; }
        public string TaskM1 { get; set; }
        public string TaskM2 { get; set; }
        public string TaskM3 { get; set; }
        public string TaskM4 { get; set; }
        public string TaskM5 { get; set; }
        public string TaskM6 { get; set; }
        public string TaskM7 { get; set; }
        public string TaskM8 { get; set; }
        public string TaskM9 { get; set; }
        public string TaskM10{ get; set; }

    }
}
