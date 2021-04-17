using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class ACourcesCertImagehr
    {
        public int CourcesIdImagehr { get; set; }
        public int? CourcesIdmaster { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public DateTime ImageCreatedDate { get; set; }
        public string FileName1 { get; set; }
        public string Note { get; set; }
    }
}
