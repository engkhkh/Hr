using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationGoal
    {

        public int Idd4 { get; set; }

        public int? EmpId { get; set; }
        public string EmpType { get; set; }
        public int? CovenantGoalsSeq { get; set; }
        public string CovenantGoalsName { get; set; }
        public string CovenantMeasurementCriteria { get; set; }
        public int? CovenantPercentageWeight { get; set; }
        public int? CovenantTargetedOutput { get; set; }
        public int? CovenantId { get; set; }
        public DateTime? CovenantDate { get; set; }
        public int? EvaluationActualOutput { get; set; }
        public int? EvaluationDifferenceOutputs { get; set; }
        public int? EvaluationResult { get; set; }
        public int? EvaluationEquilibrium { get; set; }
        public int? EvaluationId { get; set; }
        public DateTime? EvaluationDate { get; set; }
       
        public int? EvaluationTotal { get; set; }
        public int? CovenantWeightSum { get; set; }
        public int? EmpIdEnter { get; set; }
    }
}
