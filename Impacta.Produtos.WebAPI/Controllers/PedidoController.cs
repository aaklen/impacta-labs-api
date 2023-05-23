using Impacta.Produtos.WebAPI.Data;
using Impacta.Produtos.WebAPI.DTO;
using Impacta.Produtos.WebAPI.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.Pedidos.WebAPI.Controllers
{
    [Route("api/Pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Listar()   
        {
            List<PedidoDTO> pedidos = BancoDeDadosEmMemoria.Pedidos;
            
            return Ok(pedidos);
        }

        [HttpGet("{pedidoUID}")]
        public async Task<IActionResult> ObterPorPedidoId(Guid pedidoUID)
        {
            PedidoDTO? pedido = BancoDeDadosEmMemoria.Pedidos.FirstOrDefault(pedido => pedido.PedidoUID == pedidoUID);
            
            if (pedido is null)
            {
                return NotFound();
            }

            List<Produto> produtosDoPedido = BancoDeDadosEmMemoria.Produtos
                .Where(produto => pedido.ItensPedido.Any(item => item.ProdutoId == produto.Id)).ToList();

            if (pedido.ItensPedido.Count != produtosDoPedido.Count)
                return Conflict(
                    "Por favor realize um novo pedido pois um ou mais dos produtos solicitados podem ter sido alterados.");

            decimal valorFinal = 0.0m;

            pedido.ItensPedido.ForEach(item =>
            {
                valorFinal += item.Quantidade * produtosDoPedido.First(produto => produto.Id == item.ProdutoId).Valor;
            });

            PedidoRespostaDTO resposta = new()
            {
                ItensPedido = pedido.ItensPedido,
                ClientUID = pedido.ClientUID,
                PedidoUID = pedidoUID,
                ValorTotal = valorFinal
            };

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PedidoDTO pedido)
        {
            pedido.PedidoUID = Guid.NewGuid();

            if (pedido.ItensPedido.Any(item =>
                    !BancoDeDadosEmMemoria.Produtos.Any(produto => produto.Id == item.ProdutoId)))
                return Conflict("Um dos produtos do seu pedido não está mais disponível");

            BancoDeDadosEmMemoria.Pedidos.Add(pedido);

            return Created("Pedido criado com sucesso!", pedido);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> FinalizarPedido(Guid pedidoUID)
        {
            PedidoDTO? pedido = BancoDeDadosEmMemoria.Pedidos.FirstOrDefault(pedido => pedido.PedidoUID == pedidoUID);

            if (pedido is null)
            {
                return NotFound();
            }

            BancoDeDadosEmMemoria.Pedidos.Remove(pedido);

            return NoContent();
        }
    }
}
