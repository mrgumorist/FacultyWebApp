using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.Models.RequestModels
{
    public class TeacherListRequestModel
    {
        public string Surname { get; set; }
        public int? SubjectId { get; set; }
        public int? DegreeId { get; set; }
    }
}
