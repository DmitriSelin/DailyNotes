using DailyNotes.Application.Services.Authentication;
using DailyNotes.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DailyNotes.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authenticationResult = await _authenticationService.RegisterAsync(
                request.FirstName, request.LastName,
                request.Email, request.Password);

            var response = new AuthenticationResponse(
                authenticationResult.User.Id, authenticationResult.User.FirstName,
                authenticationResult.User.LastName, authenticationResult.User.Email,
                authenticationResult.User.Password, authenticationResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authenticationResult = await _authenticationService.LoginAsync(
                request.Email, request.Password);

            var response = new AuthenticationResponse(
                authenticationResult.User.Id, authenticationResult.User.FirstName,
                authenticationResult.User.LastName, authenticationResult.User.Email,
                authenticationResult.User.Password, authenticationResult.Token);

            return Ok(response);
        }
    }
}