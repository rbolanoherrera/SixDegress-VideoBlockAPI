using System.Collections.Generic;
using System.Web.Http;
using VideoBlock.Business.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.API.Controllers
{
    [RoutePrefix("api/peli")]
    public class PeliculaController : ApiController
    {
        private readonly IPeliculaBusiness PeliculaBusiness;

        public PeliculaController(IPeliculaBusiness peliculaBusiness)
        {
            PeliculaBusiness = peliculaBusiness;
        }

        [HttpPost]
        [Route("add")]
        public Result<Pelicula> Crear([FromBody] Pelicula model, string actores="")
        {
            var listActores = new List<Actores>();

            var re = PeliculaBusiness.Registrar(model, listActores);

            return re;
        }

        [HttpPost]
        [Route("getFiltered")]
        public Result<List<Pelicula>> BuscarPeliculas([FromBody] GeneralFilter model)
        {
            var re = PeliculaBusiness.GetPeliculasSearch(model);

            return re;
        }

    }
}
