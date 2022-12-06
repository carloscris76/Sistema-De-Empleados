using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***************************
using SysEmpresa.EntidadesDeNegocio;
using SysEmpresa.AccesoADatos;

namespace SysEmpresa.LogicaDeNegocio
{
    public class EmpleadoBL
    {
        public async Task<int> CrearAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.CrearAsync(pEmpleado);
        }
        public async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.ModificarAsync(pEmpleado);
        }
        public async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.EliminarAsync(pEmpleado);
        }
        public async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.ObtenerPorIdAsync(pEmpleado);
        }
        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await EmpleadoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.BuscarAsync(pEmpleado);
        }
    }
}