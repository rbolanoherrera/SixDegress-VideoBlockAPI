using System.Web.Http;
using VideoBlock.API.Helpers;
using VideoBlock.Business.Interface;
using VideoBlock.Entities;

namespace VideoBlock.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/sec")]
    public class SeguridadController : ApiController
    {
        private readonly ISeguridadBusiness SeguridadBusiness;

        public SeguridadController(ISeguridadBusiness seguridadBusiness)
        {
            SeguridadBusiness = seguridadBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Authenticate([FromBody] User obj)
        {
            var r = SeguridadBusiness.ValidarUsuarioContrasena(obj);

            //r.JWTToken = _JWTTokenHelper.GenerarJWTToken(obj.Name);
            r.Data = r.Data.WithoutPassword();

            return Content(r.StatusCode, r);
        }

    }
}
