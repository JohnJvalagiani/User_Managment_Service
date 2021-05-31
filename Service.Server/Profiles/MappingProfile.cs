using AutoMapper;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Core.Models;

namespace service.server.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AppUser, TeacherProfileDTO>();
            CreateMap<TeacherProfileDTO, AppUser>();

        }


    }
}

