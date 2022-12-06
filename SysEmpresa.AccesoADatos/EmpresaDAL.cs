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
    public class EmpresaDAL
    {
        public static async Task<int> CrearAsync(Empresa pEmpresa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                pEmpresa.FechaRegistro = DateTime.Now;
                bdContexto.Add(pEmpresa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Empresa pEmpresa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empresa = await bdContexto.Empresa.FirstOrDefaultAsync(s => s.Id == pEmpresa.Id);
                empresa.Nombre = pEmpresa.Nombre;
                empresa.Descripcion = pEmpresa.Descripcion;
                empresa.CorreoEmpresa = pEmpresa.CorreoEmpresa;
                empresa.Estatus = pEmpresa.Estatus;
                bdContexto.Update(empresa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Empresa pEmpresa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empresa = await bdContexto.Empresa.FirstOrDefaultAsync(s => s.Id == pEmpresa.Id);
                bdContexto.Empresa.Remove(empresa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Empresa> ObtenerPorIdAsync(Empresa pEmpresa)
        {
            var empresa = new Empresa();
            using (var bdContexto = new BDContexto())
            {
                empresa = await bdContexto.Empresa.FirstOrDefaultAsync(s => s.Id == pEmpresa.Id);
            }
            return empresa;
        }
        public static async Task<List<Empresa>> ObtenerTodosAsync()
        {
            var empresas = new List<Empresa>();
            using (var bdContexto = new BDContexto())
            {
                empresas = await bdContexto.Empresa.ToListAsync();
            }
            return empresas;
        }
        internal static IQueryable<Empresa> QuerySelect(IQueryable<Empresa> pQuery, Empresa pEmpresa)
        {
            if (pEmpresa.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEmpresa.Id);
            if (pEmpresa.IdEmpleado > 0)
                pQuery = pQuery.Where(s => s.IdEmpleado == pEmpresa.IdEmpleado);
            if (!string.IsNullOrWhiteSpace(pEmpresa.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEmpresa.Nombre));
            if (!string.IsNullOrWhiteSpace(pEmpresa.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pEmpresa.Descripcion));
            if (!string.IsNullOrWhiteSpace(pEmpresa.CorreoEmpresa))
                pQuery = pQuery.Where(s => s.CorreoEmpresa.Contains(pEmpresa.CorreoEmpresa));
            if (pEmpresa.CantidadEmpleados > 0)
                pQuery = pQuery.Where(s => s.CantidadEmpleados == pEmpresa.CantidadEmpleados);
            if (pEmpresa.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pEmpresa.Estatus);
            if (pEmpresa.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pEmpresa.FechaRegistro.Year, pEmpresa.FechaRegistro.Month, pEmpresa.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pEmpresa.Top_Aux > 0)
                pQuery = pQuery.Take(pEmpresa.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Empresa>> BuscarAsync(Empresa pEmpresa)
        {
            var empresas = new List<Empresa>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empresa.AsQueryable();
                select = QuerySelect(select, pEmpresa);
                empresas = await select.ToListAsync();
            }
            return empresas;
        }

        public static async Task<List<Empresa>> BuscarIncluirEmpleadoAsync(Empresa pEmpresa)
        {
            var empresas = new List<Empresa>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empresa.AsQueryable();
                select = QuerySelect(select, pEmpresa).Include(s => s.Empleado).AsQueryable();
                empresas = await select.ToListAsync();
            }
            return empresas;
        }
    }
}
