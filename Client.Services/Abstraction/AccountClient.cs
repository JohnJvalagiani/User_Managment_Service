using Blazored.LocalStorage;
using Client.Services.Abstraction;
using Client.Services.Common;
using Core.Responses;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Core.Models;

namespace Client.Services
{
    public class AccountClient:IAccountClient
    {


        private IHttpService _httpService;
     
        public AccountClient(IHttpService httpService)
        {
            _httpService = httpService;

        }

        public Task<bool> AssignRoleAsync(TeacherProfileDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherProfileDTO>> GetUserInfoDetailDTOsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherProfileDTO> GetUserProfileDTOAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherProfileDTO> GetUserProfileDTOAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async  Task<AuthentificationResult> LoginAsync(LoginDto userLoginDTO)
        {


            var result = await _httpService.Post<AuthentificationResult, LoginDto>(TeacherEndpoints.Login, userLoginDTO);

            return result;

        }

        public async Task<AuthentificationResult> RegisterAsync(TeacherProfileDTO userRegisterDTO)
        {
            try
            {
                var result = await _httpService.Post<AuthentificationResult, TeacherProfileDTO>(TeacherEndpoints.Registration, userRegisterDTO);

                // var result = await _identityService.Registration(new AppUser() {LastName= userRegisterDTO.LastName,Email= userRegisterDTO.Email,FirstName= userRegisterDTO.FirstName,UserName= userRegisterDTO.UserName } , userRegisterDTO.Password);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        
        }

        public Task<bool> RemoveRoleAsync(TeacherProfileDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherProfileDTO> UpdateUserAsync(string email, TeacherProfileDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
