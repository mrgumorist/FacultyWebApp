using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("EducationTypes")]
    public class EducationType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Required, StringLength(maximumLength: 40)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Dictionary> Dictionaries { get; set; }
    }
}
