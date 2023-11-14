using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubWeb.API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace JoinForcesHubWeb.API.Controllers.Images;

public sealed class ImagesController : ApiController
{
    private readonly IFileService _fileService;

    public ImagesController(IFileService fileService)
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

}
