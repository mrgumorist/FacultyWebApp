using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.BLL.Services;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using FacultyWebApp.DAL.Repositories;
using FacultyWebApp.DAL.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.API
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
            services.AddLogging();

            services.AddControllers().AddNewtonsoftJson();

            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection"), b => b.SetPostgresVersion(9, 6)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();

            services.AddScoped<IGenericRepository<Group>, GenericRepository<Group>>();

            services.AddScoped<IGenericRepository<Shedule>, GenericRepository<Shedule>>();

            services.AddScoped<IGenericRepository<Teacher>, GenericRepository<Teacher>>();

            services.AddScoped<IGenericRepository<Subject>, GenericRepository<Subject>>();

            services.AddScoped<IGenericRepository<EducationType>, GenericRepository<EducationType>>();

            services.AddScoped<IStudentsService, StudentsService>();

            services.AddScoped<ITeachersService, TeachersService>();

            services.AddScoped<ISheduleService, SheduleService>();

            services.AddScoped<IDataService, DataService>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // services.AddAutoMapper(c => c.AddProfile<BLL.Mappers.AutoMapping>(), typeof(Startup))
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });



            DbSeeder.SeedData(app.ApplicationServices);
        }
    }
}
