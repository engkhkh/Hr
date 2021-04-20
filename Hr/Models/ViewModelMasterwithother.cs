using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [Keyless]
    public class ViewModelMasterwithother
    {
        public ACourcesType ACourcesTypes { get; set; }
        public Cemp Cemps { get; set; }
        public ACourcesEstimate ACourcesEstimates { get; set; }
        public ACourcesMaster ACourcesMasters { get; set; }
        public ACourcesDeptin ACourcesDeptins { get; set; }
        public MasterRequestTypeId MasterRequestTypeIds { get; set; }
        public MasterDetails MasterDetails { get; set; }
        public ACourcesDeptout ACourcesDeptouts { get; set; }
        public ACourcesTrainingMethod ACourcesTrainingMethods { get; set; }
        public ACourcesName ACourcesNames { get; set; }
        







    }
}
