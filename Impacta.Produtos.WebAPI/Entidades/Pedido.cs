namespace Impacta.Produtos.WebAPI.Entidades
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Guid ClientUID { get; set; }
        public int ClientID { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
