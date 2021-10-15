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
            #region Seeding
            modelBuilder.Entity<EducationType>().HasData(
                new EducationType
                {
                    Id=1,
                    Name = "Bachelor",
                    Description = "It is an undergraduate academic degree awarded by colleges and universities upon completion of a course of study lasting three to six years."
                },
                 new EducationType
                 {
                     Id = 2,
                     Name = "Master",
                     Description = "It is an academic degree awarded by universities or colleges upon completion of a course of study demonstrating mastery or a high-order overview of a specific field of study or area of professional practice."
                 });

            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    Id = 1,
                    Code = "B44"
                },
                new Group
                {
                    Id = 2,
                    Code = "F74"
                });

            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Geography",
                    Description = "The study of places and the relationships between people and their environments."
                },
                new Subject
                {
                    Id = 2,
                    Name = "Philosophy",
                    Description = "It is a way of expressing philosophical resignation over a disappointment, of saying that the situation just has to be put up with"
                });
            #endregion
        }
    }
}
