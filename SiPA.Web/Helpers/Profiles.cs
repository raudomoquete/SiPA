using AutoMapper;
using Report.Data.Dtos;
using SiPA.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
