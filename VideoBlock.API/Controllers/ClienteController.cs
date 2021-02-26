using log4net;
using System.Web.Http;
using VideoBlock.Business.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.API.Controllers
{
    [RoutePrefix("api/customer")]
    public class ClienteController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ClienteController));
        private readonly IClienteBusiness ClienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            ClienteBusiness = clienteBusiness;
        }

        /// <summary>
        /// Crear Clientes
        /// </summary>
        /// <param name="model"><see cref="Cliente"/></param>
        /// <returns></returns>
        //public IHttpActionResult Post([FromBody] Cliente model)
        [HttpPost]
        [Route("add")]
        public Result<Cliente> Crear([FromBody] Cliente model)
        {
            var re = ClienteBusiness.Registrar(model);

            return re;
        }
    }
}
