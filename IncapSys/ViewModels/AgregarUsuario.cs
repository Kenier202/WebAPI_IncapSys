using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IncapSys.ViewModels
{
    public class AgregarUsuario
    {

        [MinLength(4, ErrorMessage = "Debe tener mas de 4 letras")]
        public string Usuario { get; set; }
        [MinLength(1, ErrorMessage = "Debe tener mas de 1 letras o numeros")]
        public string Contraseña { get; set; }
        [MinLength(1, ErrorMessage = "Debe tener mas de 1 numero")]
        [JsonRequired]
        public int RolId { get; set; }

    }
}
