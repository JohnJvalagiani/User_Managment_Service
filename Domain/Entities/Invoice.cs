using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Invoice
    {
        public string CompanyName { get; set; }
        public int IdentityCode { get; set; }
        public ICollection<LessonsDates> LessonDates { get; set; } 
        public int Lessons { get; set; }
        public string StudentFullName { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public decimal PreviusRate { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
