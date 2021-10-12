using FacultyWebApp.DAL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Surname { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string FatherName { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Degree { get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Position { get; set; }

        [Required]
        [RegularExpression(@"/^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$/gm", ErrorMessage = "Incorrect phone number")]
        public string PhoneNum { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
