using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VideoBlock.Data.Interface;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Implementation
{
    public class TablasGeneralesRepository : ITablasGeneralesRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TablasGeneralesRepository));

        private string sQuery;
        private string _connectionstring { get; set; }
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionstring);
            }
        }

        public TablasGeneralesRepository()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["ConexionVideoBlock"].ToString();
        }

        public Result<IEnumerable<GeneralTable>> GetAllTiposDocumento(string user)
        {
            Result<IEnumerable<GeneralTable>> result = new Result<IEnumerable<GeneralTable>>();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    sQuery = ObjetosBaseDatos.GetAllTiposDocumentos;

                    conn.Open();
                    result.Data = conn.Query<GeneralTable>(sQuery);
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                    result.Message = "Tipos de Documentos listados exitosamente";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                result.Data = null;
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                result.Message = "Error al obtener el listado de los tipos de documentos";
            }

            return result;
        }
    }
}
