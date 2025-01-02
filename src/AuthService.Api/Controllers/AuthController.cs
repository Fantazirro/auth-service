using AuthService.Api.Filters;
using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Core.CreateRefreshToken;
using AuthService.Application.Core.CreateUser;
using AuthService.Application.Core.SignIn;
using AuthService.Application.Core.VerifyRefreshToken;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("sign-up")]
        [ValidationFilter<CreateUserCommand>]
        public async Task<IActionResult> SignUp(
            [FromQuery] CreateUserCommand request,
            [FromServices] CreateUserCommandHandler createUser)
        {
            await createUser.Handle(request);
            return Ok();
        }

        [HttpPost("sign-in")]
        [ValidationFilter<SignInQuery>]
        public async Task<IActionResult> SignIn(
            [FromQuery] SignInQuery request,
            [FromServices] SignInQueryHandler signInHandler,
            [FromServices] CreateRefreshTokenCommandHandler createRefreshTokenHandler,
            [FromServices] IJwtProvider jwtProvider,
            [FromServices] IHttpContextAccessor httpContextAccessor,
            [FromServices] IConfiguration configuration)
        {
            var user = await signInHandler.Handle(request);

            var accessToken = jwtProvider.GenerateToken(user);

            var createRefreshTokenCommand = new CreateRefreshTokenCommand(user.Id, configuration.GetValue<int>("RefreshTokenExpirationTimeInMonth"));
            var refreshToken = await createRefreshTokenHandler.Handle(createRefreshTokenCommand);

            httpContextAccessor.HttpContext?.Response.Cookies.Append("refresh_token", refreshToken.ToString(),
                new CookieOptions()
                {
                    HttpOnly = true
                });

            return Ok(accessToken);
        }

        [HttpPost("sign-out")]
        public new async Task<IActionResult> SignOut()
        {
            throw new NotImplementedException();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(
            [FromServices] GetRefreshTokenQueryHandler getRefreshTokenHandler,
            [FromServices] IHttpContextAccessor httpContextAccessor,
            [FromServices] IJwtProvider jwtProvider)
        {
            var hasRefreshToken = httpContextAccessor.HttpContext!.Request.Cookies.TryGetValue("refresh_token", out string? refreshTokenId);
            if (!hasRefreshToken) return BadRequest();

            var query = new GetRefreshTokenQuery(Guid.Parse(refreshTokenId!));
            var refreshToken = await getRefreshTokenHandler.Handle(query);
            if (refreshToken.ExpiredAtUtc < DateTimeOffset.UtcNow) return BadRequest();

            var accessToken = jwtProvider.GenerateToken(refreshToken.User);

            return Ok(accessToken);
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