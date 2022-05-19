using AutoMapper;
using Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AGoalsLogs, LogModels>();
            CreateMap<LogModels, AGoalsLogs>();
        }
    }
}
