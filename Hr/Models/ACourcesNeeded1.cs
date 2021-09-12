using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class ACourcesNeeded1
    {

        [Required]
        public int CourcesNeededId { get; set; }

        [Required]
        public int CourcesId { get; set; }
        [Required]
        public string CourcesIdDegree { get; set; }

        [Required]
        public int CourcesIdNOOFSTUDENT { get; set; }

       

        [Required]
        public string CourcesIdSEARCHTITLE { get; set; }

        [Required]
        public string GRADUATIONTITLE { get; set; }


       

        public string ? Cempid { get; set; }

        public string ? notes { get; set; }

        public int ? available { get; set; }

   
    }
}
