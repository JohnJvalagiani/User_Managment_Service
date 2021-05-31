using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class StudentBio:BaseEntity
    {

        public Level KnowelidgeLevel { get; set; }
        public string Teacher { get; set; }
        public string About { get; set; }
        public DateTime StartLearning { get; set; }
        public DateTime EndLearning { get; set; }

    }

    public enum Level
    {
        A1, A2, B1, B2, C1
    }
}
