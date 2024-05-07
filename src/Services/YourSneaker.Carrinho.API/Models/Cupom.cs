namespace YourSneaker.Carrinho.API.Models
{
    public class Cupom
    {
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set;}
        public string? Codigo { get; set; }
        public TipoDescontoCupom TipoDesconto { get; set; }
    }
    public enum TipoDescontoCupom
    {
        Porcentagem = 0,
        Valor = 1
    }
}
