using LojaTenisAPI.ViewModels;
using LojaTenisAPI.Model;
using LojaTenisAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LojaTenisAPI.Adapters;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    /*
     O Princípio da Responsabilidade Única (Single Responsibility Principle - SRP) é um dos cinco princípios SOLID. 
        Ele diz que cada classe deve ter apenas uma responsabilidade, ou seja, uma única razão para mudar. 
        Uma classe deve ser responsável por executar uma única tarefa ou ação, evitando que fique com múltiplas 
        responsabilidades que podem levar a um código mais complexo e difícil de manter. 
    */

    [HttpPost("registrar")]
    public IActionResult Registrar(UsuarioVMRequest usuarioVM)
    {
        //Veja como ficou mais limpo o método        
        try
        {
            var usuario = _usuarioService.RegistrarUsuario(usuarioVM.ToDomain(), usuarioVM.Senha);

            return Ok(usuario.ToViewModel());
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public IActionResult Login(LoginVM loginDto)
    {
        var usuario = _usuarioService.GetUsuarioPorEmail(loginDto.Email);

        if (usuario == null || !VerificarHashSenha(loginDto.Senha, usuario.SenhaHash))
            return Unauthorized("E-mail ou senha inválidos.");

        var token = GerarTokenJWT(usuario);
        return Ok(new { Token = token });
    }

    // Método para gerar hash da senha
    // Olhar a camada Security agora e replicar
    // JWT em tem que está lá tb
    private string GerarHashSenha(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    // Método para verificar hash da senha
    private bool VerificarHashSenha(string senha, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(senha, hash);
    }

    // Método para gerar o token JWT (exemplo básico)
    private string GerarTokenJWT(Usuario usuario)
    {
        var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var key = System.Text.Encoding.UTF8.GetBytes("sua_chave_secreta_super_segura");

        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, usuario.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}