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
        [Required]
        public int CourcesIdmaster { get; set; }
       [Required(ErrorMessage = "اختر الدورة ")]
        public int CourcesId { get; set; }
        [Required(ErrorMessage = "اختر نوع الدورة ")]
        public int CourcesIdType { get; set; }
        [Required(ErrorMessage = "اختر الادارة او القسم")]
        public int CourcesIdDeptin { get; set; }
        [Required(ErrorMessage = "اختر طريقة التدريب ")]
        public int CourcesIdTraining { get; set; }
        [Required(ErrorMessage = "اختر جهة التدريب ")]
        public int CourcesIdDeptout { get; set; }
        [Required(ErrorMessage = "اختر التقدير ")]
        public int CourcesIdEstimate { get; set; }
        //[Required]
        //[AllowHtml
         public string CourcesIdImagecert { get; set; }
        //[Required]
        public string CourcesIdImagehr { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "ادخل تاريخ البداية   ")]
        public DateTime CourcesStartDate { get; set; }
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "ادخل تاريخ النهاية    ")]
        public DateTime CourcesEndDate { get; set; }
        [Required]
        public int CourcesNumberofdays { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:P2}")]
        //[Required]
        public string CourcesPassRate { get; set; }
        public string Cempid { get; set; }
        [NotMapped]
        
       //[Required(ErrorMessage = "ارفق الشهادة  ")]
        public IFormFile  Filecer { get; set; }
        [NotMapped]
        public  IFormFile  Filehr { get; set; }

        public virtual Cemp Cemp { get; set; }
        public virtual ACourcesName Cources { get; set; }


        //public virtual MasterDetails MasterDetails { get; set; }
        //public virtual MasterRequestTypeId MasterRequestTypeId { get; set; }
<<<<<<< Updated upstream


        [NotMapped]
        public string EncryptedIdd { get; set; }

        [NotMapped]
<<<<<<< HEAD
        public string EncryptedIdd { get; set; }

        [NotMapped]
=======
>>>>>>> ce52c410987e6716070bd52aa571f39c0ecc22a4
        public double gradetocourse { get; set; }

        [NotMapped]
        public string EncryptedIdd { get; set; }

        [NotMapped]
        public double gradetocourse { get; set; }
        [NotMapped]
        public double gradetocourset { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string CourcesStartDateh { get; set; }


        [NotMapped]
        public string EncryptedIdd { get; set; }

        [NotMapped]
        public double gradetocourse { get; set; }
        [NotMapped]
        public double gradetocourset { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string CourcesStartDateh { get; set; }
=======
>>>>>>> Stashed changes


        [NotMapped]
        public string EncryptedIdd { get; set; }

        [NotMapped]
        public double gradetocourse { get; set; }
        [NotMapped]
        public double gradetocourset { get; set; }

        [NotMapped]
        public string EncryptedIdd { get; set; }

        [NotMapped]
        public double gradetocourse { get; set; }
        [NotMapped]
        public double gradetocourset { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string CourcesStartDateh { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string CourceendDateh { get; set; }


        [Required(ErrorMessage = " اختر جهة  تنفيذ التدريب ")]
        public string COURCES_EXCUTION { get; set; }

        //public List<Project> Projects { get; set; }

    }
}
