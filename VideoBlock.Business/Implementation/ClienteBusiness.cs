using VideoBlock.Business.Interface;
using VideoBlock.Data.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Implementation
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository ClienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            ClienteRepository = clienteRepository;
        }


        public Result<Cliente> Registrar(Cliente obj)
        {
            return ClienteRepository.Registrar(obj);
        }
    }
}
