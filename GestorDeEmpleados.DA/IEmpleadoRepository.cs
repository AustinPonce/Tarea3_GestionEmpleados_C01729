using GestorDeEmpleados.Models;

namespace GestorDeEmpleados.DA
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ObtenerTodosLosEmpleadosRegistrados();

        Empleado? ObtenerEmpleadoPorId(int idEmpleado);

        List<Empleado> BuscarEmpleadosPorNombreApellidoODepartamento(
            string textoBusqueda);

        List<Empleado> ObtenerEmpleadosPaginadosSegunBusqueda(
            int numeroPagina,
            int cantidadRegistrosPorPagina,
            string textoBusqueda);

        int ContarCantidadTotalDeEmpleadosFiltrados(string textoBusqueda);

        void AgregarNuevoEmpleado(Empleado nuevoEmpleado);

        void ActualizarDatosDeEmpleado(Empleado empleadoActualizado);

        void AlternarEstadoActivoDelEmpleadoPorId(int idEmpleado);
    }
}