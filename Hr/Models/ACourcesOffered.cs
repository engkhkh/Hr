using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class ACourcesOffered
    {

        [Required]
        public int CourcesOfferedId { get; set; }

        [Required]
        public int CourcesId { get; set; }

        [Required]
        public int CourcesIdDeptout { get; set; }

        [Required]
        public int CourcesIdLocation { get; set; }

        [Required]
        public int CourcesIdManagement { get; set; }

        [Required]
        public int CourcesIdperiodbydays { get; set; }

        [Required]
        public string CourcesIdTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CourcesStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CourcesStartDateh { get; set; }

        [Required]
        public int CourcesIdTraining { get; set; }

        public string ? Cempid { get; set; }

        public int ? Option { get; set; }



        public int ? available { get; set; }

        public string ? timefrom { get; set; }
        public string? timeto { get; set; }
    }
}
