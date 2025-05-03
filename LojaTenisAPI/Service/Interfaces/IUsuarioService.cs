using LojaTenisAPI.Model;

namespace LojaTenisAPI.Service.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioPorEmail(string email);
        Usuario RegistrarUsuario(Usuario usuario, string senha);
    }
}
