using AutoMapper;
using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using FacultyWebApp.Domain.Models.RequestModels;

namespace FacultyWebApp.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IGenericRepository<Student> _genericRepo;
        private readonly ILogger<StudentsService> _logger;
        //private readonly IMapper _mapper;

        public StudentsService(IGenericRepository<Student> genericRepo, ILogger<StudentsService> logger/*, IMapper mapper*/ )
        {
            _genericRepo = genericRepo;
            _logger = logger;
            //_mapper = mapper;
        }

        public StudentDTO GetStudentById(Guid id)
        {
            var student = _genericRepo.GetById(id);
            if (student == null)
            {
                throw new ValidationException("Student was not founded", "id");
            }

            if (student.IsDeleted == true)
            {
                throw new ValidationException("Student was deleted", "id");
            }

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                IsDeducted = student.IsDeducted,
                EntryYear = student.EntryYear,
                PhoneNum = student.PhoneNum,
                EducationTypeId = student.EducationTypeId,
                GroupId = student.Group.Id
            };

            return studentDTO;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(Guid id)
        {
            var student = await _genericRepo.GetByIdAsync(id);
            if (student == null)
            {
                throw new ValidationException("Student was not founded", "id");
            }
            if (student.IsDeleted == true)
            {
                throw new ValidationException("Student was deleted", "id");
            }

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                IsDeducted = student.IsDeducted,
                EntryYear = student.EntryYear,
                PhoneNum = student.PhoneNum,
                EducationTypeId = student.EducationTypeId,
                GroupId = student.Group.Id
            };

            return studentDTO;
        }

        public void AddStudent(StudentDTO studentDTO)
        {
            var student = new Student()
            {
                EducationTypeId = studentDTO.EducationTypeId,
                EntryYear = studentDTO.EntryYear,
                GroupId = studentDTO.GroupId,
                IsDeducted = studentDTO.IsDeducted,
                Name = studentDTO.Name,
                PhoneNum = studentDTO.PhoneNum,
                Surname = studentDTO.Surname
            };

            _genericRepo.Add(student);
        }

        public async Task AddStudentAsync(StudentDTO studentDTO)
        {
            var student = new Student()
            {
                EducationTypeId = studentDTO.EducationTypeId,
                EntryYear = studentDTO.EntryYear,
                GroupId = studentDTO.GroupId,
                IsDeducted = studentDTO.IsDeducted,
                Name = studentDTO.Name,
                PhoneNum = studentDTO.PhoneNum,
                Surname = studentDTO.Surname
            };

            await _genericRepo.AddAsync(student);
        }

        public void ChangeStudent(StudentDTO studentDTO)
        {
            var student = _genericRepo.GetById(studentDTO.Id);
            if (student == null)
            {
                throw new ValidationException("Student was not founded", "id");
            }

            if (student.IsDeleted == true)
            {
                throw new ValidationException("Student was deleted", "id");
            }

            student.EducationTypeId = studentDTO.EducationTypeId;
            student.EntryYear = studentDTO.EntryYear;
            student.GroupId = studentDTO.GroupId;
            student.IsDeducted = studentDTO.IsDeducted;
            student.Name = studentDTO.Name;
            student.PhoneNum = studentDTO.PhoneNum;
            student.Surname = studentDTO.Surname;

            _genericRepo.Update(student);
        }

        public void DeleteStudentById(Guid id)
        {
            var student = _genericRepo.GetById(id);
            if (student == null)
            {
                throw new ValidationException("Student was not founded", "id");
            }

            if (student.IsDeleted == true)
            {
                throw new ValidationException("Student was before deleted", "id");
            }

            student.IsDeleted = true;
            _genericRepo.Update(student);
        }

        public List<StudentDTO> AllByFilters(StudentListRequestModel filters)
        {
            var students = _genericRepo.Find(x=>x.IsDeducted==false);
            return null;
        }
    }
}