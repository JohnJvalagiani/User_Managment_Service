using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
   public  class ReadStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Rate { get; set; }
        public ICollection<DateTime?> LessonsDates { get; set; }

        public string studentBio { get; set; }
        public int TeacherId { get; set; }


    }
}
