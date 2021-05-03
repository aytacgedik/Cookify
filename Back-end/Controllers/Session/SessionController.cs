using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Back_end.Data;

namespace Back_end.Controllers
{
    [Authorize]
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public SessionController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string email)
        {
            var token = jwtAuthenticationManager.Authenticate(email);
            return token == null ? Unauthorized() : Ok(token);
        }
    }
}