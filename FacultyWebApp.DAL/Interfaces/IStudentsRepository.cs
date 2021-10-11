using FacultyWebApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.DAL.Interfaces
{
    public interface IStudentsRepository:IGenericRepository<Student>
    {
        IEnumerable<Student> GetStudentsByFilters(string Surname, bool? IsDeducted, int? groupId);
    }
}
