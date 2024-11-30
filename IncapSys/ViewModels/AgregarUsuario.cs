using IncapSys.Models.Incapacidades;
using IncapSys.Models.Rol;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IncapSys.ViewModels
{
    public class AgregarUsuario
    {
        public int Id { get; set; }
        [MinLength(4,ErrorMessage ="Debe tener mas de 4 letras")]
        public string Usuario { get; set; }
        [MinLength(4, ErrorMessage = "Debe tener mas de 4 letras")]
        public string Contraseña { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public int RolId { get; set; }
        [MinLength(2, ErrorMessage = "Debe tener mas de 2 letras")]
        public int IncapacidadId { get; set; }
    }
}
