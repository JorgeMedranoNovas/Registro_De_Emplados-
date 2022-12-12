namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lkjj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Sueldo = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Vacaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacaciones", "EmpleadoId", "dbo.Empleados");
            DropIndex("dbo.Vacaciones", new[] { "EmpleadoId" });
            DropTable("dbo.Vacaciones");
            DropTable("dbo.Empleados");
        }
    }
}
