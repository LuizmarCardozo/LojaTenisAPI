using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Data;
using LojaTenisAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAPI.DAO
{
    public class ProdutoDAO : IProdutoDAO
    {

        private readonly LojaTenisContext _context;

        public ProdutoDAO(LojaTenisContext context)
        {
            _context = context;
        }

        public void AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void AtualizarProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public Produto GetProdutoId(int id)
        {
            return _context.Produtos.Include(c => c.Imagens).FirstOrDefault(c => c.Id == id);
        }

        public List<Produto> GetProdutoList()
        {
            return _context.Produtos.ToList();
        }

        public void RemoverProduto(int id)
        {
            {
                _context.Produtos.Remove(GetProdutoId(id));
                _context.SaveChanges();
            }
        }
    }
}
