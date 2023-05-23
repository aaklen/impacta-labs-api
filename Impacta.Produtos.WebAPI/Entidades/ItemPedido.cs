namespace Impacta.Produtos.WebAPI.Entidades
{
    public class ItemPedido
    {
        public Guid Id { get; set; }    
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
