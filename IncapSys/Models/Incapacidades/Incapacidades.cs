using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncapSys.Models.Incapacidades
{
    public class DescripcionIncapacidad
    {
        [Key]
        public int Id { get; set; }
        public string LugarAccidente { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSuceso { get; set; }

        // Clave foránea hacia la entidad Usuario
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        // Propiedad de navegación hacia Usuario
        public Empleados usuario { get; set; }
    }
}
