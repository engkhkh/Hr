using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hr.Models
{
    public partial class TMcomment2
    {
        public int id { get; set; }
        public int Offerdetailsid { get; set; }
        public string Offerapproval { get; set; }
        public string Offerdetailscomment { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dtapproved { get; set; }
    }
}
