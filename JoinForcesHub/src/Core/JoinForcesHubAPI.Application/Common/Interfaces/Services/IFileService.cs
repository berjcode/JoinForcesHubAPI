using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using Microsoft.AspNetCore.Http;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Services;

public interface IFileService
{
    string GetMimeType(string fileName);
    Task<(byte[], string)> GetFileAsync(string fileType, string FolderName, string fileName);
    Task<ResponseDto<bool>> UploadFileAsync(IFormFile file, string fileType, string FolderName);
}
