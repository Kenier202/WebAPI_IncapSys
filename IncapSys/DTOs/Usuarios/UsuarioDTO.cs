namespace IncapSys.DTOs.Usuarios
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int RolId { get; set; }

    }
}
