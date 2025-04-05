using LojaTenisAPI.Model;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.Service.Interfaces
{
    public interface IImagemServices
    {
        void AdicionarImagem(ProdutoImagem imagem);
        void AtualizarImagem(ProdutoImagem imagem);
        void RemoverImagem(int id);
        ProdutoImagem ObterImagemPorId(int id);
        List<ProdutoImagem> ObterTodasImagens();
    }
}