using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Model;
using LojaTenisAPI.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.Service
{
    public class ImagemServices : IImagemServices
    {
        private readonly IImagemDAO _imagemDAO;

        public ImagemServices(IImagemDAO imagemDAO)
        {
            _imagemDAO = imagemDAO;
        }

        public void AdicionarImagem(ProdutoImagem imagem)
        {
            if (imagem == null || string.IsNullOrWhiteSpace(imagem.Path))
            {
                throw new ArgumentException("Dados da imagem são inválidos.");
            }

            _imagemDAO.AdicionarImagem(imagem);
        }

        public void AtualizarImagem(ProdutoImagem imagem)
        {
            if (imagem == null || string.IsNullOrWhiteSpace(imagem.Path))
            {
                throw new ArgumentException("Dados da imagem são inválidos.");
            }

            var imagemExistente = _imagemDAO.ObterImagemPorId(imagem.Id);
            if (imagemExistente == null)
            {
                throw new Exception($"Imagem com ID {imagem.Id} não encontrada.");
            }

            _imagemDAO.AtualizarImagem(imagem);
        }

        public ProdutoImagem ObterImagemPorId(int id)
        {
            var imagem = _imagemDAO.ObterImagemPorId(id);
            if (imagem == null)
            {
                throw new Exception($"Imagem com ID {id} não encontrada.");
            }
            return imagem;
        }

        public List<ProdutoImagem> ObterTodasImagens()
        {
            return _imagemDAO.ObterTodasImagens();
        }

        public void RemoverImagem(int id)
        {
            var imagemExistente = _imagemDAO.ObterImagemPorId(id);
            if (imagemExistente == null)
            {
                throw new Exception($"Imagem com ID {id} não encontrada.");
            }

            _imagemDAO.RemoverImagem(id);
        }

        ProdutoImagem IImagemServices.ObterImagemPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<ProdutoImagem> IImagemServices.ObterTodasImagens()
        {
            throw new NotImplementedException();
        }
    }
}