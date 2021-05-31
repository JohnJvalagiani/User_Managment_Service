using UserService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Core.Responses;

namespace UserService.Abstraction
{
   public  interface IIdentityService 
    {
       Task<AuthentificationResult> Registration(AppUser user, string password);
       Task<AuthentificationResult> Login(string username,string  password);
       Task<AuthentificationResult> RefreshTokenAsync(string token,string  refreshToken);
       Task<bool> Update(UserDto appUser);
       Task<bool> Delete(object id);
    }
}
