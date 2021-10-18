using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.Models.ResponseModels
{
    public class SheduleItemResponseModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public string DayofWeek { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public DateTime Time { get; set; }
    }
}
