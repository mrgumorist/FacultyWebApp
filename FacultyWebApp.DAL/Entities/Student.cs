using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Surname { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Name { get; set; }

        [Required]
        public int EntryYear { get; set; } = DateTime.Now.Year;

        [Required]
        [RegularExpression(@"/^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$/gm", ErrorMessage = "Incorrect phone number")]
        public string PhoneNum { get; set; }

        public EducationType EducationType { get; set; }
        public int EducationTypeId { get; set; }

        [Required]
        public bool IsDeducted { get; set; } = false;

        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
