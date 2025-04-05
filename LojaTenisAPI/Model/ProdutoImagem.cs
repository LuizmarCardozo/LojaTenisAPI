using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaTenisAPI.Model
{
    public class ProdutoImagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Path { get; set; } 

       
        [Required]
        public int ProdutoId { get; set; } 

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; } 
    }
}