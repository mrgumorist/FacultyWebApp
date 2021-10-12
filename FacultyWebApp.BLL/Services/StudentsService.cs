using AutoMapper;
using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.BLL.Services
{
    public class StudentsService: IStudentsService
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

        public AppActionResult GetUserById(int id)
        {
            AppActionResult actionResult = new AppActionResult();
            try
            {
                var student = _genericRepo.GetById(id);
                if (student==null)
                {
                    actionResult.IsSuccessful = false;
                    actionResult.Message = "Student was not founded.";
                    actionResult.StatusCode = 404;
                    return actionResult;
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
                    GroupId = student.GroupId
                };

                actionResult.IsSuccessful = true;
                actionResult.Message = "Student was successfuly founded.";
                actionResult.ResObj = studentDTO;
                actionResult.StatusCode = 200;
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessful = false;
                actionResult.Message = $"Error occured: {ex.Message}.";
                actionResult.StatusCode = 500;
                return actionResult;
            }

            return actionResult;
        }

        public async Task<AppActionResult> GetUserByIdAsync(int id)
        {
            AppActionResult actionResult = new AppActionResult();
            try
            {
                var student = await _genericRepo.GetByIdAsync(id);
                if (student == null)
                {
                    actionResult.IsSuccessful = false;
                    actionResult.Message = "Student was not founded.";
                    actionResult.StatusCode = 404;
                    return actionResult;
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
                    GroupId = student.GroupId
                };

                actionResult.IsSuccessful = true;
                actionResult.Message = "Student was successfuly founded.";
                actionResult.ResObj = studentDTO;
                actionResult.StatusCode = 200;
            }
            catch (Exception ex)
            {
                actionResult.IsSuccessful = false;
                actionResult.Message = $"Error occured: {ex.Message}.";
                actionResult.StatusCode = 500;
                return actionResult;
            }

            return actionResult;
        }
    }
}
