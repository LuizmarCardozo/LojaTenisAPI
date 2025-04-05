using LojaTenisAPI.Model;

namespace LojaTenisAPI.Service.Interfaces
{
    public interface IProdutoServices
    {
        Produto GetProdutoId(int id);

        List<Produto> GetProdutoList();

        void AdicionarProduto(Produto produto);

        void AtualizarProduto(Produto produto);
        void RemoverProduto(int id);
    }
}
