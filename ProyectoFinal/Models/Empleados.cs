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
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public int fechaNacimiento { get; set; }
        public int sueldo { get; set; }
    }
}