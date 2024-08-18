using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Utilities;
using Codeyad.DataLayer.Entities;

namespace Codeyad.CoreLayer.Mapper;
public class PostMapper
{
    public static Post MapCreateDTOToPost(CreatePostDTO createPost)
    {
        return new Post()
        {
            CategoryId = createPost.CategoryID,
            SubCategoryId = createPost.SubCategoryId,
            Userid = createPost.UserId,
            Title = createPost.Title,
            Description = createPost.Description,
            Slug = createPost.Slug.ToSlug(),
            Visit = 0,
            IsDelete = false,
            IsSpecial = createPost.IsSpecial
            
        };
    }
    public static void EditPostDTO(EditPostDTO editPost, Post post)
    {
        post.Title = editPost.Title;
        post.Description = editPost.Description;
        post.CategoryId = editPost.CategoryID;
        post.Slug = editPost.Slug.ToSlug();
        post.SubCategoryId = editPost.SubCategoryId;
        post.IsSpecial = editPost.IsSpecial;
    }
    public static PostDTO MapToDTO(Post post)
    {
        return new PostDTO()
        {
            CategoryID = post.CategoryId,
            UserFullName = post.User?.FullName,
            Title = post.Title,
            Description = post.Description,
            Slug = post.Slug,
            Visit = post.Visit,
            CreationDate = post.CreationDate,
            Category = post.Category == null? null : CategoryMapper.Map(post.Category),
            ImageName = post.ImageName,
            PostId = post.Id,
            SubCategoryId = post.SubCategoryId,
            SubCategory = post.SubCategory == null ? null : CategoryMapper.Map(post.SubCategory),
            IsSpecial = post.IsSpecial
        };
    }
}
