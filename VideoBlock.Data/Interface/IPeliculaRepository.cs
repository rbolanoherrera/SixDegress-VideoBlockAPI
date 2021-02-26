using System.Collections.Generic;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Interface
{
    public interface IPeliculaRepository
    {
        Result<Pelicula> Registrar(Pelicula obj, List<Actores> listActores);
        Result<List<Pelicula>> GetPeliculasSearch(GeneralFilter filter);
    }
}
