using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class CatalogoClientesDatum
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public decimal? LimiteDeCredito { get; set; }
    }
}
