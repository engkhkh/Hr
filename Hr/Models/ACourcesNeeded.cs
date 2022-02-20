using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class ACourcesNeeded
    {

        [Required]
        public int CourcesNeededId { get; set; }

        [Required]
        public int CourcesId { get; set; }
        [Required]
        public string CourcesIdDescription { get; set; }

        [Required]
        public int CourcesIdDeptin { get; set; }

       

        [Required]
        public int CourcesIdManagement { get; set; }

        [Required]
        public int jobsid { get; set; }


        [Required]
        public int CourcesIdTraining { get; set; }

        public string ? Cempid { get; set; }

        public string ? notes { get; set; }

        public int ? available { get; set; }
        public string passrate { get; set; }
        public string levelt { get; set; }


    }
}
