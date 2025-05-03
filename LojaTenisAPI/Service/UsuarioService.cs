using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Model;
using LojaTenisAPI.Service.Interfaces;
using LojaTenisAPI.Utils;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioDAO _uarioDAO;
    private readonly ISecurityUtils _securityUtils;

    public UsuarioService(IUsuarioDAO uarioDAO, ISecurityUtils securityUtils)
    {
        _uarioDAO = uarioDAO;
        _securityUtils = securityUtils;
    }

    public Usuario GetUsuarioPorEmail(string email)
    {
        return _uarioDAO.GetUsuarioPorEmail(email);
    }

    public Usuario RegistrarUsuario(Usuario usuario, string senha)
    {
        //Estava correto mas no local errado
        //Regra de negócios deve ficar aqui!
        // is not null ou != null é a mesma coisa
        if (GetUsuarioPorEmail(usuario.Email) is not null)
        {
            //Vai disparar um erro e voltar para a controller
            //Não é o mais correto, depois vou deixar no Readme para você pesquisar sobre um item
            throw new Exception("E-mail já registrado.");
        }

        usuario.SenhaHash = _securityUtils.GerarHashSenha(senha);

        return _uarioDAO.RegistrarUsuario(usuario);
    }
}