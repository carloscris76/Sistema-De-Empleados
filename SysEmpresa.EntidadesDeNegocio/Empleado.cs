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
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Telefono es obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Edad es obligatorio")]
        [StringLength(5, ErrorMessage = "Maximo 5 caracteres")]
        public string Edad { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        [Required(ErrorMessage = "Cargo es obligatorio")]
        public byte Cargo { get; set; }
        public enum Estatus_Cargo
        {
            EMPLEADO = 1,
            VENDEDOR = 2,
            ADMINISTRADOR = 3,
            LIMPIEZA = 4,
            PROGRAMADORES = 5
        }
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "DUI es obligatorio")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string DUI { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Empresa> Empresa { get; set; }
    }
    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
