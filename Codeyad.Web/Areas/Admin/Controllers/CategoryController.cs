using Codeyad.CoreLayer.DTOs.Categories;
using Codeyad.CoreLayer.Services.Categories;
using Codeyad.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Codeyad.CoreLayer.Utilities.OperationResult;

namespace Codeyad.Web.Areas.Admin.Controllers;


public class CategoryController : AdminControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #region Index
    public IActionResult Index()
    {
        return View(_categoryService.GetCategories());
    }
    #endregion
    #region Add
    [Route("/admin/category/add/{parentId?}")]
    public IActionResult Add(int? parentId)
    {
        return View();
    }
    [HttpPost("/admin/category/add/{parentId?}")]
    public IActionResult Add(int parentId, CreateCategoryViewModel viewModel)
    {
        viewModel.ParentId = parentId;
        var result = _categoryService.CreateCategory(viewModel.MapToDTO());
        
        return RedirectAndShowAlert(result, RedirectToAction("Index"));
    }
    #endregion
    #region Edit
    public IActionResult Edit(int Id)
    {
        var category = _categoryService.GetCategoryBy(Id);
        if (category == null)
            return RedirectToAction("Index");

        var model = new EditCategoryViewModel()
        {
            Title = category.Title,
            Slug = category.Slug,
            MetaTag = category.MetaTag,
            MetaDescription = category.MetaDescription
        };

        return View(model);
    }
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(int Id, EditCategoryViewModel category)
    {
        var editedCategory = _categoryService.EditCategory(new EditCategoryDTO()
        {
            Id = Id,
            Title = category.Title,
            Slug = category.Slug,
            MetaTag = category.MetaTag,
            MetaDescription = category.MetaDescription
        });

        return RedirectAndShowAlert(editedCategory, RedirectToAction("Index"));
    }
    #endregion
    #region Delete
    public IActionResult Delete(int id)
    {
        var category = _categoryService.GetCategoryBy(id);
        var result = _categoryService.DeleteCategory(id);
        if(result.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(category.Title), result.Message);
        }
        return RedirectToAction("Index");
    }
    #endregion
    #region GetChildCategories
    public IActionResult GetChildCategories(int parentId)
    {
        var category = _categoryService.GetChildCategories(parentId);
        return new JsonResult(category);
    }
    #endregion
}
