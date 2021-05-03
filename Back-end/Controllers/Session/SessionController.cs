using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Back_end.Data;
using Microsoft.AspNetCore.Authentication;

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

        [HttpGet]
        public IActionResult GetSessionUser()
        {
            return Ok(HttpContext.User.Identity);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(SessionCredentials sc)
        {
            var token = jwtAuthenticationManager.Authenticate(sc.Email);
            return token == null ? Unauthorized() : Ok(token);
        }

        [AllowAnonymous]
        [HttpDelete]
        public IActionResult DeleteSession(string tk)
        {

            HttpContext.User = null;
            return Ok();
             
        }

    }
}