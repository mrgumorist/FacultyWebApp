using FacultyWebApp.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.DAL.Seeder
{
    public class DbSeeder
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                MainPropsSeeder.SeedStudents(context);
            }
        }
    }
}
