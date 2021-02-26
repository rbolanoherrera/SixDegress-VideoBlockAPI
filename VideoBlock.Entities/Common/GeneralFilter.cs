using System;

namespace VideoBlock.Entities.Common
{
    public class GeneralFilter
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String3 { get; set; }
        /// <summary>
        /// Número de la página
        /// </summary>
        public int PageInit { get; set; }
        /// <summary>
        /// Número de registros por página
        /// </summary>
        public int PageEnd { get; set; }

        public string StrFecha1 { get; set; }
        public string StrFecha2 { get; set; }

        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }

        /// <summary>
        /// Número de registros totales para el criterio de búsqueda
        /// </summary>
        public int Rows { get; set; }
    }
}
