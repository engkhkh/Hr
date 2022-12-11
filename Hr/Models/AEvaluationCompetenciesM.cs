using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationCompetenciesM
    {
        public int Idd1 { get; set; }
        public int? CovenantCompetenciesSeq { get; set; }
        public string CovenantCompetencyName { get; set; }
        public string CovenantWeight { get; set; }
        public int? EmpId { get; set; }
        public int? CovenantWeightSum { get; set; }
        public int? CovenantId { get; set; }
        //[NotMapped]
        //public string EncryptedCovenantId { get; set; }
    }
}
