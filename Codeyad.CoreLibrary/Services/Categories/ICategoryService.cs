using Codeyad.CoreLayer.DTOs.Categories;
using Codeyad.CoreLayer.Utilities;

namespace Codeyad.CoreLayer.Services.Categories;

public interface ICategoryService
{
    OperationResult CreateCategory(CreateCategoryDTO createCategory);
    OperationResult EditCategory(EditCategoryDTO editCategory);
    List<CategoryDTO> GetCategories();
    List<CategoryDTO> GetChildCategories(int parentId);
    CategoryDTO GetCategoryBy(int id);
    CategoryDTO GetCategoryBy(string name);
    bool IsSLugExist(string slug);
    OperationResult DeleteCategory(int id);

}
