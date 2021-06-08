using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class OfferedDetails
    {
        public int OfferedDetailsSerial { get; set; }
        public int COURCES_IDOffered { get; set; }
        public string OfferedRequestFrom { get; set; }
        public string OfferedRequestTo { get; set; }
        public string OfferedRequestTo2 { get; set; }
        public string OfferedRequestTo3 { get; set; }
        public string OfferedRequestTo4 { get; set; }
        public string OfferedRequestTo5 { get; set; }

        public int OfferedRequestTypeSatus { get; set; }
        public string OfferedRequestNotes { get; set; }


        public int Offeredoption { get; set; }
    }
}
