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

        // 
        public commite commite { get; set; }
        public IEnumerable<commite> commites { get; set; }
        public IEnumerable<members> members { get; set; }
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
    }
}
