using Codeyad.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;

namespace Codeyad.CoreLayer.Services.FileManager;

public class FileManager : IFileManager
{
    public void DeleteImage(string fileName, string path)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName, path);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public string SaveFile(IFormFile file, string savePath)
    {
        if (file == null)
            throw new Exception("file is null.");

        var fileName = $"{Guid.NewGuid()}{file.FileName}";
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(),savePath.Replace("/", "\\"));
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var fullPath = Path.Combine(folderPath, fileName);
        using var stream = new FileStream(fullPath, FileMode.Create);
        file.CopyTo(stream);

        return fileName;
    }

    public string SaveImageAndReturnImageName(IFormFile formFile, string savePath)
    {
        var isImage = ImageValidation.Validation(formFile.FileName);
        if (!isImage)
            throw new Exception();

        return SaveFile(formFile, savePath);
    }
}
