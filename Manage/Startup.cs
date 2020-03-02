using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Services.Data;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Data;
using AutoMapper;
using FluentValidation.AspNetCore;
using Manage.Resources;
using FluentValidation;

namespace Manage
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

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<TaskManagmentDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly("Data")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IProjectService,ProjectService>();


            // validations
            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation();

            services.AddTransient<IValidator<UserCreateResource>, UserCreateResourceValidator>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
