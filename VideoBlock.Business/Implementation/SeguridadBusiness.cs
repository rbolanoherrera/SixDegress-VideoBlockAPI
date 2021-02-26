using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBlock.Business.Interface;
using VideoBlock.Data.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Business.Implementation
{
    public class SeguridadBusiness : ISeguridadBusiness
    {
        private readonly ISeguridadRepository SeguridadRepository;

        public SeguridadBusiness(ISeguridadRepository seguridadRepository)
        {
            SeguridadRepository = seguridadRepository;
        }

        public Result<User> ValidarUsuarioContrasena(User user)
        {
            return SeguridadRepository.ValidarUsuarioContrasena(user);
        }
    }
}
