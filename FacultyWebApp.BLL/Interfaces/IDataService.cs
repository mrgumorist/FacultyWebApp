using FacultyWebApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface IDataService
    {
        public List<GroupDTO> GetAllGroups();
        public List<EducationTypeDTO> GetAllEducationtypes();
        public List<DegreeDTO> GetAllDegries();
    }
}
