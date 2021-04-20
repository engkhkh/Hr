using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class MasterDetails
    {
        public int MasterDetailsSerial { get; set; }
        public int COURCES_IDMASTER { get; set; }
        public string MasterRequestFrom { get; set; }
        public string MasterRequestTo { get; set; }
        public int MasterRequestTypeSatus { get; set; }
        public string MasterRequestNotes { get; set; }
    }
}
