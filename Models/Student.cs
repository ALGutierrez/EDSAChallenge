using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(100)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El Nombre debe tener entre 1 y 100 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El DNI es obligatorio")]
        [Range(10000000, 40000000, ErrorMessage = "Rango no valido")]
        public int DNI { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public int IdGrade { get; set; }

        [ForeignKey("IdGrade")]
        public virtual Grade Grade { get; set; }
    }
}
