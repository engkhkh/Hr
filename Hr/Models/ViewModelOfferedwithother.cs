using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [Keyless]
    public class ViewModelOfferedwithother
    {
        public ACoursesLocation ACoursesLocation { get; set; }
        public Cemp Cemps { get; set; }
        public ACourcesIdManagement ACourcesIdManagement { get; set; }
        public ACourcesOffered ACourcesOffered { get; set; }
        public ACourcesNeeded ACourcesNeeded { get; set; }
        
        public AJobsNames AJobsNames { get; set; }
        public ACourcesPrograms ACourcesPrograms { get; set; }

        public ACourcesOffered2 ACourcesOffered2 { get; set; }
        public ACourcesOffered3 ACourcesOffered3 { get; set; }
        public ACourcesDeptin ACourcesDeptins { get; set; }
        public MasterRequestTypeId MasterRequestTypeIds { get; set; }
        public MasterDetails MasterDetails { get; set; }
        public ACourcesDeptout ACourcesDeptouts { get; set; }
        public ACourcesTrainingMethod ACourcesTrainingMethods { get; set; }
        public ACourcesName ACourcesNames { get; set; }
        public ACourcesName ACourcesNames2 { get; set; }
        public ACourcesName ACourcesNames3 { get; set; }
        public ACourcesName ACourcesNames4 { get; set; }
        public ACourcesName ACourcesNames5 { get; set; }
        public ACourcesName ACourcesNames6 { get; set; }
        public ACourcesName ACourcesNames7 { get; set; }
        public ACourcesName ACourcesNames8 { get; set; }

        public ACourcesOptions ACourcesOptions { get; set; }











    }
}
