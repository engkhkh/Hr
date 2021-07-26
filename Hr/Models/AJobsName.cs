using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class AJobsNames
    {
        public AJobsNames()
        {
            //ACourcesMasters = new HashSet<ACourcesMaster>();
        }

        public int CourcesId { get; set; }
        public string CourcesName { get; set; }

        //public virtual ICollection<ACourcesMaster> ACourcesMasters { get; set; }
    }
}
