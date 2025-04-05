using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Model;
using LojaTenisAPI.Service.Interfaces;

namespace LojaTenisAPI.Service
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoDAO _produtoDAO;

        public ProdutoServices(IProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtoDAO.AdicionarProduto(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            _produtoDAO.AtualizarProduto(produto);
        }

        public Produto GetProdutoId(int id)
        {
            return _produtoDAO.GetProdutoId(id);
        }

        public List<Produto> GetProdutoList()
        {
            return _produtoDAO.GetProdutoList();
        }

        public void RemoverProduto(int id)
        {
            _produtoDAO.RemoverProduto(id);
        }
    }
}
