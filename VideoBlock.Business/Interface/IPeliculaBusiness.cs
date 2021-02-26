using System.Collections.Generic;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Interface
{
    public interface IPeliculaBusiness
    {
        Result<Pelicula> Registrar(Pelicula obj, List<Actores> listActores);
        Result<List<Pelicula>> GetPeliculasSearch(GeneralFilter filter);
    }
}
