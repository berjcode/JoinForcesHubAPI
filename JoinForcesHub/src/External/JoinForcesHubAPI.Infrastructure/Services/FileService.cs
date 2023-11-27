using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubAPI.Infrastructure.Services;

public class FileService : IFileService
{

    public async Task<string> UploadFileAsync(IFormFile file, string fileType, string FolderName)
    {
        if (file == null || file.Length == 0)
             throw new Exception("Not Empty");

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

            return path;
        }
        catch (Exception ex)
        {
            throw new Exception($"Hata İle Karşılaşıldı: {ex.Message}", ex);
        }
    }


    public async Task<(byte[], string)> GetFileAsync(string path)
    {
        string pathFile = path;

        if (!File.Exists(pathFile))
        {
            string defaultImagePath = "./Content/Images/defaultphoto.png";
            byte[] defaultImageBytes = await File.ReadAllBytesAsync(defaultImagePath);
            string defaultImageMimeType = GetMimeType("defaultphoto.png");

            return (defaultImageBytes, defaultImageMimeType);
        }

        byte[] fileBytes = await File.ReadAllBytesAsync(pathFile);
        string mimeType = GetMimeType(pathFile);

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

    public Task DeleteFileAsync(string path)
    {
        try
        {
            if (File.Exists(path))
                    File.Delete(path);
        
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dosya silme hatası: {ex.Message}");
        }

        return Task.CompletedTask;
    }
}
