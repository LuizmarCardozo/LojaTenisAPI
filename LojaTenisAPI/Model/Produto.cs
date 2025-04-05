using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaTenisAPI.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Img { get; set; }

        public List<ProdutoImagem> Imagens { get; set; }
    }
}
