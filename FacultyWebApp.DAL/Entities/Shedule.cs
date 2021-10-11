using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Shedules")]
    public class Shedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [SemesterMask("2_2021",
            ErrorMessage = "{0} value does not match the mask {1}.")]
        public string Semester { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
