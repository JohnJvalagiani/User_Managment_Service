using FluentValidation;
using Service.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Server.Services
{
    public class AdressValidation: AbstractValidator<Address>
    {

        public AdressValidation()
        {
            RuleFor(x=>x.State).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.Country).NotEmpty();
            RuleFor(x=>x.ZipCode).NotEmpty();
            RuleFor(x=>x.Country).NotEmpty();
        }

    }
}
