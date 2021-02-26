using System.Web.Http;
using VideoBlock.Business.Interface;

namespace VideoBlock.API.Controllers
{
    [RoutePrefix("api/gen-tables")]
    public class TablasGeneralesController : ApiController
    {
        private readonly ITablasGeneralesBusiness TablasGeneralesBusiness;

        public TablasGeneralesController(ITablasGeneralesBusiness tablasGeneralesBusiness)
        {
            TablasGeneralesBusiness = tablasGeneralesBusiness;
        }

        [HttpGet]
        [Route("getAllTipoDoc")]
        public IHttpActionResult GetAllTiposDocumentos(string user="")
        {
            var r = TablasGeneralesBusiness.GetAllTiposDocumento(user ?? "ralfs");
            //r.JWTToken = _JWTTokenHelper.GenerarJWTToken(user);

            return Content(r.StatusCode, r);
        }
    }
}
