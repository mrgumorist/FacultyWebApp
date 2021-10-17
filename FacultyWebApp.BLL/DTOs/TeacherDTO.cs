using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacultyWebApp.BLL.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Surname { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string FatherName { get; set; }
        public int DegreeId { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Position { get; set; }

        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Incorrect phone number")]
        public string PhoneNum { get; set; }
    }
}
