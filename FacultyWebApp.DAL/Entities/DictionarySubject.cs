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
        [Key]
        public int Id { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public Dictionary Dictionary { get; set; }
        public int DictionaryId { get; set; }

    }
}
