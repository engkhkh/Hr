using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hr.Models
{
    public partial class TransferProcess
    {
        public int Id { get; set; }
        public string fromr { get; set; }
        public int? Olddepid { get; set; }
        public string Olddepname { get; set; }
        public int? Newdepid { get; set; }
        public string Newdepname { get; set; }
        public int? Manageolddepid { get; set; }
        public string Manageroldname { get; set; }
        public int? Managernewid { get; set; }
        public string Managernewname { get; set; }
        public DateTime Daterequest { get; set; }
        public string decisionid { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "ادخل تاريخ القرار   ")]
        public DateTime? decisiondate { get; set; }
        public string decisionpath { get; set; }

    }
}
