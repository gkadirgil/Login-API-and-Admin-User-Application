using LOGIN.DATA.Models;
using LOGIN.SERVICES;
using LOGIN.SERVICES.IRepository;
using LoginApplication.AutoMappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LOGIN.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IPersonRepository<Admin>, AdminRepository>();
            services.AddSingleton<IPersonRepository<User>, UserRepository>();
            services.AddSingleton<IMailRepository, MailRepository>();

            services.AddAutoMapper(typeof(UserProfil));
            services.AddAutoMapper(typeof(AdminProfil));

            services.AddSwaggerDocument(config =>
            {
            config.PostProcess = (
            doc =>
            {
                doc.Info.Title = "Login Project API";
                doc.Info.Version = "1.0.1";

            });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
