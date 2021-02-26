using System.Collections.Generic;
using VideoBlock.Business.Interface;
using VideoBlock.Data.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Implementation
{
    public class PeliculaBusiness : IPeliculaBusiness
    {
        private readonly IPeliculaRepository PeliculaRepository;

        public PeliculaBusiness(IPeliculaRepository peliculaRepository)
        {
            PeliculaRepository = peliculaRepository;
        }

        public Result<Pelicula> Registrar(Pelicula obj, List<Actores> listActores)
        {
            return PeliculaRepository.Registrar(obj, listActores);
        }

        public Result<List<Pelicula>> GetPeliculasSearch(GeneralFilter filter)
        {
            return PeliculaRepository.GetPeliculasSearch(filter);
        }
    }
}
