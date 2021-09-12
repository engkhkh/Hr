using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class ACourcesOffered3
    {

        [Required]
        public int CourcesOfferedId { get; set; }

        [Required]
        public int CourcesId { get; set; }

        public int ? CourcesId2 { get; set; }

        public int ? CourcesId3 { get; set; }
        public int ? CourcesId4 { get; set; }
        public int ? CourcesId5 { get; set; }
        public int ? CourcesId6 { get; set; }
        public int ? CourcesId7 { get; set; }
        public int ? CourcesId8 { get; set; }

        [Required]
        public int CourcesIdDeptout { get; set; }

        //[Required]
        //public int CourcesIdLocation { get; set; }

        [Required]
        public string workdue { get; set; }

        //[Required]
        //public int CourcesIdperiodbydays { get; set; }

        //[Required]
        //public string CourcesIdTime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime CourcesStartDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CourcesStartDate1 { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate3 { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate4 { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate5 { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate6 { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate7 { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDate8 { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ? CourcesStartDateh { get; set; }

        //[Required]
        //public int CourcesIdTraining { get; set; }

        public string ? Cempid { get; set; }

        //public int ? Option { get; set; }



        //public string ? available { get; set; }

        //public string ? timefrom { get; set; }
        //public string? timeto { get; set; }

        //public string? COURCES_ID_IMAGE { get; set; }
        //[NotMapped]
        //public IFormFile Filehr { get; set; }
    }
}
