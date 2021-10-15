using FacultyWebApp.BLL.Interfaces;
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
    public class DataController : ControllerBase
    {

        private readonly IDataService _dataService;
        private readonly ILogger<DataController> _logger;

        public DataController(IDataService dataService, ILogger<DataController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet("GetAllGroups")]
        public IActionResult GetAllGroups()
        {
            return Ok(_dataService.GetAllGroups());
        }

        [HttpGet("GetAllEducationTypes")]
        public IActionResult GetAllEducationTypes()
        {
            return Ok(_dataService.GetAllEducationtypes());
        }


    }
}
