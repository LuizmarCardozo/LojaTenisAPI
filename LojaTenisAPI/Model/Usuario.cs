using System.ComponentModel.DataAnnotations;

namespace LojaTenisAPI.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string SenhaHash { get; set; } // A senha será armazenada como um hash, não texto puro
    }
}