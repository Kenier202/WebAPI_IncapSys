using IncapSys.Models.Usuarios;

namespace IncapSys.DTOs.Incapacidades
{
    public class IncapacidadesDto
    {
        public int Id { get; set; }
        public string LugarAccidente { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSuceso { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }


    }
}
