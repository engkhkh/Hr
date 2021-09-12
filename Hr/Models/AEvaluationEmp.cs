using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationEmp
    {
        public int Idd { get; set; }
        public int? Empno { get; set; }
        public string Empname { get; set; }
        public string Jobname { get; set; }
        public string DepName { get; set; }
        public string SubDepName { get; set; }
        public string ManagerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CovenantDate { get; set; }
        public int? CovenantId { get; set; }
        public int? CovenantYear { get; set; }
        public int? Managerid { get; set; }
        public int? Parentid { get; set; }
        public int? Adprtno { get; set; }
        public string Notes { get; set; }
        public int? EvaEmpnoOut { get; set; }
        public string EvaEmpnoNameOut { get; set; }
        public int? TypeNo { get; set; }
        public string EvaEmpnoNameOut1 { get; set; }
        public int? EmpIdEnter { get; set; }
    }
}
