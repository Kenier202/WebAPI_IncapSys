using IncapSys.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncapSys.ViewModels
{
    public class AgregarIncapacidad
    {
        public class AgregarIncapacidadViewModel
        {
            public int Id { get; set; }
            [Required]
            public string LugarAccidente { get; set; }
            [MinLength(5, ErrorMessage = "La descripcion debe tener mas de 5 letras")]
            public string Descripcion { get; set; }
            [Required]
            public DateTime FechaSuceso { get; set; }
            public int UsuarioId { get; set; }

        }
    }
}
