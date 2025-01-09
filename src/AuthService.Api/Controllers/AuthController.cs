using AuthService.Api.Filters;
using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Core.ConfirmEmail;
using AuthService.Application.Core.CreateRefreshToken;
using AuthService.Application.Core.CreateUser;
using AuthService.Application.Core.DeleteRefreshToken;
using AuthService.Application.Core.ResetPassword;
using AuthService.Application.Core.SendCode;
using AuthService.Application.Core.SignIn;
using AuthService.Application.Core.VerifyRefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("sign-up")]
        [ValidationFilter<CreateUserCommand>]
        public async Task<IActionResult> SignUp(
            [FromQuery] CreateUserCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("sign-in")]
        [ValidationFilter<SignInQuery>]
        public async Task<IActionResult> SignIn(
            [FromQuery] SignInQuery request,
            [FromServices] IJwtProvider jwtProvider,
            [FromServices] IHttpContextAccessor httpContextAccessor,
            [FromServices] IConfiguration configuration)
        {
            var user = await mediator.Send(request);

            var accessToken = jwtProvider.GenerateToken(user);

            var createRefreshTokenCommand = new CreateRefreshTokenCommand(
                user.Id, 
                configuration
                    .GetRequiredSection("RefreshTokenOptions")
                    .GetValue<int>("ExpirationTimeInMonth"));
            var refreshToken = await mediator.Send(createRefreshTokenCommand);

            httpContextAccessor.HttpContext?.Response.Cookies.Append("refresh_token", refreshToken.ToString(),
                new CookieOptions()
                {
                    HttpOnly = true
                });

            return Ok(accessToken);
        }

        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut(
            [FromServices] HttpContextAccessor httpContextAccessor,
            [FromServices] ICacheService cacheService,
            [FromServices] IUserIdentifierProvider userIdentifierProvider,
            [FromServices] IConfiguration configuration)
        {
            var hasRefreshToken = httpContextAccessor.HttpContext!.Request.Cookies.TryGetValue("refresh_token", out string? refreshTokenId);
            if (!hasRefreshToken) return BadRequest();

            var command = new DeleteRefreshTokenCommand(Guid.Parse(refreshTokenId!));
            await mediator.Send(command);

            var accessToken = httpContextAccessor.HttpContext.Request.Headers.Authorization;
            var lifeTimeInMinutes = configuration.GetSection("JwtOptions").GetValue<int>("DurationInMinutes");

            await cacheService.SetAsync(
                $"accessBlacklist_{userIdentifierProvider.UserId}_{Guid.NewGuid()}",
                accessToken,
                TimeSpan.FromMinutes(lifeTimeInMinutes));

            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(
            [FromServices] IHttpContextAccessor httpContextAccessor,
            [FromServices] IJwtProvider jwtProvider)
        {
            var hasRefreshToken = httpContextAccessor.HttpContext!.Request.Cookies.TryGetValue("refresh_token", out string? refreshTokenId);
            if (!hasRefreshToken) return BadRequest();

            var query = new GetRefreshTokenQuery(Guid.Parse(refreshTokenId!));
            var refreshToken = await mediator.Send(query);
            if (refreshToken.ExpiredAtUtc < DateTimeOffset.UtcNow) return BadRequest();

            var accessToken = jwtProvider.GenerateToken(refreshToken.User);

            return Ok(accessToken);
        }

        [HttpPost("send-code")]
        [ValidationFilter<SendVerificationCodeCommand>]
        public async Task<IActionResult> SendCode(
            [FromQuery] SendVerificationCodeCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("confirm-email")]
        [ValidationFilter<ConfirmEmailQuery>]
        public async Task<IActionResult> ConfirmEmail(
            [FromQuery] ConfirmEmailQuery request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("reset-password")]
        [ValidationFilter<ResetPasswordCommand>]
        public async Task<IActionResult> ResetPassword(
            [FromQuery] ResetPasswordCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}