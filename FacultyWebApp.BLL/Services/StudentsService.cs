using AutoMapper;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.BLL.Services
{
    public class StudentsService
    {
        private readonly IGenericRepository<Student> _genRepo;
        private readonly ILogger<StudentsService> _logger;
        private readonly IMapper _mapper;

        public StudentsService(IGenericRepository<Student> genRepo, ILogger<StudentsService> logger, IMapper mapper )
        {
            _genRepo = genRepo;
            _logger = logger;
            _mapper = mapper;
        }

        
    }
}
