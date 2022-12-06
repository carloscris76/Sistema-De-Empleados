using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysEmpresa.EntidadesDeNegocio;
using SysEmpresa.LogicaDeNegocio;

namespace SysEmpresa.UI.AppWebAspCore.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoBL empleadoBL = new EmpleadoBL();
        // GET: RolController
        public async Task<IActionResult> Index(Empleado pEmpleado = null)
        {
            if (pEmpleado == null)
                pEmpleado = new Empleado();
            if (pEmpleado.Top_Aux == 0)
                pEmpleado.Top_Aux = 10;
            else if (pEmpleado.Top_Aux == -1)
                pEmpleado.Top_Aux = 0;
            var empleados = await empleadoBL.BuscarAsync(pEmpleado);
            ViewBag.Top = pEmpleado.Top_Aux;
            return View(empleados);
        }
        // GET: RolController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(new Empleado { Id = id });
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado pEmpleado)
        {
            try
            {
                int empleado = await empleadoBL.CrearAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult> Edit(Empleado pEmpleado)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            ViewBag.Error = "";
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.ModificarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<IActionResult> Delete(Empleado pEmpleado)
        {
            ViewBag.Error = "";
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.EliminarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }
    }
}
