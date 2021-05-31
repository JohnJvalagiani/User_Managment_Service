using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UserService.Core.Models;

namespace Domain.Entities
{
    public class Student: BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
      
        public decimal Rate { get; set; }
        public ICollection<LessonsDates> LessonsDates { get; set; }

        public StudentBio studentBio { get; set; }

        [ForeignKey("ForeignKey")]
        public string ForeignKey { get; set; }
        public AppUser  Teacher { get; set; }

    }


    public class LessonsDates:BaseEntity
    {
        public DateTime Date { get; set; }
    }



}
