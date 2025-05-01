using LojaTenisAPI.Data;
using LojaTenisAPI.Service.Interfaces;

public class UsuarioService : IUsuarioService
{
    private readonly LojaTenisContext _context;

    public UsuarioService(LojaTenisContext context)
    {
        _context = context;
    }

    public Usuario GetUsuarioPorEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}