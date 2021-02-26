using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Interface
{
    public interface IClienteBusiness
    {
        Result<Cliente> Registrar(Cliente obj);
    }
}
