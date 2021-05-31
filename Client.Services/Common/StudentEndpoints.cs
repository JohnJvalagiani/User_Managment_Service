using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services.Common
{
    public class StudentEndpoints
    {

        public const string Base = "api/students/";

        public const string AddStudent = Base+"AddStudent";

        public const string GetAllStudent = Base+"GetAllStudents";

        public const string GetById = Base+"GetById";

        public const string RemoveStudent = Base+"Remove";

        public const string UpdateStudent = Base+"Update";



    }
}
