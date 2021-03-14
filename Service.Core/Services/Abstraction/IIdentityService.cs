using UserService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Responses;
using Dtos;

namespace UserService.Abstraction
{
   public  interface IIdentityService 
    {
       Task<AuthentificationResult> Registration(AppUser user,string password);
       Task<AuthentificationResult> Login(string user, string password);
       Task<bool> Update(UserDto appUser);
       Task<bool> Delete(object id);
    }
}
