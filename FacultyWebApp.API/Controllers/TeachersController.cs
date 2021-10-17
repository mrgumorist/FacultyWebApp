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
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersService _teacherService;
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ITeachersService teacherService, ILogger<TeachersController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var teacher = _teacherService.GetTeacherById(id);
                response.IsSuccessful = true;
                response.Message = "Successfuly founded";
                response.ResObj = teacher;
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

        [HttpGet("GetTeacherByIdAsync/{id}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                response.IsSuccessful = true;
                response.Message = "Successfuly founded";
                response.ResObj = teacher;
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

        [HttpPost("CreateTeacher")]
        public IActionResult CreateTeacher([FromBody] TeacherDTO teacherDto)
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
                    _teacherService.AddTeacher(teacherDto);
                }
                catch
                {
                    response.IsSuccessful = false;
                    response.Message = "Error with teacher. Some of FK is invalid.";
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }

            response.IsSuccessful = true;
            response.StatusCode = Ok().StatusCode;
            response.Message = "Successfuly added";
            return Ok(response);
        }

        [HttpPost("CreateTeacherAsync")]
        public async Task<IActionResult> CreateTeacherAsync([FromBody] TeacherDTO teacherDto)
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
                    await _teacherService.AddTeacherAsync(teacherDto);
                }
                catch
                {
                    response.IsSuccessful = false;
                    response.Message = "Error with teacher. Some of FK is invalid.";
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }

            response.IsSuccessful = true;
            response.StatusCode = Ok().StatusCode;
            response.Message = "Successfuly added";
            return Ok(response);
        }

        [HttpPut("ChangeTeacher")]
        public IActionResult ChangeTeacher([FromBody]TeacherDTO teacherDTO)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                _teacherService.ChangeTeacher(teacherDTO);
                response.IsSuccessful = true;
                response.Message = "Successfuly updated";
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

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                _teacherService.DeleteTeacherById(id);
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
        public IActionResult AllByFilters([FromBody] TeacherListRequestModel filters)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var students = _teacherService.AllByFilters(filters);
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
