using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class ImporteFacturacionClientesV
    {
        public string Cliente { get; set; } = null!;
        public decimal? Total { get; set; }
    }
}
