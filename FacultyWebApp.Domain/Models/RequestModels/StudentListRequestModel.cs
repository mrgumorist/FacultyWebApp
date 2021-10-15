using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.Models.RequestModels
{
    public class StudentListRequestModel
    {
        public string Surname { get; set; }
        public bool? IsDeducted { get; set; }
        public int? GroupId { get; set; }
    }
}
