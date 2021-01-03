using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MotorMarket.Controllers.Resources;
using MotorMarket.Models;

namespace MotorMarket.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelResources>();
           // CreateMap<Main, MainResources>();
        }
    }
}
