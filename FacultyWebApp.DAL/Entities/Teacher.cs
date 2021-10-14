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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Incorrect phone number")]
        public string PhoneNum { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
