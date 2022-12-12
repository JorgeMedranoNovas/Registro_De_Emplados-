using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Range(10000,9999999999,ErrorMessage ="Debes insertar un sueldo minimo de 10,000")]
        public int Sueldo { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Vacaciones> Vacaciones { get; set; }
    }
}