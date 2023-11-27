using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Services;

public interface IFileService
{
    Task DeleteFileAsync(string path);
    string GetMimeType(string fileName);
    Task<(byte[], string)> GetFileAsync(string path);
    Task<string> UploadFileAsync(IFormFile file, string fileType, string FolderName);
}
