using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacultyWebApp.BLL.DTOs
{
    public class StudentDTO
    {
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

        [Required]
        public int EducationTypeId { get; set; }

        [Required]
        public bool IsDeducted { get; set; } = false;

        [Required]
        public int GroupId { get; set; }
    }
}
