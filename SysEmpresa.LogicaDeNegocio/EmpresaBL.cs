﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//***************************
using SysEmpresa.EntidadesDeNegocio;
using SysEmpresa.AccesoADatos;


namespace SysEmpresa.LogicaDeNegocio
{
    public class EmpresaBL
    {
        public async Task<int> CrearAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.CrearAsync(pEmpresa);
        }
        public async Task<int> ModificarAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.ModificarAsync(pEmpresa);
        }
        public async Task<int> EliminarAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.EliminarAsync(pEmpresa);
        }
        public async Task<Empresa> ObtenerPorIdAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.ObtenerPorIdAsync(pEmpresa);
        }
        public async Task<List<Empresa>> ObtenerTodosAsync()
        {
            return await EmpresaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Empresa>> BuscarAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.BuscarAsync(pEmpresa);
        }
        public async Task<List<Empresa>> BuscarIncluirEmpleadoAsync(Empresa pEmpresa)
        {
            return await EmpresaDAL.BuscarIncluirEmpleadoAsync(pEmpresa);
        }
    }
}