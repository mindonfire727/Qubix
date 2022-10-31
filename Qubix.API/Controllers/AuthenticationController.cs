using Microsoft.AspNetCore.Mvc;
using Qubix.Application.Authentication;
using Qubix.Contracts.Authentication;

namespace Qubix.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            var response = new AuthenticationResponse(
                authResult.id,
                authResult.firstName,
                authResult.lastName,
                authResult.email,
                authResult.token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.id,
                authResult.firstName,
                authResult.lastName,
                authResult.email,
                authResult.token);

            return Ok(response);
        }
    }
}
