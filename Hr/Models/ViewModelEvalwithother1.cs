using Hr.Models;
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
    public class ViewModelEvalwithother1
    {

        //public AEvaluEmpType AEvaluEmpType { get; set; }
        //public AEvaluationGoal AEvaluationGoal { get; set; }
        //public AEvaluationEmpLog AEvaluationEmpLog { get; set; }
        //public AEvaluationEmp AEvaluationEmp { get; set; }
        //public AEvaluationCompetenciesM AEvaluationCompetenciesM { get; set; }
        //public AEvaluationCompetenciesD AEvaluationCompetenciesD { get; set; }

        public int? AEvaluEmpTypeId { get; set; }
        public string AEvaluEmpTypeName { get; set; }

        // Goals

        public int? AEvaluationGoalEmpId { get; set; }
        public string AEvaluationGoalEmpType { get; set; }
        public int? AEvaluationGoalCovenantGoalsSeq { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantGoalsName1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantGoalsName2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantGoalsName3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantGoalsName4 { get; set; }
        public string AEvaluationGoalCovenantGoalsName5 { get; set; }
        public string AEvaluationGoalCovenantGoalsName6 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantMeasurementCriteria1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantMeasurementCriteria2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantMeasurementCriteria3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationGoalCovenantMeasurementCriteria4 { get; set; }
        public string AEvaluationGoalCovenantMeasurementCriteria5 { get; set; }
        public string AEvaluationGoalCovenantMeasurementCriteria6 { get; set; }

        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantPercentageWeight1 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantPercentageWeight2 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantPercentageWeight3 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantPercentageWeight4 { get; set; }
        public int? AEvaluationGoalCovenantPercentageWeight5 { get; set; }
        public int? AEvaluationGoalCovenantPercentageWeight6 { get; set; }
        public int? AEvaluationGoalCovenantPercentageWeight7 { get; set; }

        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantTargetedOutput1 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantTargetedOutput2 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantTargetedOutput3 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationGoalCovenantTargetedOutput4 { get; set; }
        public int? AEvaluationGoalCovenantTargetedOutput5 { get; set; }
        public int? AEvaluationGoalCovenantTargetedOutput6 { get; set; }

        public int? AEvaluationGoalCovenantId { get; set; }
        public DateTime? AEvaluationGoalCovenantDate { get; set; }
        public int? AEvaluationGoalEvaluationActualOutput { get; set; }
        public int? AEvaluationGoalEvaluationDifferenceOutputs { get; set; }
        public int? AEvaluationGoalEvaluationResult { get; set; }
        public int? AEvaluationGoalEvaluationEquilibrium { get; set; }
        public int? AEvaluationGoalEvaluationId { get; set; }
        public DateTime? AEvaluationGoalEvaluationDate { get; set; }
        public int? AEvaluationGoalIdd { get; set; }
        public int? AEvaluationGoalEvaluationTotal { get; set; }
        public int? AEvaluationGoalCovenantWeightSum { get; set; }
        public int? AEvaluationGoalEmpIdEnter { get; set; }

        //

        public int? AEvaluationEmpLogIdd { get; set; }
        public int? AEvaluationEmpLogEmpno { get; set; }
        public string AEvaluationEmpLogEmpname { get; set; }
        public string AEvaluationEmpLogJobname { get; set; }
        public string AEvaluationEmpLogDepName { get; set; }
        public string AEvaluationEmpLogSubDepName { get; set; }
        public string AEvaluationEmpLogManagerName { get; set; }
        public DateTime? AEvaluationEmpLogCovenantDate { get; set; }
        public int? AEvaluationEmpLogCovenantId { get; set; }
        public int? AEvaluationEmpLogCovenantYear { get; set; }
        public int? AEvaluationEmpLogManagerid { get; set; }
        public int? AEvaluationEmpLogParentid { get; set; }
        public int? AEvaluationEmpLogAdprtno { get; set; }
        public string AEvaluationEmpLogNotes { get; set; }
        public int? AEvaluationEmpLogEvaEmpnoOut { get; set; }
        public string AEvaluationEmpLogEvaEmpnoNameOut { get; set; }
        public int? AEvaluationEmpLogTypeNo { get; set; }
        public string AEvaluationEmpLogOpType { get; set; }
        public DateTime? AEvaluationEmpLogDatee { get; set; }
        public int? AEvaluationEmpLogOpTypeId { get; set; }
        public string AEvaluationEmpLogEvaEmpnoNameOut1 { get; set; }
        public int? AEvaluationEmpLogEmpIdEnter { get; set; }
        public int? AEvaluationEmpLogSeq { get; set; }

        ///
        [Required(ErrorMessage = "*")]
        public int AEvaluationEmpIdd { get; set; }
        public int? AEvaluationEmpEmpno { get; set; }
        public string AEvaluationEmpEmpname { get; set; }
        public string AEvaluationEmpJobname { get; set; }
        public string AEvaluationEmpDepName { get; set; }
        public string AEvaluationEmpSubDepName { get; set; }
        public string AEvaluationEmpManagerName { get; set; }
       
        public DateTime? AEvaluationEmpCovenantDate { get; set; }
        public int? AEvaluationEmpCovenantId { get; set; }
        public int? AEvaluationEmpCovenantYear { get; set; }
        public int? AEvaluationEmpManagerid { get; set; }
        public int? AEvaluationEmpParentid { get; set; }
        public int? AEvaluationEmpAdprtno { get; set; }
        public string AEvaluationEmpNotes { get; set; }
        public int? AEvaluationEmpEvaEmpnoOut { get; set; }
        public string AEvaluationEmpEvaEmpnoNameOut { get; set; }
        public int? AEvaluationEmpTypeNo { get; set; }
        public string AEvaluationEmpEvaEmpnoNameOut1 { get; set; }
        public int? AEvaluationEmpEmpIdEnter { get; set; }

        //
        public int AEvaluationCompetenciesMIdd { get; set; }
        public int? AEvaluationCompetenciesMCovenantCompetenciesSeq { get; set; }
        public string AEvaluationCompetenciesMCovenantCompetencyName { get; set; }

        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight1 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight2 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight3 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight4 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight5 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight6 { get; set; }
        [Required(ErrorMessage = "*")]
        public string AEvaluationCompetenciesMCovenantWeight7 { get; set; }
        

        public int? AEvaluationCompetenciesMEmpId { get; set; }
        public int? AEvaluationCompetenciesMCovenantWeightSum { get; set; }
        public int? AEvaluationCompetenciesMCovenantId { get; set; }

        //

        public int AEvaluationCompetenciesDIdd { get; set; }
        public int? AEvaluationCompetenciesDEmpId { get; set; }
        public int? AEvaluationCompetenciesDCovenantCompetenciesDSeq { get; set; }
        public string AEvaluationCompetenciesDCovenantCompetenciesDDesc { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel1 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel2 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel3 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel4 { get; set; }

        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel5 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel6 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel7 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel8 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel9 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel10 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel11 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel12 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel13 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel14 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel15 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel16 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel17 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel18 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel19 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel20 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel21 { get; set; }
        [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel22 { get; set; }
         [Required(ErrorMessage = "*")]
        public int? AEvaluationCompetenciesDCovenantCompetenciecDLevel23 { get; set; }

        public int? AEvaluationCompetenciesDEvaluationOutputCompetency { get; set; }
        public int? AEvaluationCompetenciesDEvaluationResults { get; set; }
        public int? AEvaluationCompetenciesDEvaluationTotal { get; set; }
        public int? AEvaluationCompetenciesDCovenantCompetenciesDSeqD { get; set; }
        public int? AEvaluationCompetenciesDCovenantId { get; set; }
        //

    }
}
