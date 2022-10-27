using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [NotMapped]
    public class LogModels
    {
        public string requestid { get; set; }
        public string userr { get; set; }
   
    }
}
