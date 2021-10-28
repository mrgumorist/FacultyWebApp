using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using FacultyWebApp.Domain.Models.RequestModels;
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
            AppResponseResult response = new AppResponseResult();
            try
            {
                var student = _studentsService.GetStudentById(id);
                response.IsSuccessful = true;
                response.Message = "Successfuly founded";
                response.ResObj = student;
                response.StatusCode = Ok().StatusCode;
            }
            catch (ValidationException ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                response.StatusCode = NotFound().StatusCode;
                return NotFound(response);
            }
            catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                response.StatusCode = BadRequest().StatusCode;
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetStudentByIdAsync/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var student = await _studentsService.GetStudentByIdAsync(id);
                response.IsSuccessful = true;
                response.Message = "Successfuly founded";
                response.ResObj = student;
                response.StatusCode = Ok().StatusCode;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody] StudentDTO studentDto)
        {
            AppResponseResult response = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();

                response.IsSuccessful = false;
                response.Message = "One or more errors occured. See ResObj for details error.";
                response.ResObj = errorList;
                response.StatusCode = BadRequest().StatusCode;
                return BadRequest(response);
            }
            else
            {
                try
                {
                    _studentsService.AddStudent(studentDto);
                }
                catch
                {
                    response.IsSuccessful = false;
                    response.Message = "Error with student. Maybe group or type of education are not valid.";
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }

            response.IsSuccessful = true;
            response.StatusCode = Ok().StatusCode;
            response.Message = "Successfuly added";
            return Ok(response);
        }

        [HttpPost("CreateStudentAsync")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentDTO studentDto)
        {
            AppResponseResult response = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();

                response.IsSuccessful = false;
                response.Message = "One or more errors occured. See ResObj for details error.";
                response.ResObj = errorList;
                response.StatusCode = BadRequest().StatusCode;
                return BadRequest(response);
            }
            else
            {
                try
                {
                    await _studentsService.AddStudentAsync(studentDto);
                }
                catch
                {
                    response.IsSuccessful = false;
                    response.Message = "Error with student. Maybe group or type of education are not valid.";
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }

            response.IsSuccessful = true;
            response.StatusCode = Ok().StatusCode;
            response.Message = "Successfuly added";
            return Ok(response);
        }

        [HttpPut("ChangeStudent")]
        public IActionResult ChangeStudent([FromBody]StudentDTO studentDTO)
        {
            AppResponseResult response = new AppResponseResult();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();

                response.IsSuccessful = false;
                response.Message = "One or more errors occured. See ResObj for details error.";
                response.ResObj = errorList;
                response.StatusCode = BadRequest().StatusCode;
                return BadRequest(response);
            }
            else
            {
                try
                {
                    _studentsService.ChangeStudent(studentDTO);
                    response.IsSuccessful = true;
                    response.Message = "Successfuly updated";
                    response.StatusCode = Ok().StatusCode;
                }
                catch (ValidationException ex)
                {
                    response.IsSuccessful = false;
                    response.Message = ex.Message;
                    response.StatusCode = NotFound().StatusCode;
                    return NotFound(response);
                }
                catch(Exception ex)
                {
                    response.IsSuccessful = false;
                    response.Message = ex.Message;
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }
            return Ok(response);
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(Guid id)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                _studentsService.DeleteStudentById(id);
                response.IsSuccessful = true;
                response.Message = "Successfuly deleted";
                response.StatusCode = Ok().StatusCode;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost("AllByFilters")]
        public IActionResult AllByFilters([FromBody] StudentListRequestModel filters)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var students = _studentsService.AllByFilters(filters);
                response.IsSuccessful = true;
                response.Message = "Successfuly founded";
                response.ResObj = students;
                response.StatusCode = Ok().StatusCode;
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
