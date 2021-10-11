using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacultyWebApp.DAL.Entities
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Shedule> Shedules { get; set; }
    }
}
