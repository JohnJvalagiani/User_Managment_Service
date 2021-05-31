using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
   public class TeacherProfileDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
