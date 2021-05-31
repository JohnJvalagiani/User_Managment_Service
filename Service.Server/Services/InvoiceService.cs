using Core.Services.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Server.Services
{
    public class InvoiceService
    {
        private readonly IRepo<Student> _repo;
        public InvoiceService(IRepo<Student> repo)
        {
            this._repo = repo;

        }

        public async Task<IEnumerable<Invoice>> GetInvoiceAsync ()
        {

           var students=await _repo.GetAll();

            var invoice = await Task.FromResult(students.Select(s => new Invoice
            {

                Amount = s.Rate * s.LessonsDates.Count,
                Lessons = s.LessonsDates.Count,
                StudentFullName = s.FirstName + " " + s.LastName,
                LessonDates = s.LessonsDates,
                Bank = "",
                BankCode = "",
                AccountNumber="",
                CompanyName="Open dorr center",
                IdentityCode=1111,
                PreviusRate=25,
                Rate=25
                


            }) );

            return invoice;
        }

      
    }
}
