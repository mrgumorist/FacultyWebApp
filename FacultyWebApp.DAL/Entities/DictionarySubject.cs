using FacultyWebApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Dictionaries_Subjects")]
    public class DictionarySubject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Subject Subject { get; set; }
        public Guid SubjectId { get; set; }

        public Dictionary Dictionary { get; set; }
        public Guid DictionaryId { get; set; }
    }
}
