namespace VideoBlock.Entities
{
    public static class Enumerators
    {
        /// <summary>
        /// Roles manejados en la Aplicación
        /// </summary>
        public enum enumRoles
        {
            Administrador = 1,
            /// <summary>
            /// Perfil para Usuario que solo puede Reservar peliculas
            /// </summary>
            Arrendador = 2
        }
    }
}
