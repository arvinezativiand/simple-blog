using System.ComponentModel.DataAnnotations;

namespace Codeyad.CoreLayer.DTOs.Categories;

public class CreateCategoryDTO
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string MetaTag { get; set; }
    public string MetaDescription { get; set; }
    public int? ParentId { get; set; }

}
