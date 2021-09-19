using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.Models
{
    public partial class MessagesProcess
    {
        public int Id { get; set; }
        public string Fromr { get; set; }
        public int? mestypereqid { get; set; }
        public string mestypetopic { get; set; }
       
        public string redesc { get; set; }
       
        public DateTime Daterequest { get; set; }
    }
}
