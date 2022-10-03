using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class MovimientosFacturacionDatum
    {
        public string Tipodoc { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public long Folio { get; set; }
        public string Cliente { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal? Total { get; set; }
        public string Estado { get; set; } = null!;
    }
}
