using Codeyad.CoreLayer.DTOs.Categories;
using Codeyad.CoreLayer.Mapper;
using Codeyad.CoreLayer.Utilities;
using Codeyad.DataLayer.Context;
using Codeyad.DataLayer.Entities;

namespace Codeyad.CoreLayer.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly BlogContext _context;
    public CategoryService(BlogContext context)
    {
        _context = context;
    }
    public OperationResult CreateCategory(CreateCategoryDTO createCategory)
    {
        if (IsSLugExist(createCategory.Slug))
            return OperationResult.Error("Please enter another slug.");


        var category = new Category()
        {
            Title = createCategory.Title,
            IsDelete = false,
            CreationDate = DateTime.Now,
            MetaDescription = createCategory.MetaDescription,
            MetaTag = createCategory.MetaTag,
            ParentId = createCategory.ParentId,
            Slug = createCategory.Slug.ToSlug()
            
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return OperationResult.Error("There is no category contains this Id.");

        List<Post> posts = _context.Posts.Where(p => p.CategoryId == id).ToList();
        if (posts.Count != 0)
            return OperationResult.Error("یک یا چند پست با این دسته بندی وجود دارند. تا زمانه که همه آنها را ویرایش نکرده اید، امکان پاک کردن دسته بندی وجود ندارد.");
        var subcategories = _context.Categories.Where(c => c.ParentId == id);
        if (subcategories != null)
        {
            foreach(var s in subcategories)
                _context.Categories.Remove(s);
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult EditCategory(EditCategoryDTO editCategory)
    {
        var result = _context.Categories.FirstOrDefault(c=> c.Id == editCategory.Id);
        if (result==null)
            return OperationResult.NotFound();
        if (result.Slug != editCategory.Slug.ToSlug() && IsSLugExist(editCategory.Slug.ToSlug()))
        {
            return OperationResult.Error("Please enter another slug.");
        }

        result.Title = editCategory.Title;
        result.MetaDescription = editCategory.MetaDescription;
        result.MetaTag = editCategory.MetaTag;
        result.Slug = editCategory.Slug.ToSlug();
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public List<CategoryDTO> GetCategories()
    {
        return _context.Categories.Where(c=>c.IsDelete==false).Select(category=> CategoryMapper.Map(category)).ToList();
    }

    public CategoryDTO GetCategoryBy(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
            return null;

        return CategoryMapper.Map(category);
    }

    public CategoryDTO GetCategoryBy(string slug)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
        if (category == null)
            return null;

        return CategoryMapper.Map(category);
    }

    public List<CategoryDTO> GetChildCategories(int parentId)
    {
        return _context.Categories.Where(c=> c.ParentId == parentId).Select(p=>  CategoryMapper.Map(p)).ToList();
    }

    public bool IsSLugExist(string slug)
    {
        return _context.Categories.Any(c => c.Slug == slug.ToSlug());
    }
}
