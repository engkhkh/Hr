using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationGoal1
    {

        public int Idd4 { get; set; }

        public int? EmpId { get; set; }
        public string EmpType { get; set; }
        public int? CovenantGoalsSeq { get; set; }
        public string CovenantGoalsName { get; set; }
        public string CovenantMeasurementCriteria { get; set; }
        public int? CovenantPercentageWeight { get; set; }
        public double? CovenantTargetedOutput { get; set; }
        public int? CovenantId { get; set; }
        public DateTime? CovenantDate { get; set; }
        public double? EvaluationActualOutput { get; set; }
        public double? EvaluationDifferenceOutputs { get; set; }
        public double? EvaluationResult { get; set; }
        public double? EvaluationEquilibrium { get; set; }
        public int? EvaluationId { get; set; }
        public DateTime? EvaluationDate { get; set; }
       
        public double? EvaluationTotal { get; set; }
        public int? CovenantWeightSum { get; set; }
        public int? EmpIdEnter { get; set; }
        [NotMapped]
        public string EncryptedIdd4Id { get; set; }
    }
}
