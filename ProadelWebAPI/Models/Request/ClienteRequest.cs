namespace ProadelWebAPI.Models.Request
{
    public class ClienteRequest
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public decimal? LimiteDeCredito { get; set; }
    }
}
