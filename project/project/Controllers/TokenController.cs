using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using System.Data;

namespace project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController
    {
        /*
            [Authorize]
            [Route("getlogin")]
            public IActionResult GetLogin()
            {
                return Ok($"Ваш логин: {User.Identity.Name}");
            }

            [Authorize(Roles = "admin")]
            [Route("getrole")]
            public IActionResult GetRole()
            {
                return Ok("Ваша роль: администратор");
            }
        */
    }
}
