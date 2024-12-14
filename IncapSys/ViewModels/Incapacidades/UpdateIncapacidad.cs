using System.ComponentModel.DataAnnotations;

namespace IncapSys.ViewModels.Incapacidades
{
    public class UpdateIncapacidad
    {
        public class UpdateIncapacidadViewModel
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string LugarAccidente { get; set; }
            [MinLength(5, ErrorMessage = "La descripcion debe tener mas de 5 letras")]
            public string Descripcion { get; set; }
            [Required]
            public string UsuarioId { get; set; }

        }
    }
}
