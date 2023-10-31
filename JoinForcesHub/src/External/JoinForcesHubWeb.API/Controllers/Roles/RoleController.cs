using JoinForcesHubAPI.Application.Contracts.Roles;
using JoinForcesHubAPI.Application.Services.Roles;
using JoinForcesHubWeb.API.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JoinForcesHubWeb.API.Controllers.Roles
{
    public sealed class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(RoleCreateDto roleCreateDto, CancellationToken cancellationToken)
        {
            var response = await _roleService.CreateRoleAsync(roleCreateDto, cancellationToken);

            return CreateActionResultInstance(response);
        }
    }
}
