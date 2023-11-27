using Microsoft.AspNetCore.Mvc;
using JoinForcesHubWeb.API.Abstractions;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubWeb.API.Controllers.Images;

public sealed class FilesController : ApiController
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserImage(string path)
    {
        var fileData = await _fileService.GetFileAsync(path);

        return File(fileData.Item1, fileData.Item2);
    }
}
