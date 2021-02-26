using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Interface
{
    public interface ISeguridadRepository
    {
        Result<User> ValidarUsuarioContrasena(User user);
    }
}
