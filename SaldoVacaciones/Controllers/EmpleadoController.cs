using Microsoft.AspNetCore.Mvc;
using SaldoVacaciones.Data;
using SaldoVacaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace SaldoVacaciones.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDBContext; //para lectura

        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;

        }

        //Para listar los empleados
        [HttpGet]
        public async Task< IActionResult> Lista()
        {
            List<Empleado> lista = await _appDBContext.Empleados.ToListAsync(); 
            return View(lista);
        }

        //Para agregar los empleados
        [HttpGet]
        public IActionResult NuevoEmpleado()
        {
            return View();
        }

        //Recibir los datos enviados desde el formulario
        [HttpPost]
        public async Task<IActionResult> NuevoEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _appDBContext.Empleados.Add(empleado);
                await _appDBContext.SaveChangesAsync();
                return RedirectToAction("Lista");
            }

            return View(empleado);  // Si no es válido, devolver el mismo formulario con los errores
        }

        //Para editar los empleados
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.Id == id);
            return View(empleado);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDBContext.Empleados.Update(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        //Para eliminar los empleados
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.Id == id);
            _appDBContext.Empleados.Remove(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
