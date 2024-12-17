using IncapSys.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncapSys.Models.Rol
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)] 
        public string Name { get; set; }
    }

}
