using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IBM_WebApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using IBM_WebApi.Models;
using IBM_WebApi.Repositories;
using IBM_WebApi.Services.UnitsOfWork;

namespace IBM_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(o => o.UseSqlServer(Configuration.GetConnectionString("PCStoreConnString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRamRepository, RamRepository>();
            services.AddScoped<IProcesoareRepository, ProcesoareRepository>();
            services.AddScoped<IPlaciVideoRepository, PlaciVideoRepository>();
            services.AddScoped<IPcsRepository, PcsRepository>();

            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IStoreUnitOfWork, StoreUnitOfWork>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
