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
        }
    }
}
