using AutoMapper;
using Core.Responses;
using Core.Services.Abstraction;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Core.Models;

namespace Service.Server.Controllers
{
 
    [Authorize]
    [ApiController]
    [Route("api/Account")]
    public class AccauntController : ControllerBase
    {
        private readonly IIdentityService _service;
        private readonly ILogger<AccauntController> _logger;
        private readonly IMapper _mapper;
        private readonly CurrentUserSupplier _currentUserSupplier;

        public AccauntController(CurrentUserSupplier currentUserSupplier,IIdentityService service, IMapper mapper,
            ILogger<AccauntController> logger)
        {

            this._mapper = mapper;

            this._service = service;

            this._logger = logger;

            this._currentUserSupplier = currentUserSupplier;
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(TeacherProfileDTO User,string password)
        {
           

            _logger.LogInformation("Registration",User);


            var theuser = _mapper.Map<AppUser>(User);

           

             return  Ok(await  _service.Registration(theuser, User.Password));

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<AuthentificationResult>> Login( LoginDto User)
        {
            _logger.LogInformation("Login", User);


            var result = await _service.Login(User.Email, User.Password);

            if(result.Success)
            {
            return Ok(result);
            }

            return Unauthorized();

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            var curUser = await _currentUserSupplier.GetCurrentUser();

            _logger.LogInformation("Delete", User);

            return Ok(await _service.Delete(curUser.Id));

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]  UserDto userDto)
        {


            _logger.LogInformation("Update", User);
            


            return Ok(await _service.Update(userDto));

        }


    }
}
