using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using YourSneaker.Core.Validation;

namespace YourSneaker.BFF.Compras.Models
{
    public class PedidoDTO
    {
        public int? Codigo { get; set; }
        // Autorizado = 1,
        // Pago = 2,
        // Recusado = 3,
        // Entregue = 4,
        // Cancelado = 5
        public int? Status { get; set; }
        public DateTime? Data { get; set; }
        public decimal? ValorTotal { get; set; }

        public decimal? Desconto { get; set; }
        public string? CupomCodigo { get; set; }
        public bool CumpomUtilizado { get; set; }

        public List<ItemCarrinhoDTO> PedidoItems { get; set; }



        public EnderecoDTO Endereco { get; set; }



        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

    }
}
