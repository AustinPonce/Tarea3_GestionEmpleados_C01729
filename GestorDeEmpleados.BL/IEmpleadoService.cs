using GestorDeEmpleados.Models;

namespace GestorDeEmpleados.BL
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerEmpleadosPaginadosParaMostrar(
            int numeroPagina,
            int cantidadRegistrosPorPagina,
            string textoBusqueda);

        int ObtenerCantidadTotalDeEmpleadosFiltrados(
            string textoBusqueda);

        Empleado? ObtenerEmpleadoExistentePorId(
            int idEmpleado);

        void RegistrarNuevoEmpleado(
            Empleado nuevoEmpleado);

        void EditarInformacionDeEmpleado(
            Empleado empleadoEditado);

        void CambiarEstadoActivoDelEmpleado(
            int idEmpleado);

        List<Empleado> ObtenerTodosLosEmpleados();
    }
}