using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class EmpleadosDbContext : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
    }
}