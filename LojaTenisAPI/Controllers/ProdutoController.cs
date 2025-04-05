using LojaTenisAPI.Model;
using LojaTenisAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LojaTenisAPI.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {   
        private readonly IProdutoServices _services;

        public ProdutoController(IProdutoServices services)
        {
            _services = services;
        }
        [HttpDelete("remover")]
        public IActionResult Remover(int id)
        {
            _services.RemoverProduto(id);
                return Ok();
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Produto produto)
        {
            _services.AtualizarProduto(produto);
            return Ok();
        }
        
        [HttpGet("obter-por-id")]
        public IActionResult Obter(int id)
        {
            return Ok(_services.GetProdutoId(id));
        }

        [HttpGet("obter-todos")]
        public IActionResult Obter()
        {
            return Ok(_services.GetProdutoList());
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(Produto produto)
        {
            _services.AdicionarProduto(produto);
            return Ok();
        }
    }
}
