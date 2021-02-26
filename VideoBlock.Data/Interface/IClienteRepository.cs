using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Interface
{
    public interface IClienteRepository
    {
        Result<Cliente> Registrar(Cliente obj);
    }
}
