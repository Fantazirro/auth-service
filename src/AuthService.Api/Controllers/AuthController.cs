using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp()
        {
            throw new NotImplementedException();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn()
        {
            throw new NotImplementedException();
        }

        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            throw new NotImplementedException();
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth()
        {
            throw new NotImplementedException();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            throw new NotImplementedException();
        }

        [HttpPost("send-code")]
        public async Task<IActionResult> SendCode()
        {
            throw new NotImplementedException();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail()
        {
            throw new NotImplementedException();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}