namespace YourSneaker.Carrinho.API.Models
{
    public class Cumpom
    {
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set;}
        public string Codigo { get; set; }
        public TipoDescontoCumpom TipoDesconto { get; set; }
    }
    public enum TipoDescontoCumpom
    {
        Porcentagem = 0,
        Valor = 1
    }
}
