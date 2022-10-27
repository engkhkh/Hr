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
    public class ViewModelEvalwithother
    {

        public AEvaluEmpType AEvaluEmpType { get; set; }
        public AEvaluationGoal AEvaluationGoal { get; set; }
        public AEvaluationGoal1 AEvaluationGoal1 { get; set; }
        public AEvaluationEmpLog AEvaluationEmpLog { get; set; }
        public AEvaluationEmp AEvaluationEmp { get; set; }
        public AEvaluationCompetenciesM AEvaluationCompetenciesM { get; set; }
        public AEvaluationCompetenciesD AEvaluationCompetenciesD { get; set; }
        //
        public EvalDetail evalDetail { get; set; }
        public EvalRequestTypeId evalRequestTypeId { get; set; }
        public Evalcomment evalcomment { get; set; }

        //
        public EvalDetail2 evalDetail2 { get; set; }
        public EvalRequestTypeId2 evalRequestTypeId2 { get; set; }
        public Evalcomment2 evalcomment2 { get; set; }

        //
        public Cemp cemp { get; set; }

        // 
        public commite commite { get; set; }
        public commitez commitez { get; set; }
        public members member { get; set; }
        public membersz memberz { get; set; }
        public memberszz memberzz { get; set; }
        public IEnumerable<commite> commites { get; set; }
        public IEnumerable<members> members { get; set; }
        public IEnumerable<membersz> membersz { get; set; }
        public IEnumerable<memberszz> memberszz { get; set; }
        public IEnumerable<Cemp> cemps { get; set; }


        public string c0 { get; set; }
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string c4 { get; set; }
        public string c5 { get; set; }
        public string c6 { get; set; }
        public string? c7 { get; set; }
        public string? c8 { get; set; }
        public string c9 { get; set; }
        public string c10 { get; set; }
        public string c11 { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string c12 { get; set; }
        public string c13 { get; set; }


        
        public double gradetocourse0 { get; set; }

        public ACourcesType ACourcesTypes { get; set; }
       // public Cemp Cemps { get; set; }
        public ACourcesEstimate ACourcesEstimates { get; set; }
        public ACourcesMaster ACourcesMasters { get; set; }
        public ACourcesDeptin ACourcesDeptins { get; set; }
        public MasterRequestTypeId MasterRequestTypeIds { get; set; }
        public MasterDetails MasterDetails { get; set; }
        public ACourcesDeptout ACourcesDeptouts { get; set; }
        public ACourcesTrainingMethod ACourcesTrainingMethods { get; set; }
        public ACourcesIdManagement ACourcesIdManagement { get; set; }

        public ACourcesName ACourcesNames { get; set; }
    }
}
