using Codeyad.CoreLayer.Services.FileManager;
using Codeyad.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codeyad.Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("/Upload/Article")]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
                BadRequest();

            string imageName = _fileManager.SaveFile(upload, Directories.PostContentImage);
            return new JsonResult(new { Uploaded = true, url = Directories.GetPostContentImage(imageName)});
        }
    }
}
