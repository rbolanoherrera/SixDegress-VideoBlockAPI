using System.Collections.Generic;
using VideoBlock.Business.Interface;
using VideoBlock.Data.Interface;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Implementation
{
    public class TablasGeneralesBusiness : ITablasGeneralesBusiness
    {
        private readonly ITablasGeneralesRepository TablasGeneralesRepository;

        public TablasGeneralesBusiness(ITablasGeneralesRepository tablasGeneralesRepository)
        {
            TablasGeneralesRepository = tablasGeneralesRepository;
        }

        public Result<IEnumerable<GeneralTable>> GetAllTiposDocumento(string user)
        {
            return TablasGeneralesRepository.GetAllTiposDocumento(user);
        }
    }
}
