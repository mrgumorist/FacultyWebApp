using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.Models.RequestModels
{
    public class StudentListRequestModel
    {
        string Surname { get; set; }
        bool? IsDeducted { get; set; }
        int? GroupId { get; set; }
    }
}
