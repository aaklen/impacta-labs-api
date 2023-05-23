using Impacta.Produtos.WebAPI.Data;
using Impacta.Produtos.WebAPI.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Impacta.Produtos.WebAPI.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(BancoDeDadosEmMemoria.Produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Produto? produto = BancoDeDadosEmMemoria.Produtos.FirstOrDefault(produto => produto.Id == id);

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
            

            BancoDeDadosEmMemoria.Produtos.Add(produto);

            return Created("Produto criado com sucesso!", produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] Produto atualizacaoProduto)
        {
            Produto? produto = BancoDeDadosEmMemoria.Produtos.FirstOrDefault(produto => produto.Id == id);

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
            Produto? produto = BancoDeDadosEmMemoria.Produtos.FirstOrDefault(produto => produto.Id == id);

            if (produto is null)
            {
                return NotFound();
            }

            BancoDeDadosEmMemoria.Produtos.Remove(produto);

            return NoContent();
        }
    }
}
