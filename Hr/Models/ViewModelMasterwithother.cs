﻿using Microsoft.EntityFrameworkCore;
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
        public ACourcesIdManagement ACourcesIdManagement { get; set; }
        public ACoursesLocation ACoursesLocation { get; set; }
        public ACourcesName ACourcesNames { get; set; }
        public ACourcesName ACourcesNames2 { get; set; }
        public ACourcesName ACourcesNames3 { get; set; }
        public ACourcesName ACourcesNames4 { get; set; }
        public ACourcesName ACourcesNames5 { get; set; }
        public ACourcesName ACourcesNames6 { get; set; }
        public ACourcesName ACourcesNames7 { get; set; }
        public ACourcesName ACourcesNames8 { get; set; }




        public ACourcesOffered ACourcesOffered { get; set; }

        public OfferedDetails OfferedDetails { get; set; }


        public OfferedRequestTypeId OfferedRequestTypeId { get; set; }


        // offer 2

        public ACourcesOffered2 ACourcesOffered2 { get; set; }

        public OfferedDetails2 OfferedDetails2 { get; set; }


        public OfferedRequestTypeId2 OfferedRequestTypeId2 { get; set; }



        public ACourcesOffered3 ACourcesOffered3 { get; set; }

        public OfferedDetails3 OfferedDetails3 { get; set; }


        public OfferedRequestTypeId3 OfferedRequestTypeId3 { get; set; }








    }
}
