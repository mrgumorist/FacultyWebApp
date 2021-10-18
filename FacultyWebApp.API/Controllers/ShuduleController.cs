using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.Domain.ActionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShuduleController : ControllerBase
    {
        private readonly ISheduleService _sheduleService;
        private readonly ILogger<ShuduleController> _logger;

        public ShuduleController(ISheduleService sheduleService, ILogger<ShuduleController> logger)
        {
            _sheduleService = sheduleService;
            _logger = logger;
        }

        [HttpPost("CreateItemInShedule")]
        public IActionResult CreateItemInShedule([FromBody] SheduleDTO sheduleItemDto)
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
                    _sheduleService.AddToShudule(sheduleItemDto);
                }
                catch
                {
                    response.IsSuccessful = false;
                    response.Message = "Error with shedule. Check relationships!";
                    response.StatusCode = BadRequest().StatusCode;
                    return BadRequest(response);
                }
            }

            response.IsSuccessful = true;
            response.StatusCode = Ok().StatusCode;
            response.Message = "Successfuly added";
            return Ok(response);
        }

        [HttpGet("GetShedules/{groupId}")]
        public IActionResult GetShedules(int groupId)
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var students = _sheduleService.GetShedule(groupId);
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
        [HttpGet("GetShedules")]
        public IActionResult GetShedules()
        {
            AppResponseResult response = new AppResponseResult();
            try
            {
                var students = _sheduleService.GetShedule();
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
