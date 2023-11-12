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


    [HttpPost("users")]
    public async Task<IActionResult> UserRegister(RegisterRequest registerRequest)
    {
        var response = await _authenticationService.Register(registerRequest);

        return CreateActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> UserLogin(LoginRequest loginRequest)
    {
        var response = await _authenticationService.Login(loginRequest);

        return CreateActionResultInstance(response);
    }


    [HttpPost("refreshtoken")]
    public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
    {
        var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);

        return CreateActionResultInstance(result);
    }

}
