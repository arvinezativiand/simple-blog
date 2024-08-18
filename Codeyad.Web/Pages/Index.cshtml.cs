using Codeyad.CoreLayer.DTOs;
using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Services;
using Codeyad.CoreLayer.Services.MainPage;
using Codeyad.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeyad.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IMainPageService _mainPageService;
    private readonly IPostServices _postService;

    public IndexModel(IMainPageService mainPageService, IPostServices postService)
    {
        _mainPageService = mainPageService;
        _postService = postService;
    }
    public MainPageDTO MainPageData { get; set; }


    public void OnGet()
    {
        MainPageData = _mainPageService.GetData();
    }
    public IActionResult OnGetLatestPosts(string categorySlug)
    {
        var filterDto = _postService.GetPostByFilter(new PostFilterParams()
        {
            CategorySlug = categorySlug,
            PageId = 1,
            Take = 6
        });
        return Partial("_LatestPosts", filterDto.posts);
    }
    public IActionResult OnGetPopularPost()
    {
        return Partial("_PopularPosts", _postService.GetPopularPosts());
    }
}
