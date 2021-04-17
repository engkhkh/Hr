using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class ACourcesMaster
    {
        public int CourcesIdmaster { get; set; }
        public int? CourcesId { get; set; }
        public int? CourcesIdType { get; set; }
        public int? CourcesIdDeptin { get; set; }
        public int? CourcesIdTraining { get; set; }
        public int? CourcesIdDeptout { get; set; }
        public int? CourcesIdEstimate { get; set; }
        public int? CourcesIdImagecert { get; set; }
        public int? CourcesIdImagehr { get; set; }
        public DateTime CourcesStartDate { get; set; }
        public DateTime CourcesEndDate { get; set; }
        public int? CourcesNumberofdays { get; set; }
        public string CourcesPassRate { get; set; }
        public string Cempid { get; set; }

        public virtual Cemp Cemp { get; set; }
        public virtual ACourcesName Cources { get; set; }
    }
}
