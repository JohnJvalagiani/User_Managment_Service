using Core.Services.Abstraction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserService.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Service.Server.Services;
using Dtos;

namespace Service.Server.Controllers
{
    public class UserProfileController: ControllerBase
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepo _repo;
        private readonly IMapper _mapper;
        private readonly CurrentUserSupplier _currentUserSupplier;

        public UserProfileController(CurrentUserSupplier currentUser,IMapper mapper,IRepo repo, UserManager<AppUser> userManager)
        {
            this._mapper=mapper;
            this._userManager = userManager;
            this._repo = repo;
            this._currentUserSupplier = currentUser;
        }

        [Authorize]
        [HttpGet("UserProfile")]
        public async Task<IActionResult> GetUserdataAsync()
        {

            var theuser = await _currentUserSupplier.GetCurrentUser();

           var Address = await _repo.GetById(theuser.Id);

           var theuserdata = _mapper.Map<UserDto>(theuser);

            var theAddress = _mapper.Map<ReadAdress>(Address);

            return Ok(new JsonResult (theuserdata, theAddress));


        }



       
    }
}
