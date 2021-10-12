using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<DictionarySubject> DictionarySubjects { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EducationType>().HasData(
                new EducationType
                {
                    Name = "Bachelor",
                    Description = "It is an undergraduate academic degree awarded by colleges and universities upon completion of a course of study lasting three to six years."
                },
                 new EducationType
                 {
                     Name = "Master",
                     Description = "It is an academic degree awarded by universities or colleges upon completion of a course of study demonstrating mastery or a high-order overview of a specific field of study or area of professional practice."
                 }
                 );

            modelBuilder.Entity<Group>().HasData(
                new Group() { Code = "B44" },
                new Group() { Code = "F74" }
                );
        }
    }
}
