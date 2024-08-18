using Microsoft.AspNetCore.Http;

namespace Codeyad.CoreLayer.Services.FileManager;

public interface IFileManager
{
    string SaveImageAndReturnImageName(IFormFile formFile, string savePath);
    string SaveFile(IFormFile formFile ,string savePath);
    void DeleteImage(string fileName, string filePath);
}
