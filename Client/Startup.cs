using Blazored.LocalStorage;
using Client.Data;
using Client.Services;
using Client.Services.Abstraction;
using Client.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using UserService.Abstraction;
using UserService.Implementation;

namespace Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IAccountClient, AccountClient> ();


            services.AddBlazoredLocalStorage();

            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<IBrowserStorageService,BrowserStorageService>();

            services.AddScoped<JwtAuthProvider>();

            services.AddAuthorizationCore(opt => { });

            services.AddScoped<IAccountClient, AccountClient>();

            services.AddScoped<IStudentsService, StudentsService>();

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            //services.AddTransient<IIdentityService, IdentityService>();


            services.AddScoped<HttpClient>(s =>
            {
                return new HttpClient { BaseAddress = new Uri("https://localhost:44319") };
            });

            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<IJWTClaimParserService, JwtClaimsParser>();

            services.AddSyncfusionBlazor();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
