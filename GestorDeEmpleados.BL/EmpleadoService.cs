using GestorDeEmpleados.DA;
using GestorDeEmpleados.Models;

namespace GestorDeEmpleados.BL
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repositorioEmpleado;

        public EmpleadoService(
            IEmpleadoRepository repositorioEmpleado)
        {
            _repositorioEmpleado = repositorioEmpleado;
        }

        public List<Empleado> ObtenerEmpleadosPaginadosParaMostrar(
            int numeroPagina,
            int cantidadRegistrosPorPagina,
            string textoBusqueda)
        {
            if (numeroPagina <= 0)
            {
                numeroPagina = 1;
            }

            if (cantidadRegistrosPorPagina <= 0)
            {
                cantidadRegistrosPorPagina = 5;
            }

            return _repositorioEmpleado
                .ObtenerEmpleadosPaginadosSegunBusqueda(
                    numeroPagina,
                    cantidadRegistrosPorPagina,
                    textoBusqueda);
        }

        public int ObtenerCantidadTotalDeEmpleadosFiltrados(
            string textoBusqueda)
        {
            return _repositorioEmpleado
                .ContarCantidadTotalDeEmpleadosFiltrados(
                    textoBusqueda);
        }

        public Empleado? ObtenerEmpleadoExistentePorId(
            int idEmpleado)
        {
            return _repositorioEmpleado
                .ObtenerEmpleadoPorId(idEmpleado);
        }

        public void RegistrarNuevoEmpleado(
            Empleado nuevoEmpleado)
        {
            nuevoEmpleado.FechaIngreso = DateTime.Now;
            nuevoEmpleado.Activo = true;

            _repositorioEmpleado
                .AgregarNuevoEmpleado(nuevoEmpleado);
        }

        public void EditarInformacionDeEmpleado(
            Empleado empleadoEditado)
        {
            _repositorioEmpleado
                .ActualizarDatosDeEmpleado(
                    empleadoEditado);
        }

        public void CambiarEstadoActivoDelEmpleado(
            int idEmpleado)
        {
            _repositorioEmpleado
                .AlternarEstadoActivoDelEmpleadoPorId(
                    idEmpleado);
        }

        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            return _repositorioEmpleado
                .ObtenerTodosLosEmpleadosRegistrados();
        }
    }
}