using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacultyWebApp.BLL.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Surname { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Name { get; set; }

        [Required]
        public int EntryYear { get; set; } = DateTime.Now.Year;

        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Incorrect phone number")]
        public string PhoneNum { get; set; }

        [Required]
        public Guid EducationTypeId { get; set; }

        [Required]
        public bool IsDeducted { get; set; } = false;

        [Required]
        public Guid GroupId { get; set; }
    }
}
