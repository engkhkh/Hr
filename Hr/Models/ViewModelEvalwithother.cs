using Hr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
