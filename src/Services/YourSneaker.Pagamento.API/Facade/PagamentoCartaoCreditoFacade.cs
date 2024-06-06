using Microsoft.Extensions.Options;
using YourSneaker.Pagamento.API.Models;
using YourSneaker.Pagamento.SneakerPag;

namespace YourSneaker.Pagamento.API.Facade
{
    public class PagamentoCartaoCreditoFacade : IPagamentoFacade
    {
        private readonly PagamentoConfig _pagamentoConfig;

        public PagamentoCartaoCreditoFacade(IOptions<PagamentoConfig> pagamentoConfig)
        {
            _pagamentoConfig = pagamentoConfig.Value;
        }

        public async Task<Transacao> AutorizarPagamento(Pagamentos pagamento)
        {
            var sneakerPagSvc = new SneakerPagService(_pagamentoConfig.DefaultApiKey,
                                                   _pagamentoConfig.DefaultEncryptionKey);

            var cardHashGen = new CardHash(sneakerPagSvc) // PASSANDO DADOS DO CARTAO PARA GERAR UM CARD HASH
            {
                CardNumber = pagamento.CartaoCredito.NumeroCartao,
                CardHolderName = pagamento.CartaoCredito.NomeCartao,
                CardExpirationDate = pagamento.CartaoCredito.MesAnoVencimento,
                CardCvv = pagamento.CartaoCredito.CVV
            };

            string cardHash = cardHashGen.Generate(); // GERANDO UMA STRING CARD HASH PARA REPRESENTAR O CARTAO DO CLIENTE 

            var transacao = new Transaction(sneakerPagSvc)
            {
                CardHash = cardHash,
                CardNumber = pagamento.CartaoCredito.NumeroCartao,
                CardHolderName = pagamento.CartaoCredito.NomeCartao,
                CardExpirationDate = pagamento.CartaoCredito.MesAnoVencimento,
                CardCvv = pagamento.CartaoCredito.CVV,
                PaymentMethod = PaymentMethod.CreditCard,
                Amount = pagamento.Valor 
            };

            return ParaTransacao(await transacao.AuthorizeCardTransaction());
        }
        public static Transacao ParaTransacao(Transaction transaction)
        {
            return new Transacao
            {
                Id = Guid.NewGuid(),
                Status = (StatusTransacao)transaction.Status,
                ValorTotal = transaction.Amount,
                BandeiraCartao = transaction.CardBrand,
                CodigoAutorizacao = transaction.AuthorizationCode,
                CustoTransacao = transaction.Cost,
                DataTransacao = transaction.TransactionDate,
                NSU = transaction.Nsu,
                TID = transaction.Tid
            };
        }
    }
}
