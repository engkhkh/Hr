using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class Cemp
    {
        public Cemp()
        {
            ACourcesMasters = new HashSet<ACourcesMaster>();
        }

        public string Cempid { get; set; }
        public string Cempname { get; set; }
        public string Cempuser { get; set; }
        public string Cempidentityid { get; set; }
        public string Cempdepartment { get; set; }
        public string Cempgrade { get; set; }
        public string Cemptitle { get; set; }
        public DateTime Cemphiringdate { get; set; }
        public DateTime Cemplastupgrade { get; set; }
        public string Cempother1 { get; set; }
        public string Cempother2 { get; set; }

        public virtual ICollection<ACourcesMaster> ACourcesMasters { get; set; }
    }
}
