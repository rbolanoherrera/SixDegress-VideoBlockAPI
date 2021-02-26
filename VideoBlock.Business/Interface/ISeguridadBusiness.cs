using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Interface
{
    public interface ISeguridadBusiness
    {
        Result<User> ValidarUsuarioContrasena(User user);
    }
}
