using Microsoft.AspNetCore.Http;
using JoinForcesHubAPI.Domain.Enums;
using System.Text.RegularExpressions;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;

namespace JoinForcesHubAPI.Infrastructure.Services;

public class FileService : IFileService
{

    public async Task<ResponseDto<bool>> UploadFileAsync(IFormFile file, string fileType, string FolderName)
    {
        if (file == null || file.Length == 0)
            return ResponseDto<bool>.Fail("exx", 404);

        try
        {
            string fileFormat = file.FileName.Substring(file.FileName.LastIndexOf("."));
            fileFormat = fileFormat.ToLower();
            string cleanFileName = Regex.Replace(Path.GetFileNameWithoutExtension(file.FileName), @"[^\w\s]", "");
            string filename = Guid.NewGuid().ToString() + cleanFileName + fileFormat;

            string directoryPath = $"./Content/{fileType}/{FolderName}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);


            string path = Path.Combine(directoryPath, filename);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return ResponseDto<bool>.Success(true, (int)ApiStatusCode.Success);
        }
        catch (Exception ex)
        {
            return ResponseDto<bool>.Fail($"Hata İle Karşılaşıldı: {ex}", 500);
        }
    }


    public async Task<(byte[], string)> GetFileAsync(string fileType, string FolderName,string fileName)
    {
        string path = $"./Content/{fileType}/{FolderName}/{fileName}";

        if (!File.Exists(path))
        {
            string defaultImagePath = "./Content/Images/defaultphoto.png";
            byte[] defaultImageBytes = await File.ReadAllBytesAsync(defaultImagePath);
            string defaultImageMimeType = GetMimeType("defaultphoto.png");

            return (defaultImageBytes, defaultImageMimeType);
        }

        byte[] fileBytes = await File.ReadAllBytesAsync(path);
        string mimeType = GetMimeType(fileName);

        return (fileBytes, mimeType);
    }
    public string GetMimeType(string fileName)
    {

        string ext = Path.GetExtension(fileName);

        switch (ext.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".pdf":
                return "application/pdf";
            case ".doc":
                return "application/msword";
            case ".docx":
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            case ".xls":
                return "application/vnd.ms-excel";
            case ".xlsx":
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            case ".ppt":
                return "application/vnd.ms-powerpoint";
            case ".pptx":
                return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            default:
                return "application/octet-stream";
        }
    }

}
