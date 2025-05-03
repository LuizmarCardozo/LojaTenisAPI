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
            _context.ProdutoImagem.Add(imagem);
            _context.SaveChanges();
        }


        public void AtualizarImagem(ProdutoImagem imagem)
        {
            _context.ProdutoImagem.Update(imagem);
            _context.SaveChanges();
        }
               
        //Na interface vc definiu o nome ObterImagemPorId e não GetImagemById
        //public ProdutoImagem GetImagemById(int id)
        public ProdutoImagem ObterImagemPorId(int id)
        {
            return _context.ProdutoImagem.FirstOrDefault(i => i.Id == id);
        }

        //Na interface vc definiu o nome ObterTodasImagens e não GetImagemList
        //public List<ProdutoImagem> GetImagemList()
        public List<ProdutoImagem> ObterTodasImagens()
        {
            return _context.ProdutoImagem.ToList();
        }


        public void RemoverImagem(int id)
        {
            var imagem = ObterImagemPorId(id);
            if (imagem != null)
            {
                _context.ProdutoImagem.Remove(imagem);
                _context.SaveChanges();
            }
        }

        //void IImagemDAO.AdicionarImagem(ProdutoImagem imagem)
        //{
        //    throw new NotImplementedException();
        //}

        //void IImagemDAO.AtualizarImagem(ProdutoImagem imagem)
        //{
        //    throw new NotImplementedException();
        //}

        //ProdutoImagem IImagemDAO.ObterImagemPorId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //List<ProdutoImagem> IImagemDAO.ObterTodasImagens()
        //{
        //    throw new NotImplementedException();
        //}

        //void IImagemDAO.RemoverImagem(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}