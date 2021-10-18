using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacultyWebApp.BLL.DTOs
{
    public class SheduleDTO
    {
        public Guid Id { get; set; }

        [Required]
        [SemesterMask("2_2021",
            ErrorMessage = "{0} value does not match the mask {1}.")]
        public string Semester { get; set; }

        public int SubjectId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int TeacherId { get; set; }

        public int GroupId { get; set; }
    }
}
