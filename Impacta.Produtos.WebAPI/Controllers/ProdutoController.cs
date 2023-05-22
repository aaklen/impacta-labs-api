using Impacta.Produtos.WebAPI.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.Produtos.WebAPI.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public static List<Produto> Produtos = new List<Produto>();

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(Produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Produto? produto = Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if(produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            produto.Id = Guid.NewGuid();

            Produtos.Add(produto);

            return Created("Produto criado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] Produto atualizacaoProduto)
        {
            Produto? produto = Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
            {
                return NotFound();
            }

            produto.Nome = atualizacaoProduto.Nome;
            produto.Descricao = atualizacaoProduto.Descricao;
            produto.Valor = atualizacaoProduto.Valor;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            Produto? produto = Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
            {
                return NotFound();
            }

            Produtos.Remove(produto);

            return NoContent();
        }
    }
}
