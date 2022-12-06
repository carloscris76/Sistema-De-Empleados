using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using Microsoft.EntityFrameworkCore;
using SysEmpresa.EntidadesDeNegocio;

namespace SysEmpresa.AccesoADatos
{
    public class EmpleadoDAL
    {
        public static async Task<int> CrearAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                pEmpleado.FechaInicio = DateTime.Now;
                bdContexto.Add(pEmpleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                empleado.Nombre = pEmpleado.Nombre;
                empleado.Apellido = pEmpleado.Apellido;
                empleado.Telefono = pEmpleado.Telefono;
                empleado.Direccion = pEmpleado.Direccion;
                empleado.Estatus = pEmpleado.Estatus;
                empleado.Cargo = pEmpleado.Cargo;
                empleado.Edad = pEmpleado.Edad;
                empleado.DUI = pEmpleado.DUI;
                bdContexto.Update(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                bdContexto.Empleado.Remove(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            var empleado = new Empleado();
            using (var bdContexto = new BDContexto())
            {
                empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
            }
            return empleado;
        }
        public static async Task<List<Empleado>> ObtenerTodosAsync()
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                empleados = await bdContexto.Empleado.ToListAsync();
            }
            return empleados;
        }
        internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pEmpleado)
        {
            if (pEmpleado.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEmpleado.Id);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEmpleado.Nombre));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pEmpleado.Apellido));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Telefono))
                pQuery = pQuery.Where(s => s.Apellido == pEmpleado.Telefono);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Edad))
                pQuery = pQuery.Where(s => s.Edad.Contains(pEmpleado.Edad));
            if (pEmpleado.Cargo > 0)
                pQuery = pQuery.Where(s => s.Cargo == pEmpleado.Cargo);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Direccion))
                pQuery = pQuery.Where(s => s.Direccion == pEmpleado.Direccion);
            if (!string.IsNullOrWhiteSpace(pEmpleado.DUI))
                pQuery = pQuery.Where(s => s.DUI == pEmpleado.DUI);
            if (pEmpleado.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pEmpleado.Estatus);
            if (pEmpleado.FechaInicio.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pEmpleado.FechaInicio.Year, pEmpleado.FechaInicio.Month, pEmpleado.FechaInicio.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaInicio >= fechaInicial && s.FechaInicio <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pEmpleado.Top_Aux > 0)
                pQuery = pQuery.Take(pEmpleado.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empleado.AsQueryable();
                select = QuerySelect(select, pEmpleado);
                empleados = await select.ToListAsync();
            }
            return empleados;
        }
    }
}
