using System.Collections.Generic;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Interface
{
    public interface ITablasGeneralesRepository
    {
        Result<IEnumerable<GeneralTable>> GetAllTiposDocumento(string user);
    }
}
