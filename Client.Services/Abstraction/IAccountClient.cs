using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Responses;
using Dtos;


namespace Client.Services.Abstraction
{
   public  interface IAccountClient
    {

        Task<TeacherProfileDTO> GetUserProfileDTOAsync(int id);
        Task<TeacherProfileDTO> GetUserProfileDTOAsync(string email);
        Task<List<TeacherProfileDTO>> GetUserInfoDetailDTOsAsync();
        Task<AuthentificationResult> LoginAsync(LoginDto userLoginDTO);
        Task<AuthentificationResult> RegisterAsync(TeacherProfileDTO userRegisterDTO);
        Task<TeacherProfileDTO> UpdateUserAsync(string email, TeacherProfileDTO userUpdateDTO);
        Task<bool> AssignRoleAsync(TeacherProfileDTO userRoleDTO);
        Task<bool> RemoveRoleAsync(TeacherProfileDTO userRoleDTO);
        Task<bool> DeleteUserAsync(int id);
    }
}
