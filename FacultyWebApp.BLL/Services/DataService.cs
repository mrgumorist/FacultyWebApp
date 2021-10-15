using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacultyWebApp.BLL.Services
{
    public class DataService:IDataService
    {
        private readonly IGenericRepository<Group> _groupsRepo;
        private readonly IGenericRepository<EducationType> _educatinTypesRepo;
        private readonly ILogger<DataService> _logger;

        public DataService(ILogger<DataService> logger, IGenericRepository<Group> groupsRepo, IGenericRepository<EducationType> educatinTypesRepo)
        {
            _logger = logger;
            _groupsRepo = groupsRepo;
            _educatinTypesRepo = educatinTypesRepo;
        }

        public List<GroupDTO> GetAllGroups()
        {
            return _groupsRepo.GetAll().Select(x => new GroupDTO() { Id = x.Id, Code = x.Code }).ToList(); 
        }

        public List<EducationTypeDTO> GetAllEducationtypes()
        {
            return _educatinTypesRepo.GetAll().Select(x => new EducationTypeDTO() { Id = x.Id, Description = x.Description, Name = x.Name }).ToList();
        }
    }
}
