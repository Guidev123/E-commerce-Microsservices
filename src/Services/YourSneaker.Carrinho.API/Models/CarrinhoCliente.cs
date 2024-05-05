using FluentValidation;
using FluentValidation.Results;

namespace YourSneaker.Carrinho.API.Models
{
    public class CarrinhoCliente
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
        public ValidationResult? ValidationResult { get; set; } 

        public bool CumpomUtilizado { get; set; }
        public decimal Desconto { get; set; }
        public Cumpom Cupom { get; set; }

        public CarrinhoCliente(Guid clienteId)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
        }

        //EF
        public CarrinhoCliente() { }
        public void AplicarCupom(Cumpom cupom)
        {
            Cupom = cupom;
            CumpomUtilizado = true;
            CalculoDoValorCarrinho();
        }
        internal void CalculoDoValorCarrinho()
        {
            ValorTotal = Itens.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        private void CalcularValorTotalDesconto()
        {
            if (!CumpomUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Cupom.TipoDesconto == TipoDescontoCumpom.Porcentagem)
            {
                if (Cupom.Percentual.HasValue)
                {
                    desconto = (valor * Cupom.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Cupom.ValorDesconto.HasValue)
                {
                    desconto = Cupom.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        internal bool CarrinhoItemExiste(CarrinhoItem item)
        {
            return Itens.Any(p => p.ProdutoId == item.ProdutoId);   
        }

        internal CarrinhoItem ObterProdutoPorId(Guid produtoId)
        {
            return Itens.FirstOrDefault(p => p.ProdutoId == produtoId);
        }

        internal void AdicionarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);

            if(CarrinhoItemExiste(item))
            {
                var itemExistente = ObterProdutoPorId(item.ProdutoId);
                itemExistente.AdicionarUnidades(item.Quantidade);

                item = itemExistente;   
                Itens.Remove(itemExistente);
            }

            Itens.Add(item);

            CalculoDoValorCarrinho();
        }

        internal void AtualizarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);

            var itemExiste = ObterProdutoPorId(item.ProdutoId);

            Itens.Remove(itemExiste);
            Itens.Add(item);

            CalculoDoValorCarrinho();
        }

        internal void AtualizarUnidades(CarrinhoItem item, int unidades) 
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        internal void RemoverItem(CarrinhoItem item)
        {
            Itens.Remove(ObterProdutoPorId(item.ProdutoId));  

            CalculoDoValorCarrinho();
        }

        internal bool EhValido()
        {
            var erros = Itens.SelectMany(i => new CarrinhoItem.ItemCarrinhoValidation().Validate(i).Errors).ToList();
            erros.AddRange(new CarrinhoClienteValidation().Validate(this).Errors);
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }

        public class CarrinhoClienteValidation : AbstractValidator<CarrinhoCliente>
        {
            public CarrinhoClienteValidation()
            {
                RuleFor(c => c.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Cliente não encontrado");

                //RuleFor(c => c.Itens.Count)
                //    .GreaterThan(0)
                //    .WithMessage("O carrinho não possui itens");

                //RuleFor(c => c.ValorTotal)
                //    .GreaterThan(0)
                //    .WithMessage("O valor total do carrinho precisa ser maior que 0");
            }
        }
    }
}
