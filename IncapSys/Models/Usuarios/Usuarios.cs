using IncapSys.Models.Rol;
using IncapSys.Models.Incapacidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncapSys.Models.Usuarios
{
    public class Empleados
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        [MinLength(4)]
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }


        [ForeignKey("RolId")]
        public int RolId { get; set; }
        public Roles Rol { get; set; }

        [ForeignKey("IncapacidadId")]
        public int IncapacidadId { get; set; }
        public ICollection<DescripcionIncapacidad> Incapacidades { get; set; }
    }
}
