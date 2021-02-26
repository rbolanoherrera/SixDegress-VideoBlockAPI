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
    public class ClienteRepository : IClienteRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ClienteRepository));
        private string sQuery;
        private string _connectionstring { get; set; }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionstring);
            }
        }

        public ClienteRepository()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["ConexionVideoBlock"].ToString();
        }

        public Result<Cliente> Registrar(Cliente obj)
        {
            Result<Cliente> result = new Result<Cliente>();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    sQuery = ObjetosBaseDatos.InsertCliente;

                    DynamicParameters dp = new DynamicParameters();

                    dp.Add("@Id", obj.Id, DbType.Int32, ParameterDirection.Output);
                    dp.Add("@@TipoDocumentoId", obj.TipoDocumentoId, DbType.Int32);
                    dp.Add("@documento", obj.Documento, DbType.String);
                    dp.Add("@nombre1", obj.Nombre1, DbType.String);
                    dp.Add("@nombre2", obj.Nombre2, DbType.String);
                    dp.Add("@apellido1", obj.Apellido1, DbType.String);
                    dp.Add("@apellido2", obj.Apellido2, DbType.String);
                    dp.Add("@celular", obj.Celular, DbType.String);
                    dp.Add("@direccion", obj.Direccion, DbType.String);
                    dp.Add("@email", obj.Direccion, DbType.String);
                    dp.Add("@estado", obj.Estado, DbType.Int32);

                    conn.Open();
                    conn.Execute(sql: sQuery, param: dp, commandType: CommandType.StoredProcedure);
                    int id = dp.Get<int>("@Id");

                    if (id > 0)
                    {
                        obj.Id = id;
                        result.Data = obj;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.Message = "Cliente registrado exitosamente!";
                    }
                    else
                    {
                        result.Data = null;
                        result.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        result.Message = "No se pudo registrar el Cliente!";
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY") && ex.Message.Contains("UX_ClienteTipoAndDocumento"))
                {
                    result.Data = null;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.Message = "Ya existe un Cliente con el mismo Tipo y número de Documento";

                    return result;
                }

                log.Error(ex.Message);
                result.Data = null;
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                result.Message = "Error desconocido al crear el Cliente";
            }

            return result;
        }
    }
}
