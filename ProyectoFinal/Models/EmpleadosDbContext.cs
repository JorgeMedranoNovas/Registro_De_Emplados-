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
        public DbSet<Vacaciones> Vacaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Vacaciones>()
                .Property(v => v.EmpleadoId)
                .IsRequired();

            modelBuilder.Entity<Vacaciones>()
                .HasRequired(e => e.Empleado)
                .WithMany(x => x.Vacaciones).HasForeignKey(x=>x.EmpleadoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}