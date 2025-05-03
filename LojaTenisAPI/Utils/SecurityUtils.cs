namespace LojaTenisAPI.Utils
{
    /// <summary>
    /// Classe vai ser responsável por tratar senhas
    /// </summary>
    public class SecurityUtils : ISecurityUtils
    {
        public string GerarHashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
    }
}
