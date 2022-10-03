using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hr.Models
{
    public partial class Cemp
    {
        public Cemp()
        {
            ACourcesMasters = new HashSet<ACourcesMaster>();
        }

        public string Cempid { get; set; }
        public string CEMPUSERNO { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }


        //[Required]
        //[StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
         ErrorMessage = "Password must contain 1 + number / 1 + lowercase / 1 + uppercase / 1 + special character and range 8 - 15")]
        public string CEMPPASSWRD { get; set; }
        public string CEMPNO { get; set; }
        public string CEMPNAME { get; set; }
        public string CEMPJOBNAME { get; set; }
        public string CEMPADPRTNO { get; set; }
        public string DEP_NAME { get; set; }
        public string CLSSNO { get; set; }
        public string grade { get; set; }
        public string mobileno { get; set; }
        public string mail { get; set; }
        public string MANAGERID { get; set; }
        public string MANAGERID2id { get; set; }
        public string MANAGERID2 { get; set; }
        public string MANAGERNAME { get; set; }
        public string PARENTID { get; set; }
        public string CEMPPASSWRD1 { get; set; }
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss tt}")]
        public DateTime? Cemphiringdate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CEMPHIRINGDATEHIJRA { get; set; }
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss tt}")]
        public DateTime? Cemplastupgrade { get; set; }
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CEMPLASTUPGRADEHIJRA { get; set; }
        public string PARENTNAME { get; set; }
        public int CROLEID { get; set; }
        public char login { get; set; }
        public string cip { get; set; }
        public string cbrowser { get; set; }


        public string imagepath { get; set; }
        [NotMapped]
        public IFormFile Fileimagepath { get; set; }




     

        public virtual ICollection<ACourcesMaster> ACourcesMasters { get; set; }
    }
}
