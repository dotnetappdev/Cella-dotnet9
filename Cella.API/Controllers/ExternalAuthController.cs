using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cella.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalAuthController : ControllerBase
    {
        [HttpGet("signin-google")]
        [AllowAnonymous]
        public IActionResult SignInWithGoogle([FromQuery] string returnUrl = "/")
        {
            var redirectUrl = Url.Action(nameof(HandleExternalLogin), "ExternalAuth", new { provider = "Google", returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("signin-microsoft")]
        [AllowAnonymous]
        public IActionResult SignInWithMicrosoft([FromQuery] string returnUrl = "/")
        {
            var redirectUrl = Url.Action(nameof(HandleExternalLogin), "ExternalAuth", new { provider = "Microsoft", returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        [HttpGet("externallogin-callback")]
        [AllowAnonymous]
        public async Task<IActionResult> HandleExternalLogin([FromQuery] string provider, [FromQuery] string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync();
            if (!authenticateResult.Succeeded)
            {
                return BadRequest("External authentication failed.");
            }
            // Here you would typically create or find the user, issue a JWT, etc.
            // For demo, just return the claims.
            return Ok(authenticateResult.Principal?.Identities);
        }
    }
}
