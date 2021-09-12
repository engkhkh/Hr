using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class Evalcomment
    {
        public int id { get; set; }
        public int Offerdetailsid { get; set; }
        public string Offerapproval { get; set; }
        public string Offerdetailscomment { get; set; }
    }
}
