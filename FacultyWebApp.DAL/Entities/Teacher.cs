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
        [PhoneMask("+380631111111",
         ErrorMessage = "{0} value does not match the mask {1}.")]
        public string PhoneNum { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
