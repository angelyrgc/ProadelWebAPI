using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class LoginAccessFact
    {
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Permiso { get; set; } = null!;
        public byte[] Contraseña { get; set; } = null!;
        public DateTime InsertionDate { get; set; }
    }
}
