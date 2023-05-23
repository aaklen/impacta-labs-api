namespace Impacta.Produtos.WebAPI.DTO
{
    public class PedidoDTO
    {
        public Guid? PedidoUID { get; set; }
        public Guid ClientUID { get; set; }
        public List<PedidoItemDTO> ItensPedido { get; set; }

    }

    public class PedidoItemDTO
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class PedidoRespostaDTO
    {
        public Guid? PedidoUID { get; set; }
        public Guid ClientUID { get; set; }
        public List<PedidoItemDTO> ItensPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
