using System;
using System.ComponentModel.DataAnnotations;

namespace GestorDeEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80, ErrorMessage = "Máximo 80 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(400000, 10000000,
            ErrorMessage = "El salario debe estar entre 400000 y 10000000")]
        public decimal Salario { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellidos}"; }
        }
    }
}