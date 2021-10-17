using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface ITeachersService
    {
        public TeacherDTO GetTeacherById(int id);
        public Task<TeacherDTO> GetTeacherByIdAsync(int id);
        public void AddTeacher(TeacherDTO teacherDTO);
        public Task AddTeacherAsync(TeacherDTO teacherDTO);
        public void ChangeTeacher(TeacherDTO teacherDTO);
        public void DeleteTeacherById(int id);
        public List<TeacherDTO> AllByFilters(TeacherListRequestModel filters);
    }
}
