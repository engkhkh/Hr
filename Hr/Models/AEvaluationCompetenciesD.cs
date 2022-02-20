using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationCompetenciesD
    {
        public int Idd2 { get; set; }
        public int? EmpId { get; set; }
        public int? CovenantCompetenciesDSeq { get; set; }
        public string CovenantCompetenciesDDesc { get; set; }
        public double? CovenantCompetenciecDLevel { get; set; }
        public double? EvaluationOutputCompetency { get; set; }
        public double? EvaluationResults { get; set; }
        public double? EvaluationResults2 { get; set; }
        public double? EvaluationTotal { get; set; }
        public int? CovenantCompetenciesDSeqD { get; set; }
        public int? CovenantId { get; set; }
        //[NotMapped]
        //public string EncryptedCovenantId { get; set; }
    }
}
