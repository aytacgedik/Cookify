using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult Login(SessionCredentials sc)
        {
            var token = jwtAuthenticationManager.Authenticate(sc.Email);
            return token == null ? Unauthorized() : Ok(token);
        }

        // [AllowAnonymous]
        // [HttpDelete]
        // public IActionResult DeleteSession(string tk)
        // {
        //     HttpContext.User = null;
        //     return Ok();
        // }
    }
}