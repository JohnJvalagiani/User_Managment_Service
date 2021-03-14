using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class RegisterUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public decimal Salary { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Street { get; set; }


    }
}
