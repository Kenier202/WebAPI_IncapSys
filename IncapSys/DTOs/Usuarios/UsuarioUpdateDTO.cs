namespace IncapSys.DTOs.Usuarios
{
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
    }
}
