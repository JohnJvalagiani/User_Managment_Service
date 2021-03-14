using Core.Services;
using Core.Services.Abstraction;
using Dtos;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Core.Data.Entities;
using Service.Server.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Core.Models;
using UserService.Core.Responses;

namespace UserService.Implementation
{
    public class IdentityService : IIdentityService
    {
        public readonly CurrentUserSupplier _currentUserSupplier;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTTokenService _jWT;
        private readonly IRepo _repo;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(IRepo repo,CurrentUserSupplier currentUserSupplier,JWTTokenService jWt
            ,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager /*JwtSettings jwtSettings*/)
        {
            this._repo = repo;
            this._currentUserSupplier = currentUserSupplier;
            this._jWT = jWt;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        public async Task<AuthentificationResult> Registration(AppUser user, string password)
        {

            var theuser = await _userManager.FindByEmailAsync(user.Email);

            if (theuser != null)
            {

                return new AuthentificationResult
                {
                    Errors = new[] { "User with this email adress already exists" }
                };

            }

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return new AuthentificationResult
                {
                    Errors = result.Errors.Select(e => e.Description)

                };
            }

            var roleExist = await _roleManager.RoleExistsAsync("default");

            if(!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "default" });
            }

            await _userManager.AddToRoleAsync(user, "default");

            return await GenerateAuthenicationResultForUser(user);
        }


        public async Task<AuthentificationResult> Login(string user, string password)
        {

            var theuser = await _userManager.FindByEmailAsync(user);

            if (theuser == null)
            {

                return new AuthentificationResult
                {
                    Errors = new string[] { $"Password or Email not correct" }
                };
            }

          var result = await _signInManager.PasswordSignInAsync(user,password, false,false);

            if(result.Succeeded)
            return await GenerateAuthenicationResultForUser(theuser);


            return new AuthentificationResult
            {
                Errors = new string[] { $"Password or Email not correct" }
            };

        }


        public async Task<bool> Update(UserDto appUser)
        {


            var curUser = await _currentUserSupplier.GetCurrentUser();

            curUser.IsEmployed = appUser.IsEmployed;
            curUser.IsMarried = appUser.IsMarried;
            curUser.Salary = appUser.Salary;
            curUser.PersonalNumber = appUser.PersonalNumber;
            curUser.LastName = appUser.LastName;
            curUser.FirstName = appUser.FirstName;

            Address address = new Address { State = appUser.Address.State, City = appUser.Address.City
            ,ZipCode= appUser.Address.ZipCode, Country= appUser.Address.Country, Street= appUser.Address.Street
            };

           await  _repo.Update(address,curUser.Id);

            var result=await _userManager.UpdateAsync(curUser);

            return result.Succeeded;
           
        }

        public async Task<bool> Delete(object id)
        {
           var theuser=await  _userManager.FindByIdAsync(id.ToString());
           
           var result= await _userManager.DeleteAsync(theuser);

            return result.Succeeded;
        
        }
        private async Task<AuthentificationResult> GenerateAuthenicationResultForUser(AppUser theuser)
        {
           return  await _jWT.BuildToken(new UserInfoDTO {EmailAddress=theuser.Email});

           
        }
    }
}
