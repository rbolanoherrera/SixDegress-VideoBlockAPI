using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VideoBlock.Data.Interface;
using VideoBlock.Entities;
using VideoBlock.Entities.Common;

namespace VideoBlock.Data.Implementation
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PeliculaRepository));
        private string sQuery;
        private string _connectionstring { get; set; }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionstring);
            }
        }

        public PeliculaRepository()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["ConexionVideoBlock"].ToString();
        }


        public Result<Pelicula> Registrar(Pelicula obj, List<Actores> listActores)
        {
            Result<Pelicula> result = new Result<Pelicula>();
            int actors = 0;
            try
            {
                using (IDbConnection conn = Connection)
                {
                    sQuery = ObjetosBaseDatos.InsertPelicula;

                    DynamicParameters dp = new DynamicParameters();

                    dp.Add("@id", obj.Id, DbType.Int32, ParameterDirection.Output);
                    dp.Add("@titulo", obj.Titulo, DbType.String);
                    dp.Add("@descripcion", obj.Descripcion, DbType.String);
                    dp.Add("@director", obj.Director, DbType.String);
                    dp.Add("@costo", obj.Costo, DbType.Decimal);
                    dp.Add("@cantidad", obj.Cantidad, DbType.Int32);

                    conn.Open();
                    conn.Execute(sql: sQuery, param: dp, commandType: CommandType.StoredProcedure);
                    obj.Id = dp.Get<int>("@id");

                    if (obj.Id > 0)
                    {
                        int re1 = conn.Execute(string.Format(ObjetosBaseDatos.DeleteActoresPelicula, obj.Id));

                        foreach (Actores item in listActores)
                        {
                            int re2 = conn.Execute(string.Format(ObjetosBaseDatos.InsertPeliculaActores, obj.Id, item.Id));

                            if (re2 > 0)
                                actors += 1;
                        }

                        if (actors >= listActores.Count)
                        {
                            result.Data = obj;
                            result.StatusCode = System.Net.HttpStatusCode.OK;
                            result.Message = "Pelicula registrada exitosamente!";
                        }
                        else
                        {
                            result.Data = null;
                            result.StatusCode = System.Net.HttpStatusCode.BadRequest;
                            result.Message = "No se pudo asignar los Actores a la Pelicula!";
                        }

                    }
                    else
                    {
                        result.Data = null;
                        result.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        result.Message = "No se pudo registrar la Pelicula!";
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY") && ex.Message.Contains("CK_Pelicula_Titulo"))
                {
                    result.Data = null;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.Message = "Ya existe una Pelicula con el Titulo especificado";

                    return result;
                }

                log.Error(ex.Message);

                result.Data = null;
                result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                result.Message = "Error desconocido al crear la Pelicula";
            }

            return result;
        }

        public Result<List<Pelicula>> GetPeliculasSearch(GeneralFilter filter)
        {
            Result<List<Pelicula>> result = new Result<List<Pelicula>>();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    sQuery = ObjetosBaseDatos.GetPeliculasFiltradas;

                    DynamicParameters dp = new DynamicParameters();

                    if (!string.IsNullOrEmpty(filter.String1))
                        dp.Add("@buscar", filter.String1, DbType.String, ParameterDirection.Input);

                    conn.Open();
                    var re = conn.Query<Pelicula>(sql: sQuery, commandType: CommandType.StoredProcedure, param: dp);

                    if (re != null && re.Count() > 0)
                        result.Data = re.Cast<Pelicula>().ToList();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("Sequence contains no elements"))
                    log.Error(ex.Message);
            }

            return result;
        }

    }
}
