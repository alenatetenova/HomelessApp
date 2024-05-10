using Homeless.Authorization.Models;
using Homeless.Authorization.Services;
using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homeless.Controllers;

    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null) return Unauthorized("Неверный логин или пароль");

            return Ok(response);
        }
    
}