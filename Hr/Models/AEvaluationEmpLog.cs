using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationEmpLog
    {
        public int? Idd { get; set; }
        public int? Empno { get; set; }
        public string Empname { get; set; }
        public string Jobname { get; set; }
        public string DepName { get; set; }
        public string SubDepName { get; set; }
        public string ManagerName { get; set; }
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
        public string OpType { get; set; }
        public DateTime? Datee { get; set; }
        public int? OpTypeId { get; set; }
        public string EvaEmpnoNameOut1 { get; set; }
        public int? EmpIdEnter { get; set; }
        public int? Seq { get; set; }
    }
}
