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
    public class ViewModelTransferwithother
    {

        public AEvaluEmpType AEvaluEmpType { get; set; }
        public AEvaluationGoal AEvaluationGoal { get; set; }
        public AEvaluationEmpLog AEvaluationEmpLog { get; set; }
        public AEvaluationEmp AEvaluationEmp { get; set; }
        public AEvaluationCompetenciesM AEvaluationCompetenciesM { get; set; }
        public AEvaluationCompetenciesD AEvaluationCompetenciesD { get; set; }
        //
        public TransferProcess TransferProcess { get; set; }
        public TransferDetail TransferDetail { get; set; }
        public TransferRequestTypeId TransferRequestTypeId { get; set; }
        public Transfercomment Transfercomment { get; set; }
        public Cemp cemp { get; set; }

        //
        public MessagesProcess MessagesProcess { get; set; }
        public MessagesDetail MessagesDetail { get; set; }
        public MessagesRequestTypeId MessagesRequestTypeId { get; set; }
        public Messagescomment Messagescomment { get; set; }
        public ACourcesMaster ACourcesMaster { get; set; }

        //
        public SupportProcess SupportProcess { get; set; }
        public SupportDetail SupportsDetail { get; set; }
        public SupportRequestTypeId SupportsRequestTypeId { get; set; }
        public Supportcomment Supportscomment { get; set; }
       


    }
}
