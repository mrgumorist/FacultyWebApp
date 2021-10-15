using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentsService studentsService, ILogger<StudentsController> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            AppResponseResult responseRes = new AppResponseResult();
            try
            {
                var student = _studentsService.GetStudentById(id);
                responseRes.IsSuccessful = true;
                responseRes.Message = "Successfuly founded";
                responseRes.ResObj = student;
                responseRes.StatusCode = Ok().StatusCode;
            }
            catch(ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(responseRes);
        }

        [HttpGet("GetUserByIdAsync/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            AppResponseResult responseRes = new AppResponseResult();
            try
            {
                var student = await _studentsService.GetStudentByIdAsync(id);
                responseRes.IsSuccessful = true;
                responseRes.Message = "Successfuly founded";
                responseRes.ResObj = student;
                responseRes.StatusCode = Ok().StatusCode;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(responseRes);
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody]StudentDTO studentDto)
        {
            AppResponseResult responseRes = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();
                var responseStr = String.Join("\n", errorList);

                responseRes.IsSuccessful = false;
                responseRes.Message = "One or more errors occured: \n";
                responseRes.Message += responseStr;
                responseRes.ResObj = errorList;
                responseRes.StatusCode = BadRequest().StatusCode;
                return Ok(responseRes);
            }
            else
            {
                try
                {
                    _studentsService.AddStudent(studentDto);
                }
                catch
                {
                    responseRes.IsSuccessful = false;
                    responseRes.Message = "Error with student. Maybe group or type of education are not valid.";
                    responseRes.StatusCode = BadRequest().StatusCode;
                    return Ok(responseRes);
                }
            }

            responseRes.IsSuccessful = true;
            responseRes.StatusCode = Ok().StatusCode;
            responseRes.Message = "Successfuly added";
            return Ok(responseRes);
        }

        [HttpPost("CreateStudentAsync")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentDTO studentDto)
        {
            AppResponseResult responseRes = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();
                var responseStr = String.Join("\n", errorList);

                responseRes.IsSuccessful = false;
                responseRes.Message = "One or more errors occured: \n";
                responseRes.Message += responseStr;
                responseRes.ResObj = errorList;
                responseRes.StatusCode = BadRequest().StatusCode;
                return Ok(responseRes);
            }
            else
            {
                try
                {
                    await _studentsService.AddStudentAsync(studentDto);
                }
                catch 
                {
                    responseRes.IsSuccessful = false;
                    responseRes.Message = "Error with student. Maybe group or type of education are not valid.";
                    responseRes.StatusCode = BadRequest().StatusCode;
                    return Ok(responseRes);
                }
            }

            responseRes.IsSuccessful = true;
            responseRes.StatusCode = Ok().StatusCode;
            responseRes.Message = "Successfuly added";
            return Ok(responseRes);
        }
    }
}
