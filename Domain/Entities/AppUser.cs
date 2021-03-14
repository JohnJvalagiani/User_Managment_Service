using Microsoft.AspNetCore.Identity;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Core.Models
{
   public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalNumber { get; set; }


        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public decimal Salary { get; set; }


        public Address Address { get; set; }

    }
}
