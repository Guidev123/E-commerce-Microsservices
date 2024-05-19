using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using YourSneaker.Core.Validation;

namespace YourSneaker.WebApp.MVC.Models
{
    public class PedidoTransacaoViewModel
    {
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public string? CupomCodigo { get; set; }
        public bool CumpomUtilizado { get; set; }

        public List<ItemCarrinhoViewModel> PedidoItems { get; set; } = new List<ItemCarrinhoViewModel>();
        public EnderecoViewModel? Endereco { get; set; }


        [Required(ErrorMessage = "Informe o número do cartão")]
        [DisplayName("Número do Cartão")]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage = "Informe o nome do portador do cartão")]
        [DisplayName("Nome do Portador")]
        public string NomeCartao { get; set; }

        [RegularExpression(@"(0[1-9]|1[0-2])\/[0-9]{2}", ErrorMessage = "O vencimento deve estar no padrão MM/AA")]
        [CartaoExpiracao(ErrorMessage = "Cartão Expirado")]
        [Required(ErrorMessage = "Informe o vencimento")]
        [DisplayName("Data de Vencimento MM/AA")]
        public string ExpiracaoCartao { get; set; }

        [Required(ErrorMessage = "Informe o código de segurança")]
        [DisplayName("Código de Segurança")]
        public string CvvCartao { get; set; }
    }
}
