using IncapSys.Models.Incapacidades;
using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace IncapSys.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> config) : base (config)  { }

       public DbSet<Empleados> Usuarios { get; set; }
       public DbSet<Roles> Roles { get; set; }
       public DbSet<DescripcionIncapacidad> Incapacidades { get; set; }
    }
}
