using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Dictionaries")]
    public class Dictionary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Education { get; set; }

        public ICollection<DictionarySubject> DictionarySubjects { get; set; }

        public  EducationType EducationType { get; set; }
        public int EducationTypeId { get; set; }
    }
}
