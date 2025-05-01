using LojaTenisAPI.DTO;
using LojaTenisAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("registrar")]
    public IActionResult Registrar(UsuarioDTO usuarioDto)
    {
        if (_usuarioService.GetUsuarioPorEmail(usuarioDto.Email) != null)
            return BadRequest("E-mail já registrado.");

        var usuario = new Usuario
        {
            Email = usuarioDto.Email,
            Nome = usuarioDto.Nome,
            SenhaHash = GerarHashSenha(usuarioDto.Senha) // Gerar o hash da senha
        };

        _usuarioService.RegistrarUsuario(usuario);

        return Ok(new { usuario.Id, usuario.Email, usuario.Nome });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO loginDto)
    {
        var usuario = _usuarioService.GetUsuarioPorEmail(loginDto.Email);

        if (usuario == null || !VerificarHashSenha(loginDto.Senha, usuario.SenhaHash))
            return Unauthorized("E-mail ou senha inválidos.");

        var token = GerarTokenJWT(usuario);
        return Ok(new { Token = token });
    }

    // Método para gerar hash da senha
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