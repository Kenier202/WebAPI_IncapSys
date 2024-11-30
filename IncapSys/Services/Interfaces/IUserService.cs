using IncapSys.Helpers;
using IncapSys.Models.Usuarios;

namespace IncapSys.Services.Interfaces
{
    public interface IUserService : IBaseInterface<Empleados>
    {
        Task<Response<bool>> ExisteUsuario(int idUsuario);

    }
}
