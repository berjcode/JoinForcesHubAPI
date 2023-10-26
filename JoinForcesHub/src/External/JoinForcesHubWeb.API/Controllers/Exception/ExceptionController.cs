using JoinForcesHubWeb.API.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JoinForcesHubWeb.API.Controllers.Exception;

public class ExceptionController : ApiController
{
    [HttpGet(Name ="GetException")]
    public IEnumerable<IActionResult> Get()
    {
        throw new ("x");
    }
}
