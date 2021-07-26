using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class ACourcesPrograms
    {
        public ACourcesPrograms()
        {
            //ACourcesMasters = new HashSet<ACourcesMaster>();
        }

        public int CourcesId { get; set; }
        public string CourcesName { get; set; }

        //public virtual ICollection<ACourcesMaster> ACourcesMasters { get; set; }
    }
}
