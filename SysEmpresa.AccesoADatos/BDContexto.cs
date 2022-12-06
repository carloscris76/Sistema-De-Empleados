using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ********************************
using Microsoft.EntityFrameworkCore;
using SysEmpresa.EntidadesDeNegocio;

namespace SysEmpresa.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DEV01\SQLEXPRESS02;Initial Catalog=SeguridadWebdb;Integrated Security=True");
        }
    }
}

