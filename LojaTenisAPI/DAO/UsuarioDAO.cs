using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Data;
using LojaTenisAPI.Model;

namespace LojaTenisAPI.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly LojaTenisContext _context;

        public UsuarioDAO(LojaTenisContext context)
        {
            _context = context;
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario RegistrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
