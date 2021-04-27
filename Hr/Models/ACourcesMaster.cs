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
       [Required]
        public int CourcesId { get; set; }
        [Required]
        public int CourcesIdType { get; set; }
        [Required]
        public int CourcesIdDeptin { get; set; }
        [Required]
        public int CourcesIdTraining { get; set; }
        [Required]
        public int CourcesIdDeptout { get; set; }
        [Required]
        public int CourcesIdEstimate { get; set; }
        //[Required]
        public string CourcesIdImagecert { get; set; }
        //[Required]
        public string CourcesIdImagehr { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CourcesStartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CourcesEndDate { get; set; }
        [Required]
        public int CourcesNumberofdays { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        [Required]
        public decimal CourcesPassRate { get; set; }
        public string Cempid { get; set; }
        [NotMapped]
        public IFormFile Filecer { get; set; }
        [NotMapped]
        public IFormFile Filehr { get; set; }

        public virtual Cemp Cemp { get; set; }
        public virtual ACourcesName Cources { get; set; }
    }
}
