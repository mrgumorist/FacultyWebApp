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
            AppResponseResult requestResult = new AppResponseResult();
            try
            {
                var student = _studentsService.GetStudentById(id);
                requestResult.IsSuccessful = true;
                requestResult.Message = "Successfuly founded";
                requestResult.ResObj = student;
                requestResult.StatusCode = 200;
            }
            catch(ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(requestResult);
        }

        [HttpGet("GetUserByIdAsync/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            AppResponseResult requestResult = new AppResponseResult();
            try
            {
                var student = await _studentsService.GetStudentByIdAsync(id);
                requestResult.IsSuccessful = true;
                requestResult.Message = "Successfuly founded";
                requestResult.ResObj = student;
                requestResult.StatusCode = 200;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(requestResult);
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody]StudentDTO studentDto)
        {
            AppResponseResult requestResult = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                return Ok(studentDto);
            }
            else
            {
                _studentsService.AddStudent(studentDto);
            try
            {
                //bool studentDTO = _studentsService.AddStudent(student);
                //requestResult.IsSuccessful = true;
                //requestResult.Message = "Successfuly founded";
                //requestResult.ResObj = student;
                //requestResult.StatusCode = 200;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }

            }
            return Ok(requestResult);
        }
    }
}
