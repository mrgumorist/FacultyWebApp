using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using FacultyWebApp.Domain.Models.RequestModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.BLL.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly IGenericRepository<Teacher> _genericRepo;
        private readonly IGenericRepository<Shedule> _shedulesGenericRepo;
        private readonly ILogger<TeachersService> _logger;

        public TeachersService(IGenericRepository<Teacher> genericRepo, IGenericRepository<Shedule> shedulesGenericRepo, ILogger<TeachersService> logger)
        {
            _genericRepo = genericRepo;
            _shedulesGenericRepo = shedulesGenericRepo;
            _logger = logger;
        }
        public TeacherDTO GetTeacherById(int id)
        {
            var teacher = _genericRepo.GetById(id);
            if (teacher == null)
            {
                throw new ValidationException("Teacher was not founded", "id");
            }

            if (teacher.IsDeleted == true)
            {
                throw new ValidationException("Teacher was deleted", "id");
            }

            var teacherDTO = new TeacherDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                FatherName = teacher.FatherName,
                DegreeId = teacher.DegreeId,
                PhoneNum = teacher.PhoneNum,
                Position = teacher.Position
            };

            return teacherDTO;
        }

        public async Task<TeacherDTO> GetTeacherByIdAsync(int id)
        {
            var teacher = await _genericRepo.GetByIdAsync(id);
            if (teacher == null)
            {
                throw new ValidationException("Teacher was not founded", "id");
            }

            if (teacher.IsDeleted == true)
            {
                throw new ValidationException("Teacher was deleted", "id");
            }

            var teacherDTO = new TeacherDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                FatherName = teacher.FatherName,
                DegreeId = teacher.DegreeId,
                PhoneNum = teacher.PhoneNum,
                Position = teacher.Position
            };

            return teacherDTO;
        }

        public void AddTeacher(TeacherDTO teacherDTO)
        {
            var teacher = new Teacher()
            {
                Name = teacherDTO.Name,
                Surname = teacherDTO.Surname,
                FatherName = teacherDTO.FatherName,
                DegreeId = teacherDTO.DegreeId,
                IsDeleted = false,
                PhoneNum = teacherDTO.PhoneNum,
                Position = teacherDTO.Position
            };

            _genericRepo.Add(teacher);
        }

        public async Task AddTeacherAsync(TeacherDTO teacherDTO)
        {
            var teacher = new Teacher()
            {
                Name = teacherDTO.Name,
                Surname = teacherDTO.Surname,
                FatherName = teacherDTO.FatherName,
                DegreeId = teacherDTO.DegreeId,
                IsDeleted = false,
                PhoneNum = teacherDTO.PhoneNum,
                Position = teacherDTO.Position
            };

            await _genericRepo.AddAsync(teacher);
        }

        public void ChangeTeacher(TeacherDTO teacherDTO)
        {
            var teacher = _genericRepo.GetById(teacherDTO.Id);
            if (teacher == null)
            {
                throw new ValidationException("Teacher was not founded", "id");
            }

            if (teacher.IsDeleted == true)
            {
                throw new ValidationException("Teacher was deleted", "id");
            }

            teacher.Name = teacherDTO.Name;
            teacher.Surname = teacherDTO.Surname;
            teacher.FatherName = teacherDTO.FatherName;
            teacher.DegreeId = teacherDTO.DegreeId;
            teacher.PhoneNum = teacherDTO.PhoneNum;
            teacher.Position = teacherDTO.Position;

            _genericRepo.Update(teacher);
        }

        public void DeleteTeacherById(int id)
        {
            var teacher = _genericRepo.GetById(id);
            if (teacher == null)
            {
                throw new ValidationException("Teacher was not founded", "id");
            }

            if (teacher.IsDeleted == true)
            {
                throw new ValidationException("Teacher was already deleted", "id");
            }

            teacher.IsDeleted = true;
            _genericRepo.Update(teacher);
        }

        public List<TeacherDTO> AllByFilters(TeacherListRequestModel filters)
        {
            var teachersIQueryable = _genericRepo.GetAllIQueryable();

            if (!String.IsNullOrWhiteSpace(filters.Surname))
            {
                teachersIQueryable = teachersIQueryable.Where(x => x.Surname == filters.Surname);
            }

            if (filters.DegreeId.HasValue)
            {
                teachersIQueryable = teachersIQueryable.Where(x => x.DegreeId == filters.DegreeId);
            }

            if (filters.SubjectId.HasValue)
            {
                //JOIN
                teachersIQueryable = teachersIQueryable.Where(x => _shedulesGenericRepo.GetAllIQueryable().Any(l=>l.SubjectId==filters.SubjectId&&l.TeacherId==x.Id));
            }

            teachersIQueryable = teachersIQueryable.Where(x => x.IsDeleted == false);

           

            var listOfStudentDTOs = teachersIQueryable.Select(teacher => new TeacherDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                FatherName = teacher.FatherName,
                DegreeId = teacher.DegreeId,
                PhoneNum = teacher.PhoneNum,
                Position = teacher.Position
            }
            ).ToList();

            if (listOfStudentDTOs.Count == 0)
            {
                throw new ValidationException("Count of teachers by filter is 0", "Count");
            }
            return listOfStudentDTOs;
        }
    }
}
