using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Services.Authentication;
using JoinForcesHubWeb.API.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JoinForcesHubWeb.API.Controllers.Authentication;



public sealed class AuthController : ApiController
{

    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("[action]")]
    public IActionResult UserRegister(RegisterRequest registerRequest)
    {
        var authResult = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.SurName,
            registerRequest.Email,
            registerRequest.Password
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

    [HttpPost("[action]")]
    public IActionResult UserLogin(LoginRequest loginRequest)
    {
        var authResult = _authenticationService.Login(
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
