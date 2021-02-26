using Dapper;
using log4net;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VideoBlock.Data.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Implementation
{
    public class SeguridadRepository : ISeguridadRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SeguridadRepository));

        private string sQuery;
        private string _connectionstring { get; set; }
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionstring);
            }
        }

        public SeguridadRepository()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["ConexionVideoBlock"].ToString();
        }

        public Result<User> ValidarUsuarioContrasena(User user)
        {
            Result<User> result = new Result<User>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    sQuery = string.Format(ObjetosBaseDatos.GetValidarUsuarioPassword, user.Name, user.Password);
                    dbConnection.Open();
                    result.Data = dbConnection.QuerySingle<User>(sQuery);

                    if (result.Data != null)
                    {
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.Message = "Usuario Autorizado";
                    }
                    else
                    {
                        result.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                        result.Message = "Acceso denegado";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contains no elements"))
                {
                    result.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                    result.Message = "Usuario o Contraseña invalidos!";
                    result.Data = null;

                    return result;
                }

                log.Error(ex.Message);

                result.Data = null;
                result.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                result.Message = "Error al autenticarse en el sistema";
            }

            return result;
        }
    }
}
