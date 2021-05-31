using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services.Abstraction
{
  public  interface IStudentsService
    {

        Task<IEnumerable<ReadStudentDto>> GetAllStudent(string token);
        Task<ReadStudentDto> GetyId(object Id, string token);
        Task<bool> RemoveStudent(object Id, string token);
        Task<ReadStudentDto> Updatestudent(ReadStudentDto data, string token);
        Task<ReadStudentDto> Addstudent(StudentDto data, string token);


    }
}
