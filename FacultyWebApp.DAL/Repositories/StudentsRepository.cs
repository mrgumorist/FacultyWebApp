using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FacultyWebApp.DAL.Repositories
{
    public class StudentsRepository:GenericRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Student> GetStudentsByFilters(string Surname, bool? IsDeducted, int? groupId)
        {
            //TODO: filtering
            return _context.Students.Take(5);
        }
    }
}
