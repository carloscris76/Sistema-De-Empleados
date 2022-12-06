using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysEmpresa.EntidadesDeNegocio;
using SysEmpresa.LogicaDeNegocio;

namespace SysEmpresa.UI.AppWebAspCore.Controllers
{
    public class EmpresaController : Controller
    {
        EmpresaBL empresaBL = new EmpresaBL();
        private object empleadoBL;

        // GET: EmpresaController
        public async Task<IActionResult> Index(Empresa pEmpresa = null)
        {
            if (pEmpresa == null)
                pEmpresa = new Empresa();
            if (pEmpresa.Top_Aux == 0)
                pEmpresa.Top_Aux = 10;
            else if (pEmpresa.Top_Aux == -1)
                pEmpresa.Top_Aux = 0;
            var taskBuscar = empresaBL.BuscarIncluirEmpleadoAsync(pEmpresa);
            var taskObtenerTodosEmpleados = empresaBL.ObtenerTodosAsync();
            var empresas = await taskBuscar;
            ViewBag.Top = pEmpresa.Top_Aux;
            ViewBag.Empleados = await taskObtenerTodosEmpleados;
            return View(empresas);
        }


        // GET: EmpresaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empresa = await empresaBL.ObtenerPorIdAsync(new Empresa { Id = id });
            return View(empresa);
        }

        // GET: EmpresaController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Empleados = await empresaBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa pEmpresa)
        {
            try
            {
                int result = await empresaBL.CrearAsync(pEmpresa);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Empleados = await empresaBL.ObtenerTodosAsync();
                return View(pEmpresa);
            }
        }

        // GET: EmpresaController/Edit/5
        public async Task<IActionResult> Edit(Empresa pEmpresa)
        {
            var taskObtenerPorId = empresaBL.ObtenerPorIdAsync(pEmpresa);
            var taskObtenerTodosEmpleados = empresaBL.ObtenerTodosAsync();
            var empresa = await taskObtenerPorId;
            ViewBag.Empresa = await taskObtenerTodosEmpleados;
            ViewBag.Error = "";
            return View(empresa);
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empresa pEmpresa)
        {
            try
            {
                int result = await empresaBL.ModificarAsync(pEmpresa);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Empleados = await empresaBL.ObtenerTodosAsync();
                return View(pEmpresa);
            }
        }

        // GET: EmpresaController/Delete/5
        public async Task<IActionResult> Delete(Empresa pEmpresa)
        {
            var empresa = await empresaBL.ObtenerPorIdAsync(pEmpresa);
            ViewBag.Error = "";
            return View(empresa);
        }

        // POST: EmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Empresa pEmpresa)
        {
            try
            {
                int result = await empresaBL.EliminarAsync(pEmpresa);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpresa);
            }
        }
    }
}
