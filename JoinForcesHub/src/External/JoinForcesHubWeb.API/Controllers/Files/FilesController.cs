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

    [HttpPost]
    public async Task<IActionResult> SaveUserImage(IFormFile image)
    {
        var response = await _fileService.UploadFileAsync(image, "Images", "User");

        return CreateActionResultInstance(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserImage( string fileName)
    {
        var fileData = await _fileService.GetFileAsync("Images", "User",fileName);

        return File(fileData.Item1, fileData.Item2);
    }


    [HttpPost("usercv")]
    public async Task<IActionResult> SaveUserCv(IFormFile image)
    {
        var response = await _fileService.UploadFileAsync(image, "Pdf", "UserCv");

        return CreateActionResultInstance(response);
    }
    [HttpGet("usercv")]
    public async Task<IActionResult> GetUserCv(string fileName)
    {
        var fileData = await _fileService.GetFileAsync("Pdf", "UserCv", fileName);

        return File(fileData.Item1, fileData.Item2);
    }


}
