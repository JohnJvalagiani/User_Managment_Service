using AutoMapper;
using Dtos;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Core.Models;

namespace service.server.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<AppUser,RegisterUser>();
            CreateMap<RegisterUser,AppUser>();

            CreateMap<RegisterUser,Address>();
            CreateMap<Address, RegisterUser>();

            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto,AppUser>();

            CreateMap< Address, ReadAdress>();
            CreateMap< ReadAdress ,Address >();
        }


    }
}
