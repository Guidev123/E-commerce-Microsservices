using FluentValidation.Results;
using YourSneaker.Core.Messages.Integration;
using YourSneaker.Pagamento.API.Facade;
using YourSneaker.Pagamento.API.Models;

namespace YourSneaker.Pagamento.API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoFacade _pagamentoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoFacade pagamentoFacade, IPagamentoRepository pagamentoRepository)
        {
            _pagamentoFacade = pagamentoFacade;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<ResponseMessage> AutorizarPagamento(Pagamentos pagamento)
        {
            var transacao = await _pagamentoFacade.AutorizarPagamento(pagamento);
            var validationResult = new ValidationResult();

            if(transacao.Status != StatusTransacao.Autorizado)
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento",
                                            "Seu cartão foi recusado, contate sua operadora para resolver."));

            }
            
            pagamento.AdicionarTransacao(transacao);
            _pagamentoRepository.AdicionarPagamento(pagamento);

            if (!await _pagamentoRepository.UnitOfWork.Commit())
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento", "Algo deu errado durante a realização do pagamento"));
                
                
                // TO DO: COMUNICAR COM O GATEWAY PARA REALIZAR REEMBOLSO
                return new ResponseMessage(validationResult);
            }
            return new ResponseMessage(validationResult);
        }
    }
}
