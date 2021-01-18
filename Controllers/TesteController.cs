using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.DemoAuth.API.Controllers
{

    [Route("api")]
    public class TesteController : ControllerBase
    {
        [HttpGet("ping")] public string Ping() => "Pong";

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";


    }
}