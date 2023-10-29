using Microsoft.AspNetCore.Mvc;
using JoinForcesHubWeb.API.Abstractions;
using JoinForcesHubAPI.Application.Services.Authentication;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubWeb.API.Controllers.Authentication;



public sealed class AuthController : ApiController
{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> UserRegister(RegisterRequest registerRequest)
    {
        var authResult = await _authenticationService.Register(registerRequest);

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.Firstname,
            authResult.SurName,
            authResult.Email,
            authResult.Token
            );

        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UserLogin(LoginRequest loginRequest)
    {
        var authResult = await _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password
            );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.Firstname,
            authResult.SurName,
            authResult.Email,
            authResult.Token
            );

        return Ok(response);
    }

}
