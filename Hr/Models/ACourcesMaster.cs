using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class ACourcesMaster
    {
        public int CourcesIdmaster { get; set; }
        public int? CourcesId { get; set; }
        public int? CourcesIdType { get; set; }
        public int? CourcesIdDeptin { get; set; }
        public int? CourcesIdTraining { get; set; }
        public int? CourcesIdDeptout { get; set; }
        public int? CourcesIdEstimate { get; set; }
        public string? CourcesIdImagecert { get; set; }
        public string? CourcesIdImagehr { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        public DateTime CourcesStartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        public DateTime CourcesEndDate { get; set; }
        public int? CourcesNumberofdays { get; set; }
        public string CourcesPassRate { get; set; }
        public string Cempid { get; set; }
        [NotMapped]
        public IFormFile Filecer { get; set; }
        [NotMapped]
        public IFormFile Filehr { get; set; }

        public virtual Cemp Cemp { get; set; }
        public virtual ACourcesName Cources { get; set; }
    }
}
