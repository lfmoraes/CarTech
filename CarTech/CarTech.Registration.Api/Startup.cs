using AutoMapper;
using CarTech.Registration.Data.Context;
using CarTech.Registration.Data.Interface.Base;
using CarTech.Registration.Data.Repository.Base;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarTech.Registration.Api
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
            services.AddDbContext<RegistrationDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("RegistrationConnection"));
            });

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<RegistrationDbContext>();

            services.AddControllers();

            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CarTech Registration Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(o => {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "CarTech Registration V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
