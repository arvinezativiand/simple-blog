using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Utilities;

namespace Codeyad.CoreLayer.Services.Posts;

public interface IPostServices
{
    OperationResult CreatePost(CreatePostDTO command);
    OperationResult EditPost(EditPostDTO command);
    OperationResult DeletePost(int id);
    PostDTO GetPostById(int postId);
    PostDTO GetPostBySlug(string slug);
    PostFilterDTO GetPostByFilter(PostFilterParams postFilter);
    List<PostDTO> GetRealtedPosts(int categoryId, int postId);
    List<PostDTO> GetPopularPosts();
    bool IsSlugExist(string slug);
    void IncreaseVisit(int postId);
}
