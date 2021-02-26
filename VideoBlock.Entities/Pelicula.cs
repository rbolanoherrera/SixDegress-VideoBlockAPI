namespace VideoBlock.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Director { get; set; }

        public decimal Costo { get; set; }

        public int Cantidad { get; set; }
    }
}
