using Codeyad.CoreLayer.DTOs.Categories;
using Codeyad.DataLayer.Entities;

namespace Codeyad.CoreLayer.Mapper;

public class CategoryMapper
{
    public static CategoryDTO Map(Category c)
    {
        return new CategoryDTO()
        {
            Title = c.Title,
            Slug = c.Slug,
            MetaDescription = c.MetaDescription, 
            MetaTag = c.MetaTag,
            ParentId = c.ParentId,
            Id = c.Id
        };
    }
}
