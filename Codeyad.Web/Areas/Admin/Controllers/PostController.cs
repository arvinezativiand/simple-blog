using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Services.Posts;
using Codeyad.CoreLayer.Utilities;
using Codeyad.Web.Areas.Admin.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Codeyad.CoreLayer.Utilities.OperationResult;

namespace Codeyad.Web.Areas.Admin.Controllers;


public class PostController : AdminControllerBase
{
    private readonly IPostServices _postService;

    public PostController(IPostServices postService)
    {
        _postService = postService;
    }

    public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
    {
        var result = _postService.GetPostByFilter(new PostFilterParams()
        {
            PageId = pageId,
            Title = title,
            CategorySlug = categorySlug,
            Take = 3
        });
        return View(result);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Add(CreatePostViewModel postViewModel)
    {
        if (!ModelState.IsValid)
            return View();

        var result = _postService.CreatePost(new CreatePostDTO()
        {
            CategoryID = postViewModel.CategoryID,
            Description = postViewModel.Description,
            Slug = postViewModel.Slug,
            Title = postViewModel.Title,
            ImageFile = postViewModel.ImageFile,
            SubCategoryId = postViewModel.SubCategoryId == 0 ? null : postViewModel.SubCategoryId,
            UserId = User.GetUserId(),
            IsSpecial = postViewModel.IsSpecial
        });
        if (result.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(postViewModel.Slug), result.Message);
            return View(postViewModel);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var post = _postService.GetPostById(id);
        if (post == null)
            return RedirectToAction("Index");

        var model = new EditPostViewModel()
        {
            CategoryID = post.CategoryID,
            Description = post.Description,
            Slug = post.Slug,
            Title = post.Title,
            SubCategoryId = post.SubCategoryId,
            IsSpecial = post.IsSpecial
        };
        return View(model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Edit(int id, EditPostViewModel editViewModel)
    {
        if (!ModelState.IsValid)
            return View();

        var result = _postService.EditPost(new EditPostDTO()
        {
            CategoryID = editViewModel.CategoryID,
            Description = editViewModel.Description,
            Slug = editViewModel.Slug,
            Title = editViewModel.Title,
            ImageFile = editViewModel.ImageFile,
            SubCategoryId = editViewModel.SubCategoryId == 0 ? null : editViewModel.SubCategoryId,
            PostId = id,
            IsSpecial = editViewModel.IsSpecial
        });

        if (result.Status != OperationResultStatus.Success)
        {
            ModelState.AddModelError(nameof(editViewModel.Slug), result.Message);
            return View(editViewModel);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _postService.DeletePost(id);
        return RedirectToAction("Index");

    }
}
