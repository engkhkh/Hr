using Hr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [Keyless]
    [NotMapped]
    public class ViewModelTasks
    {

        public TasksEmployee TasksEmployee { get; set; }
        public TasksEmployeeTasks TasksEmployeeTasks { get; set; }
        public TasksEmployeeGoals TasksEmployeeGoals { get; set; }
        public string CEMPNO { get; set; }
        public string CDEPNO { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CEMPManager { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CEMPManager0 { get; set; }
        //
        public Cemp cemp { get; set; }

        public TasksManagement TasksManagement0 { get; set; }
        public TasksManagementDesc TasksManagementDesc0 { get; set; }
        public TasksManagementsOutput TasksManagementsOutput0 { get; set; }
        public TasksManagementsDecision TasksManagementsDecision0 { get; set; }

        public TasksManagementGoals TasksManagementGoals0 { get; set; }

        public TasksManagementStat TasksManagementStat0 { get; set; }

        public TasksManagementTasks TasksManagementTasks0 { get; set; }
        

        public IEnumerable<TasksManagement> TasksManagement { get; set; }
        public IEnumerable<TasksManagementDesc> TasksManagementDesc { get; set; }
        public IEnumerable<TasksManagementsOutput> TasksManagementsOutput { get; set; }
        public IEnumerable<TasksManagementsDecision> TasksManagementsDecision { get; set; }
        public IEnumerable<TasksManagementTasks> TasksManagementTaskslist { get; set; }


        

        public IEnumerable<TasksManagementGoals> TasksManagementGoalslist { get; set; }

        public IEnumerable<TasksManagementStat> TasksManagementStatlist { get; set; }



        [NotMapped]

        //[Required(ErrorMessage = "ارفق   ")]
        public IFormFile Filecer { get; set; }


        public string CourcesIdImagecert { get; set; }
        public string Iddecision { get; set; }
        public string privilegedecision { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "ادخل تاريخ    ")]
        public DateTime CourcesStartDate { get; set; }

        //
        //
        public TMDetail2 evalDetail2 { get; set; }
        public TMRequestTypeId2 evalRequestTypeId2 { get; set; }
        public TMcomment2 evalcomment2 { get; set; }


    }
}
