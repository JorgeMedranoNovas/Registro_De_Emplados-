using System;

namespace ProyectoFinal.Models
{
    public class Vacaciones
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int EmpleadoId { get; set; }
        public Empleados Empleado { get; set; }
    }
}