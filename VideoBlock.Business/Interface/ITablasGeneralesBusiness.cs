using System.Collections.Generic;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Interface
{
    public interface ITablasGeneralesBusiness
    {
        Result<IEnumerable<GeneralTable>> GetAllTiposDocumento(string user);
    }
}
