using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    
    public class members
    {
        public int id { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dateexcute { get; set; }
        public string commitedescession { get; set; }
        public string userentry { get; set; }
        public DateTime? timeentry { get; set; }
        public int? status { get; set; }


    }
}
