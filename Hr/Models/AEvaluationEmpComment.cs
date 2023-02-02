using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class AEvaluationEmpComment
    {
        public int Id { get; set; }
        public string covenreqid { get; set; }
        public string commentforreq { get; set; }
        public string commentby { get; set; }
        public DateTime datecomment { get; set; }

    }
}
