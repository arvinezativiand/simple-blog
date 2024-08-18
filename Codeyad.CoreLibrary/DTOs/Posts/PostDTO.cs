using Codeyad.CoreLayer.DTOs.Categories;

namespace Codeyad.CoreLayer.DTOs.Posts;

public class PostDTO
{
    public int PostId { get; set; }
    public string UserFullName { get; set; }
    public int CategoryID { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string ImageName { get; set; }
    public bool IsSpecial { get; set; }
    public int Visit { get; set; }
    public DateTime CreationDate { get; set; }
    public CategoryDTO Category { get; set; }
    public CategoryDTO SubCategory { get; set; }
}
