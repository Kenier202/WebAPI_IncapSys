using System.ComponentModel.DataAnnotations;

namespace IncapSys.ViewModels.Incapacidades
{
    public class AgregarIncapacidad
    {
        public class AgregarIncapacidadViewModel
        {
            [Required]
            public string LugarAccidente { get; set; }
            [Required]
            [MinLength(5, ErrorMessage = "La descripcion debe tener mas de 5 letras")]
            public string Descripcion { get; set; }
            [Required(ErrorMessage = "UsuarioId es requerido")]
            public int UsuarioId { get; set; }
        }
    }
}
