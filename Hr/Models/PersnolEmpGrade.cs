using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hr.Models
{
    public partial class PersnolEmpGrade
    {
        public int seriad { get; set; }
        public string empnational { get; set; }
        public string empname { get; set; }
        public string empgrade { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? empdate { get; set; }
    }
}
