using Microsoft.AspNetCore.Mvc;
using JoinForcesHubWeb.API.Abstractions;
using JoinForcesHubAPI.Application.Services.Roles;
using JoinForcesHubAPI.Application.Contracts.Roles;

namespace JoinForcesHubWeb.API.Controllers.Roles
{
    public sealed class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDto roleCreateDto, CancellationToken cancellationToken)
        {
            var response = await _roleService.CreateRoleAsync(roleCreateDto, cancellationToken);

            return CreateActionResultInstance(response);
        }
    }
}
