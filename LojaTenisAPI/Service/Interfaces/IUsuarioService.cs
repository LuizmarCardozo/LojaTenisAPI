namespace LojaTenisAPI.Service.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioPorEmail(string email);
        void RegistrarUsuario(Usuario usuario);
    }
}
