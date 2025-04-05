using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Data;
using LojaTenisAPI.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.DAO
{
    public class ImagemDAO : IImagemDAO
    {
        private readonly LojaTenisContext _context;

        public ImagemDAO(LojaTenisContext context)
        {
            _context = context;
        }

 
        public void AdicionarImagem(ProdutoImagem imagem)
        {
            _context.Imagens.Add(imagem);
            _context.SaveChanges();
        }

     
        public void AtualizarImagem(ProdutoImagem imagem)
        {
            _context.Imagens.Update(imagem);
            _context.SaveChanges();
        }

     
        public ProdutoImagem GetImagemById(int id)
        {
            return _context.Imagens.FirstOrDefault(i => i.Id == id);
        }

       
        public List<ProdutoImagem> GetImagemList()
        {
            return _context.Imagens.ToList();
        }

       
        public void RemoverImagem(int id)
        {
            var imagem = GetImagemById(id);
            if (imagem != null)
            {
                _context.Imagens.Remove(imagem);
                _context.SaveChanges();
            }
        }

        void IImagemDAO.AdicionarImagem(ProdutoImagem imagem)
        {
            throw new NotImplementedException();
        }

        void IImagemDAO.AtualizarImagem(ProdutoImagem imagem)
        {
            throw new NotImplementedException();
        }

        ProdutoImagem IImagemDAO.ObterImagemPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<ProdutoImagem> IImagemDAO.ObterTodasImagens()
        {
            throw new NotImplementedException();
        }

        void IImagemDAO.RemoverImagem(int id)
        {
            throw new NotImplementedException();
        }
    }
}