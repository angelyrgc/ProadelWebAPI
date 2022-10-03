using System.ComponentModel.DataAnnotations;

namespace ProadelWebAPI.Models.Request
{
    public class UsuarioRequest
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
