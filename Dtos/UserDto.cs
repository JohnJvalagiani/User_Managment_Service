using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalNumber { get; set; }

        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public decimal Salary { get; set; }

        public ReadAdress Address { get; set; }
    }
}
