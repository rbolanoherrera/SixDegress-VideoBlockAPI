namespace VideoBlock.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public int TipoDocumentoId { get; set; }

        public string Documento { get; set; }

        public string Nombre1 { get; set; }

        public string Nombre2 { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public int Estado { get; set; }
    }
}
