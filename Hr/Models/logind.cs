using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class logind
    {
        public int id { get; set; }
        public String   userid { get; set; }
        public DateTime ? dtimelogin { get; set; }
        public DateTime? dtimelogout { get; set; }
        public String ? ip { get; set; }


    }
}
