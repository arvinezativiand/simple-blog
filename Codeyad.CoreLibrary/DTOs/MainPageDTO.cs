using Codeyad.CoreLayer.DTOs.Posts;

namespace Codeyad.CoreLayer.DTOs;

public class MainPageDTO
{
    public List<PostDTO> LatestPosts { get; set; }
    public List<PostDTO> SpecialPosts { get; set; }
    public List<MainPageCategoryDTO> Categories { get; set; }
}

public class MainPageCategoryDTO
{
    public bool IsMainCategory { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public int PostChild { get; set; }
}