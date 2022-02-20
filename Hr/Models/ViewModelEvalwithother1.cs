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
        //[NotMapped]
        //public string EncryptedId { get; set; }

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
        public double? AEvaluationGoalCovenantTargetedOutput1 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationGoalCovenantTargetedOutput2 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationGoalCovenantTargetedOutput3 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationGoalCovenantTargetedOutput4 { get; set; }
        public double? AEvaluationGoalCovenantTargetedOutput5 { get; set; }
        public double? AEvaluationGoalCovenantTargetedOutput6 { get; set; }

        public int? AEvaluationGoalCovenantId { get; set; }
        public DateTime? AEvaluationGoalCovenantDate { get; set; }

        public double? AEvaluationGoalEvaluationActualOutput { get; set; }
        public double? AEvaluationGoalEvaluationActualOutput2 { get; set; }
        public double? AEvaluationGoalEvaluationActualOutput3 { get; set; }
        public double? AEvaluationGoalEvaluationActualOutput4 { get; set; }
        public double? AEvaluationGoalEvaluationActualOutput5 { get; set; }
        public double? AEvaluationGoalEvaluationActualOutput6 { get; set; }
        public double? AEvaluationGoalEvaluationDifferenceOutputs { get; set; }
        public double? AEvaluationGoalEvaluationResult { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium { get; set; }
        public int? AEvaluationGoalEvaluationId { get; set; }
        public DateTime? AEvaluationGoalEvaluationDate { get; set; }
        public int? AEvaluationGoalIdd { get; set; }
        public double? AEvaluationGoalEvaluationTotal { get; set; }
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
        //[NotMapped]
        //public string EncryptedIdd { get; set; }

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
        //public string covenreqid { get; set; }
        public string commentforreq { get; set; }
        public string commentforreq2 { get; set; }
        //public string commentby { get; set; }
        //public DateTime datecomment { get; set; }
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
        //[Required(ErrorMessage = "*")]
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
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel1 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel2 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel3 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel4 { get; set; }

        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel5 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel6 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel7 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel8 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel9 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel10 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel11 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel12 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel13 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel14 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel15 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel16 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel17 { get; set; }
        [Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel18 { get; set; }
        //[Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel19 { get; set; }
        //[Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel20 { get; set; }
        //[Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel21 { get; set; }
        //[Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel22 { get; set; }
         //[Required(ErrorMessage = "*")]
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel23 { get; set; }

        public int? AEvaluationCompetenciesDEvaluationOutputCompetency { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults2 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationTotal { get; set; }
        //[RegularExpression(@"^\d+\.\d{0,2}$")] 
        public double? AEvaluationCompetenciesDEvaluationTotal11 { get; set; }
        public string AEvaluationCompetenciesDEvaluationTotal111 { get; set; }
        public int? AEvaluationCompetenciesDCovenantCompetenciesDSeqD { get; set; }
        public int? AEvaluationCompetenciesDCovenantId { get; set; }
        //


        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel01 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel02 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel03 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel04 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel05 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel06 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel07 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel08 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel09 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel010 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel011 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel012 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel013 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel014 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel015 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel016 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel017 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel018 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel019 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel020 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel021 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel022 { get; set; }
        public double? AEvaluationCompetenciesDCovenantCompetenciecDLevel023 { get; set; }
        //
        public double? AEvaluationGoalEvaluationResult2 { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium2 { get; set; }
        public double? AEvaluationGoalEvaluationResult3 { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium3 { get; set; }
        public double? AEvaluationGoalEvaluationResult4 { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium4 { get; set; }
        public double? AEvaluationGoalEvaluationResult5 { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium5 { get; set; }
        public double? AEvaluationGoalEvaluationResult6 { get; set; }
        public double? AEvaluationGoalEvaluationEquilibrium6 { get; set; }


        //
        public double? AEvaluationCompetenciesDEvaluationResults12 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults22 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults13 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults23 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults14 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults24 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults15 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults25 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults16 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults26 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults17 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults27 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults18 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults28 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults19 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults29 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults110 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults210 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults111 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults211 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults112 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults212 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults113 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults213 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults114 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults214 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults115 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults215 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults116 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults216 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults117 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults217 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults118 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults218 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults119 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults219 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults120 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults220 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults121 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults221 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults122 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults222 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults123 { get; set; }
        public double? AEvaluationCompetenciesDEvaluationResults223 { get; set; }
<<<<<<< HEAD

=======
       
>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4



        //
<<<<<<< HEAD
        public string FIRSTAPPROVAL { get; set; }
        public string SECONDAPPROVALID { get; set; }
        public string SECONDAPPROVAL { get; set; }
=======

>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4
    }
}
