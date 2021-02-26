namespace VideoBlock.Data
{
    public static class ObjetosBaseDatos
    {
        public const string InsertCliente = "SP_INS_CLIENTE";
        public const string GetAllTiposDocumentos = "select * from TipoDocumento order by nombre";
        public const string GetValidarUsuarioPassword = "select * from AppUser where Name= '{0}' and Password= '{1}';";
    }
}
