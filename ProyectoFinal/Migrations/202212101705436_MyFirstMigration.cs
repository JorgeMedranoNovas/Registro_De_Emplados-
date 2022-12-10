namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        idEmpleado = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellido = c.String(),
                        telefono = c.Int(nullable: false),
                        direccion = c.String(),
                        fechaNacimiento = c.Int(nullable: false),
                        sueldo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmpleado);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleados");
        }
    }
}
