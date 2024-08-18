using Codeyad.CoreLayer.Services.FileManager;
using Microsoft.AspNetCore.Http;

namespace Codeyad.CoreLayer.DTOs.Posts;

public class EditPostDTO
{
    public int PostId { get; set; }
    public int CategoryID { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsSpecial { get; set; }
    public string Slug { get; set; }
    public IFormFile ImageFile { get; set; }
}
