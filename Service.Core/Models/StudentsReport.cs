using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
  public   class StudentsReport
    {
        public ICollection<DateTime> LessonsDateTime { get; set; }
        public decimal amount { get; set; }
        public decimal PreviusRate { get; set; }
        public decimal Rate { get; set; }
        public string StudentFullName { get; set; }

        private void  Amount()
        {
            amount = LessonsDateTime.Count * Rate;
        }
    }
}
