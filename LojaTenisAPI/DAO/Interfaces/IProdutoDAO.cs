using LojaTenisAPI.Model;

namespace LojaTenisAPI.DAO.Interfaces
{
    public interface IProdutoDAO
    {
        Produto GetProdutoId(int id);

        List<Produto> GetProdutoList();

        void AdicionarProduto(Produto produto);

        void AtualizarProduto(Produto produto);
        void RemoverProduto(int id);
    }
}
