using YourSneaker.Core.DomainObjects;

namespace YourSneaker.Pagamento.API.Models
{
    public class Transacao : Entity
    {
        public string CodigoAutorizacao { get; set; }
        public string BandeiraCartao { get; set; }
        public DateTime? DataTransacao { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal CustoTransacao { get; set; }
        public StatusTransacao Status { get; set; }
        public string TID { get; set; } // Id
        public string NSU { get; set; } // Codigo de identificacao do meio de captura 

        public Guid PagamentoId { get; set; }

        // EF Relation
        public Pagamentos Pagamento { get; set; }
    }
}
