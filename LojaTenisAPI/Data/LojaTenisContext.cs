using LojaTenisAPI.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace LojaTenisAPI.Data
{
    public class LojaTenisContext : DbContext
    {
        public LojaTenisContext()
        {
            
        }
        public LojaTenisContext(DbContextOptions<LojaTenisContext>options) : base(options) { }

        public DbSet<ProdutoImagem> ProdutoImagem { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
