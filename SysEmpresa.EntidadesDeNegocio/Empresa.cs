using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ********************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysEmpresa.EntidadesDeNegocio
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Empleado")]
        [Required(ErrorMessage = "Empleado es obligatorio")]
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Nombre { get; set; }
        public int CantidadEmpleados { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "CorreoEmpresa es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string CorreoEmpresa { get; set; }
        public Empleado Empleado { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Estatus_Empresa
    {
        ACTIVO = 1,
        INACTIVO = 2,
        ENREGISTRO = 3
    }
}