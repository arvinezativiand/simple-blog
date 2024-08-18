using Codeyad.CoreLayer.Utilities;

namespace Codeyad.CoreLayer.DTOs.Posts;

public class PostFilterDTO : BasePagination
{
    public List<PostDTO> posts;
    public PostFilterParams filterParams { get; set; }
}
public class PostFilterParams
{
    public string Title { get; set; }
    public int PageId { get; set; }
    public int Take { get; set; }
    public string CategorySlug { get; set; }
}
