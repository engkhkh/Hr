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
        public string CEMPPASSWRD { get; set; }
        public string CEMPNO { get; set; }
        public string CEMPNAME { get; set; }
        public string CEMPJOBNAME { get; set; }
        public string CEMPADPRTNO { get; set; }
        public string DEP_NAME { get; set; }
        public string CLSSNO { get; set; }
        public string MANAGERID { get; set; }
        public string MANAGERNAME { get; set; }
        public string PARENTID { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Cemphiringdate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CEMPHIRINGDATEHIJRA { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Cemplastupgrade { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CEMPLASTUPGRADEHIJRA { get; set; }
        public string PARENTNAME { get; set; }
        public int CROLEID { get; set; }
        public char login { get; set; }


        public string imagepath { get; set; }
        [NotMapped]
        public IFormFile Fileimagepath { get; set; }

        public virtual ICollection<ACourcesMaster> ACourcesMasters { get; set; }
    }
}
