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
        public IActionResult GetStudentById(int id)
        {
            AppActionResult requestRes = new AppActionResult();

            var actionRes = _studentsService.GetUserById(id);

            requestRes.StatusCode = actionRes.StatusCode;
            requestRes.Message = actionRes.Message;
            requestRes.IsSuccessful = actionRes.IsSuccessful;
            if (actionRes.IsSuccessful == false)
            {
                if (actionRes.StatusCode == 404)
                {
                    return NotFound(requestRes);
                }
            }

            return Ok(requestRes);
        }

        [HttpGet("GetUserByIdAsync/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            AppActionResult requestRes = new AppActionResult();

            var actionRes = await _studentsService.GetUserByIdAsync(id);

            requestRes.StatusCode = actionRes.StatusCode;
            requestRes.Message = actionRes.Message;
            requestRes.IsSuccessful = actionRes.IsSuccessful;
            if (actionRes.IsSuccessful == false)
            {
                if (actionRes.StatusCode == 404)
                {
                    return NotFound(requestRes);
                }
            }

            return Ok(requestRes);
        }


    }
}
