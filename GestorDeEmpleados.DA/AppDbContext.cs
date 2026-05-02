using GestorDeEmpleados.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GestorDeEmpleados.DA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 1,
                    Nombre = "Ana",
                    Apellidos = "Ramirez",
                    Departamento = "TI",
                    Salario = 800000,
                    FechaIngreso = new DateTime(2022, 1, 10),
                    Activo = true
                },
                new Empleado
                {
                    Id = 2,
                    Nombre = "Carlos",
                    Apellidos = "Lopez",
                    Departamento = "RH",
                    Salario = 650000,
                    FechaIngreso = new DateTime(2021, 5, 20),
                    Activo = true
                }
            );
        }
    }
}