using YourSneaker.Pedido.Domain.Pedidos;

namespace YourSneaker.Pedido.API.Application.DTO
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public string CupomCodigo { get; set; }
        public bool CupomUtilizado { get; set; }

        public List<PedidoItemDTO> PedidoItems { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public static PedidoDTO ParaPedidoDTO(Pedidos pedido)
        {
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Codigo = pedido.Codigo,
                Status = (int)pedido.PedidoStatus,
                Data = pedido.DataCadastro,
                ValorTotal = pedido.ValorTotal,
                Desconto = pedido.Desconto,
                CupomUtilizado = pedido.CupomUtilizado,
                PedidoItems = new List<PedidoItemDTO>(),
                Endereco = new EnderecoDTO()
            };

            foreach (var item in pedido.PedidoItems)
            {
                pedidoDTO.PedidoItems.Add(new PedidoItemDTO
                {
                    Nome = item.ProdutoNome,
                    Imagem = item.ProdutoImagem,
                    Quantidade = item.Quantidade,
                    ProdutoId = item.ProdutoId,
                    Valor = item.ValorUnitario,
                    PedidoId = item.PedidoId
                });
            }

            pedidoDTO.Endereco = new EnderecoDTO
            {
                Logradouro = pedido.Endereco.Logradouro,
                Numero = pedido.Endereco.Numero,
                Complemento = pedido.Endereco.Complemento,
                Bairro = pedido.Endereco.Bairro,
                Cep = pedido.Endereco.Cep,
                Cidade = pedido.Endereco.Cidade,
                Estado = pedido.Endereco.Estado,
            };

            return pedidoDTO;
        }
    }
}
