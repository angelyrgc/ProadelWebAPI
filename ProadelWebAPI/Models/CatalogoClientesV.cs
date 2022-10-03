using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class CatalogoClientesV
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Abono { get; set; }
        public decimal? SaldoTotal { get; set; }
    }
}
