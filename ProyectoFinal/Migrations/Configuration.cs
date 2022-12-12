namespace ProyectoFinal.Migrations
{
    using ProyectoFinal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmpleadosDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmpleadosDbContext context)
        {
            context.Set<Empleados>().Add(new Empleados()
            {
                Nombre = "Admin",
                Apellido = "Admin",
                Telefono = "829-935-0913",
                Direccion = "Calle la Real",
                Username = "admin",
                Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                FechaNacimiento = DateTime.Now,
                Sueldo = 100000
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
