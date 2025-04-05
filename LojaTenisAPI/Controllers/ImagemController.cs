using LojaTenisAPI.Model;
using LojaTenisAPI.Service;
using LojaTenisAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.Controllers
{
    [ApiController]
    [Route("imagem")]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemServices _services;

        public ImagemController(IImagemServices services)
        {
            _services = services;
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(string path, int produtoId)
        {
            var imagem = new ProdutoImagem
            {
                Path = path,
                ProdutoId = produtoId
            };

            _services.AdicionarImagem(imagem);
            return Ok("Imagem adicionada com sucesso!");
        }


        [HttpPut("atualizar")]
        public IActionResult Atualizar(ProdutoImagem imagem)
        {
            _services.AtualizarImagem(imagem);
            return Ok("Imagem atualizada com sucesso!");
        }

        [HttpDelete("remover")]
        public IActionResult Remover(int id)
        {
            _services.RemoverImagem(id);
            return Ok($"Imagem com ID {id} removida com sucesso.");
        }

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(int id)
        {
            var imagem = _services.ObterImagemPorId(id);
            if (imagem == null)
            {
                return NotFound($"Imagem com ID {id} não encontrada.");
            }
            return Ok(imagem);
        }

        [HttpGet("obter-todas")]
        public IActionResult ObterTodas()
        {
            var imagens = _services.ObterTodasImagens();
            return Ok(imagens);
        }
    }
}