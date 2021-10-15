using FacultyWebApp.Domain.Models;
using FacultyWebApp.Domain.Models.ResponseModels.AddictionalProps;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface IDataService
    {
        public List<GroupAddictional> GetAllGroups();
        public List<EducationTypeAddictional> GetAllEducationtypes();
    }
}
