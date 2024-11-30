namespace IncapSys.DTOs.Usuarios
{
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
    }
}
