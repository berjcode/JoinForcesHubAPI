using Microsoft.AspNetCore.Mvc;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;

namespace JoinForcesHubWeb.API.Abstractions;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{

    public IActionResult CreateActionResultInstance<T>(ResponseDto<T> responseDto)
    {
        return new ObjectResult(responseDto)
        {
            StatusCode = responseDto.StatusCode
        };
    }
}
