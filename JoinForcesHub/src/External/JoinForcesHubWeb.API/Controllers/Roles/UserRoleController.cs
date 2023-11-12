using Microsoft.AspNetCore.Mvc;
using JoinForcesHubWeb.API.Abstractions;
using JoinForcesHubAPI.Application.Services.UserRoles;
using JoinForcesHubAPI.Application.Contracts.UserRoles;

namespace JoinForcesHubWeb.API.Controllers.Roles;

[Route("api/[controller]s")]
public sealed class UserRoleController : ApiController
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(UserRoleCreateDto userRoleCreateDto, CancellationToken cancellationToken)
    {
        var response = await _userRoleService.CreateUserRoleAsync(userRoleCreateDto, cancellationToken);

        return CreateActionResultInstance(response);
    }

}
