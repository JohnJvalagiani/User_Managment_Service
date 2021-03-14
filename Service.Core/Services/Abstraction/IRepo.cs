using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.Models;

namespace Core.Services.Abstraction
{
    public interface IRepo
    {

        Task<Address> GetById(object Id);
        Task<Address> Update(Address Address, object userId);
        Task<Address> Create(Address address);
    }
}
