
using System.ComponentModel.DataAnnotations;

namespace IncapSys.ViewModels
{
    public class AgregarUsuario
    {

        [MinLength(4, ErrorMessage = "Debe tener mas de 4 letras")]
        public string Usuario { get; set; }
        [MinLength(1, ErrorMessage = "Debe tener mas de 1 letras")]
        public string Contraseña { get; set; }
        public int RolId { get; set; }

    }
}
