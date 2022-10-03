using System;
using System.Collections.Generic;

namespace ProadelWebAPI.Models
{
    public partial class LoginAccessLoad
    {
        public string? Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Permiso { get; set; }
        public byte[]? Contraseña { get; set; }
    }
}
