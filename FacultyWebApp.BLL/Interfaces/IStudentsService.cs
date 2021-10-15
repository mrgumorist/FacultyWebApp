using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.Domain.ActionModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface IStudentsService
    {
        public StudentDTO GetStudentById(Guid id);
        public Task<StudentDTO> GetStudentByIdAsync(Guid id);
        public void AddStudent(StudentDTO studentDTO);
        public Task AddStudentAsync(StudentDTO studentDTO);
    }
}
