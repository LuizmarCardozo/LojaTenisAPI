using LojaTenisAPI.Model;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.DAO.Interfaces
{
    public interface IImagemDAO
    {
        ProdutoImagem ObterImagemPorId(int id); 
        List<ProdutoImagem> ObterTodasImagens(); 
        void AdicionarImagem(ProdutoImagem imagem); 
        void AtualizarImagem(ProdutoImagem imagem); 
        void RemoverImagem(int id); 
    }
}