using Codeyad.CoreLayer.DTOs;
using Codeyad.CoreLayer.Mapper;
using Codeyad.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Codeyad.CoreLayer.Services.MainPage;

public class MainPageService : IMainPageService
{
    private readonly BlogContext _blogContext;

    public MainPageService(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

    public MainPageDTO GetData()
    {
        var Categories = _blogContext.Categories.OrderByDescending(c => c.Id).Take(6)
            .Include(c => c.Posts)
            .Include(c => c.SubPosts)
            .Select(c => new MainPageCategoryDTO()
            {
                Title = c.Title,
                Slug = c.Slug,
                PostChild = c.Posts.Count + c.SubPosts.Count,
                IsMainCategory = c.ParentId == null
            }).ToList();
        var specialPosts = _blogContext.Posts
                .OrderByDescending(d => d.Id)
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .Where(r => r.IsSpecial).Take(4)
                .Select(post => PostMapper.MapToDTO(post)).ToList();

        var latestPost = _blogContext.Posts
            .Include(c => c.Category)
            .Include(c => c.SubCategory)
            .OrderByDescending(d => d.Id)
            .Take(6)
            .Select(post => PostMapper.MapToDTO(post)).ToList();

        return new MainPageDTO()
        {
            LatestPosts = latestPost,
            Categories = Categories,
            SpecialPosts = specialPosts
        };
    }
}
