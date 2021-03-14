using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Core.Models;
using UserService.Implementation;

namespace Service.Server.Installers
{
    public class DbInstaller : IInstaller
    {
      
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IIdentityService, IdentityService>();



            services.AddDbContext<UserDbContext>
                   (opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

        }
    }
}
