using Fansoft.DemoAuth.API.Models;
using Fansoft.DemoAuth.API.Repositories;
using Fansoft.DemoAuth.API.Services;
using Microsoft.AspNetCore.Mvc;

public class SecurityController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Authenticate([FromBody] User model)
    {
        // Recupera o usuário
        var user = UserRepository.Get(model.Username, model.Password);

        // Verifica se o usuário existe
        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Password = "";

        return Ok(new
                        {
                            access_token = token
                        }
        );
    }
}