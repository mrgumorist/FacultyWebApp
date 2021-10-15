using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Subjects")]
    public class Subject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Shedule> Shedules { get; set; }
        public ICollection<DictionarySubject> DictionarySubjects { get; set; }
    }
}
