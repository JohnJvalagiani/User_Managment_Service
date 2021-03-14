using Core.Services.Abstraction;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Models;

namespace Core.Services.Implementation
{
    public class UserRepo : IRepo
    {
        protected readonly UserDbContext _context;
        protected readonly DbSet<Address> _set;

        public UserRepo(UserDbContext context)
        {
            _context = context;
            _set = context.Set<Address>();
        }

        public async Task<Address> Create(Address address)
        {
            var result = await _set.AddAsync(address);
            
            return result.Entity;

        }

        public async Task<Address> GetById(object Id)
        {
            if (Id == null)
                throw new ArgumentNullException($"Argument {nameof(Id)} was null ");


            var theresult = await _set.FirstOrDefaultAsync(a => a.UserForeignKey == Id.ToString());


            return theresult;
        }

        public async Task<Address> Update( Address address, object userId)
        {
           var theadress= await GetById(userId);

            theadress.State = address.State;
            theadress.City = address.City;
            theadress.ZipCode = address.ZipCode;
            theadress.Street = address.Street;
            theadress.Country = address.Country;

            var result = await  Task.FromResult( _set.Update(address));

            return result.Entity;
        }

       
    }
}
