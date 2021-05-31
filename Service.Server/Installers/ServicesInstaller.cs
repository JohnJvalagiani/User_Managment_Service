using Core.Services;
using Core.Services.Abstraction;
using Core.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using service.server.Profiles;
using service.server.Services;
using Service.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Implementation;

namespace Service.Server.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<UserValidation>();

            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));

            services.AddScoped<JWTTokenService>();

            services.AddScoped<CurrentUserSupplier>();

            services.AddTransient<IMailService, MailService>();

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<InvoiceService>();

        }
    }
}
