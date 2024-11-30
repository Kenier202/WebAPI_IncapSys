using IncapTrack.Controllers;
using IncapTrack.Models.Incapacidades;

namespace IncapTrack.Models.Usuarios
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DescripcionIncapacidad Incapacidad { get; set; }

}
}
