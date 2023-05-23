using Impacta.Produtos.WebAPI.DTO;
using Impacta.Produtos.WebAPI.Entidades;

namespace Impacta.Produtos.WebAPI.Data
{
    public static class BancoDeDadosEmMemoria
    {

        public static List<Produto> Produtos = new List<Produto>()
        {
            {
                new Produto(Guid.Parse("efb20777-41fe-4128-94ec-4b97c46fbaea"),
                    "Produto 1",
                    "Produto de teste",
                    10.0m)
            },
            {
                new Produto(Guid.Parse("55673dd2-1976-4917-a7a9-1d28292c90c5"),
                    "Produto 2",
                    "Produto de teste 2",
                    25.0m)
            }
        };

        public static List<PedidoDTO> Pedidos = new List<PedidoDTO>();
    }
}
