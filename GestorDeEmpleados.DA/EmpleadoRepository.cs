using GestorDeEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorDeEmpleados.DA
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _contexto;

        public EmpleadoRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<Empleado> ObtenerTodosLosEmpleadosRegistrados()
        {
            return _contexto.Empleados.ToList();
        }

        public Empleado? ObtenerEmpleadoPorId(int idEmpleado)
        {
            return _contexto.Empleados
                .FirstOrDefault(e => e.Id == idEmpleado);
        }

        public List<Empleado> BuscarEmpleadosPorNombreApellidoODepartamento(
            string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                return ObtenerTodosLosEmpleadosRegistrados();
            }

            textoBusqueda = textoBusqueda.ToLower();

            return _contexto.Empleados
                .Where(e =>
                    e.Nombre.ToLower().Contains(textoBusqueda) ||
                    e.Apellidos.ToLower().Contains(textoBusqueda) ||
                    e.Departamento.ToLower().Contains(textoBusqueda))
                .ToList();
        }

        public List<Empleado> ObtenerEmpleadosPaginadosSegunBusqueda(
            int numeroPagina,
            int cantidadRegistrosPorPagina,
            string textoBusqueda)
        {
            var consulta = _contexto.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                textoBusqueda = textoBusqueda.ToLower();

                consulta = consulta.Where(e =>
                    e.Nombre.ToLower().Contains(textoBusqueda) ||
                    e.Apellidos.ToLower().Contains(textoBusqueda) ||
                    e.Departamento.ToLower().Contains(textoBusqueda));
            }

            return consulta
                .OrderBy(e => e.Id)
                .Skip((numeroPagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina)
                .ToList();
        }

        public int ContarCantidadTotalDeEmpleadosFiltrados(
            string textoBusqueda)
        {
            var consulta = _contexto.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                textoBusqueda = textoBusqueda.ToLower();

                consulta = consulta.Where(e =>
                    e.Nombre.ToLower().Contains(textoBusqueda) ||
                    e.Apellidos.ToLower().Contains(textoBusqueda) ||
                    e.Departamento.ToLower().Contains(textoBusqueda));
            }

            return consulta.Count();
        }

        public void AgregarNuevoEmpleado(Empleado nuevoEmpleado)
        {
            _contexto.Empleados.Add(nuevoEmpleado);
            _contexto.SaveChanges();
        }

        public void ActualizarDatosDeEmpleado(Empleado empleadoActualizado)
        {
            _contexto.Empleados.Update(empleadoActualizado);
            _contexto.SaveChanges();
        }

        public void AlternarEstadoActivoDelEmpleadoPorId(int idEmpleado)
        {
            var empleado = ObtenerEmpleadoPorId(idEmpleado);

            if (empleado == null)
            {
                return;
            }

            empleado.Activo = !empleado.Activo;

            _contexto.SaveChanges();
        }
    }
}