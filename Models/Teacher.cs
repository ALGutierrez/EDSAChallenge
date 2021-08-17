using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int DNI { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
