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
        public ACourcesDeptin ACourcesDeptins { get; set; }
        public MasterRequestTypeId MasterRequestTypeIds { get; set; }
        public MasterDetails MasterDetails { get; set; }
        public ACourcesDeptout ACourcesDeptouts { get; set; }
        public ACourcesTrainingMethod ACourcesTrainingMethods { get; set; }
        public ACourcesName ACourcesNames { get; set; }

        public ACourcesOptions ACourcesOptions { get; set; }











    }
}
