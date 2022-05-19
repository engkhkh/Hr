using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e

#nullable disable

namespace Hr.Models
{
    public partial class PersnolEmpGrade
    {
        public int seriad { get; set; }
        public string empnational { get; set; }
        public string empname { get; set; }
        public string empgrade { get; set; }
<<<<<<< HEAD
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? empdate { get; set; }
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
    }
}
