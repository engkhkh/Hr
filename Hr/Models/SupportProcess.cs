using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class SupportProcess
    {
        public int Id { get; set; }
        public string Fromr { get; set; }
        public string Mestypereqidp { get; set; }
        public string Mestypetopic { get; set; }
        public string Redesc { get; set; }
        public DateTime Daterequest { get; set; }
        [NotMapped]

        //[Required(ErrorMessage = "ارفق الشهادة  ")]
        public IFormFile Filecer { get; set; }
        
    }
}
