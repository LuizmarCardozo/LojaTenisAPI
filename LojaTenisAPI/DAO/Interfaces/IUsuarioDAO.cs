using LojaTenisAPI.Model;

namespace LojaTenisAPI.DAO.Interfaces
{
    public interface IUsuarioDAO
    {
        Usuario GetUsuarioPorEmail(string email);
        Usuario RegistrarUsuario(Usuario usuario);
    }
}
