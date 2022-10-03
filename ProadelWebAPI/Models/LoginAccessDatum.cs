using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class LoginAccessDatum
    {
        public long Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Permiso { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public DateTime InsertionDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
