namespace YourSneaker.BFF.Compras.Models
{
    public class CupomDTO
    {
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set; }
        public string? Codigo { get; set; }
        public int TipoDesconto { get; set; }
    }
}
