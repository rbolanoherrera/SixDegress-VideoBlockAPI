namespace VideoBlock.Data
{
    public static class ObjetosBaseDatos
    {
        public const string InsertCliente = "SP_INS_CLIENTE";
        public const string GetAllTiposDocumentos = "select * from TipoDocumento order by nombre";
        public const string GetValidarUsuarioPassword = "select * from AppUser where Name= '{0}' and Password= '{1}';";
        public const string InsertPelicula = "SP_INS_PELICULA";
        public const string DeleteActoresPelicula = "delete from PeliculaActores where PeliculaId={0}";
        public const string InsertPeliculaActores = "insert into PeliculaActores (PeliculaId, ActorId) values ({0},{1})";
        public const string GetPeliculasFiltradas = "SP_GET_PELICULAS_FILTER";
    }
}
