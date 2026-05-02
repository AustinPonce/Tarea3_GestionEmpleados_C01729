using Microsoft.AspNetCore.Mvc;
using GestorDeEmpleados.BL;
using GestorDeEmpleados.Models;

namespace GestorDeEmpleados.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(
            IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public IActionResult Index(
            string busqueda = "",
            int pagina = 1)
        {
            int cantidadRegistrosPorPagina = 5;

            var empleados =
                _empleadoService.ObtenerEmpleadosPaginadosParaMostrar(
                    pagina,
                    cantidadRegistrosPorPagina,
                    busqueda);

            int totalRegistros =
                _empleadoService.ObtenerCantidadTotalDeEmpleadosFiltrados(
                    busqueda);

            int totalPaginas =
                (int)Math.Ceiling(
                    (double)totalRegistros /
                    cantidadRegistrosPorPagina);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.TotalRegistros = totalRegistros;

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            Empleado nuevoEmpleado)
        {
            if (!ModelState.IsValid)
            {
                return View(nuevoEmpleado);
            }

            _empleadoService
                .RegistrarNuevoEmpleado(
                    nuevoEmpleado);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var empleado =
                _empleadoService
                    .ObtenerEmpleadoExistentePorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult Edit(
            Empleado empleadoEditado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleadoEditado);
            }

            _empleadoService
                .EditarInformacionDeEmpleado(
                    empleadoEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            _empleadoService
                .CambiarEstadoActivoDelEmpleado(id);

            return RedirectToAction(nameof(Index));
        }
    }
}