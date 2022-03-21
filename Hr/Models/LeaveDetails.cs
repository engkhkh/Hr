using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [NotMapped]
    public class LeaveDetails
    {
        public int id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string NUMOFDAYS { get; set; }
        public string typeid { get; set; }
        public string typestring { get; set; }
        public string lastmodified { get; set; }
        public string reqid { get; set; }
        public List<LeaveDetails> usersinfo { get; set; }
    }
}
