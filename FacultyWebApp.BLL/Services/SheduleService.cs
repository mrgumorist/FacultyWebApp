using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.BLL.Infrastructure;
using FacultyWebApp.BLL.Interfaces;
using FacultyWebApp.DAL.Entities;
using FacultyWebApp.DAL.Interfaces;
using FacultyWebApp.Domain.Models.ResponseModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyWebApp.BLL.Services
{
    public class SheduleService : ISheduleService
    {
        private readonly IGenericRepository<Shedule> _genericRepo;
        private readonly IGenericRepository<Teacher> _teacherscRepo;
        private readonly IGenericRepository<Subject> _subjectscRepo;
        private readonly IGenericRepository<Group> _groupsRepo;
        private readonly ILogger<SheduleService> _logger;
        public SheduleService(IGenericRepository<Shedule> genericRepo, IGenericRepository<Teacher> teacherscRepo, IGenericRepository<Subject> subjectscRepo, IGenericRepository<Group> groupscRepo, ILogger<SheduleService> logger)
        {
            _genericRepo = genericRepo;
            _teacherscRepo = teacherscRepo;
            _subjectscRepo = subjectscRepo;
            _groupsRepo = groupscRepo;
            _logger = logger;
        }

        public void AddToShudule(SheduleDTO sheduleItemDTO)
        {
            var sheduleItem = new Shedule()
            {
                GroupId = sheduleItemDTO.GroupId,
                Semester = sheduleItemDTO.Semester,
                SubjectId = sheduleItemDTO.SubjectId,
                TeacherId = sheduleItemDTO.TeacherId,
                Time = sheduleItemDTO.Time,
                IsDeleted = false
            };

            _genericRepo.Add(sheduleItem);
        }

        public List<SheduleItemResponseModel> GetShedule(int groupId)
        {
            List<SheduleItemResponseModel> shedule = new List<SheduleItemResponseModel>();
            var shedulesQuaryable = _genericRepo.GetAllIQueryable();
            var teachersQuaryable = _teacherscRepo.GetAllIQueryable();
            var groupsQuaryable = _groupsRepo.GetAllIQueryable();
            var subjectsQuaryable = _subjectscRepo.GetAllIQueryable();

            shedulesQuaryable = shedulesQuaryable.Where(x => x.GroupId == groupId);

            shedulesQuaryable = shedulesQuaryable.Where(x => !x.IsDeleted);

            shedule = (from c in shedulesQuaryable
                       join o in teachersQuaryable on c.TeacherId equals o.Id
                       join s in groupsQuaryable on c.GroupId equals s.Id
                       join i in subjectsQuaryable on c.SubjectId equals i.Id
                       select new SheduleItemResponseModel() 
                       {
                           DayofWeek=c.Time.DayOfWeek.ToString(),
                           Time=c.Time,
                           TeacherId=c.TeacherId,
                           TeacherName=o.Name+" "+o.Surname,
                           GroupId=c.GroupId,
                           GroupName=s.Code,
                           SubjectId=c.SubjectId,
                           SubjectName=i.Name
                       }).ToList();

            if (shedule.Count == 0)
            {
                throw new ValidationException("Count of shedule items by filter is 0", "Count");
            }

            return shedule;
        }

        public List<SheduleItemResponseModel> GetShedule()
        {
            List<SheduleItemResponseModel> shedule = new List<SheduleItemResponseModel>();
            var shedulesQuaryable = _genericRepo.GetAllIQueryable();
            var teachersQuaryable = _teacherscRepo.GetAllIQueryable();
            var groupsQuaryable = _groupsRepo.GetAllIQueryable();
            var subjectsQuaryable = _subjectscRepo.GetAllIQueryable();

            shedulesQuaryable = shedulesQuaryable.Where(x => !x.IsDeleted);

            shedule = (from c in shedulesQuaryable
                       join o in teachersQuaryable on c.TeacherId equals o.Id
                       join s in groupsQuaryable on c.GroupId equals s.Id
                       join i in subjectsQuaryable on c.SubjectId equals i.Id
                       select new SheduleItemResponseModel()
                       {
                           DayofWeek = c.Time.DayOfWeek.ToString(),
                           Time = c.Time,
                           TeacherId = c.TeacherId,
                           TeacherName = o.Name + " " + o.Surname,
                           GroupId = c.GroupId,
                           GroupName = s.Code,
                           SubjectId = c.SubjectId,
                           SubjectName = i.Name
                       }).ToList();

            if (shedule.Count == 0)
            {
                throw new ValidationException("Count of shedule items by filter is 0", "Count");
            }

            return shedule;
        }
    }
}
