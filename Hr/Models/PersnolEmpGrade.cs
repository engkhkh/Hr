using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes

#nullable disable

namespace Hr.Models
{
    public partial class PersnolEmpGrade
    {
        public int seriad { get; set; }
        public string empnational { get; set; }
        public string empname { get; set; }
        public string empgrade { get; set; }
<<<<<<< Updated upstream
<<<<<<< HEAD
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? empdate { get; set; }
=======
>>>>>>> 45d78e3ca66fb8f490d9ad386017ee5c2f9d479e
=======
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? empdate { get; set; }
>>>>>>> Stashed changes
    }
}
