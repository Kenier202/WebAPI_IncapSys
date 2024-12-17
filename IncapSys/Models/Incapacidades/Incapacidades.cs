using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IncapSys.Models.Incapacidades
{
    public class DescripcionIncapacidad
    {
        [Key]
        public int Id { get; set; }
        public string LugarAccidente { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSuceso { get; set; }

        // Relación con Empleados (uno a muchos)
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Empleados Usuario { get; set; } // Nombre PascalCase
    }

}
