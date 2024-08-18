using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeyad.Web.Pages;

public class SearchModel : PageModel
{
    private readonly IPostServices _postService;

    public SearchModel(IPostServices postService)
    {
        _postService = postService;
    }
    public PostFilterDTO Post { get; set; }

    public void OnGet(int pageId = 1, string categorySlug = null, string title = null)
    {
        Post = _postService.GetPostByFilter(new PostFilterParams()
        {
            Title = title,
            PageId = pageId,
            CategorySlug = categorySlug,
            Take = 5
        });
    }
    public IActionResult OnGetPagination(int pageId = 1, string categorySlug = null, string title = null)
    {
        var model = _postService.GetPostByFilter(new PostFilterParams()
        {
            Title = title,
            PageId = pageId,
            CategorySlug = categorySlug,
            Take = 6
        });
        return Partial("_SearchView", model);
    }
}
