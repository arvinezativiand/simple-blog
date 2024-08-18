using Codeyad.CoreLayer.DTOs.Comments;
using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Services.Comments;
using Codeyad.CoreLayer.Services.Posts;
using Codeyad.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using static Codeyad.CoreLayer.Utilities.OperationResult;

namespace Codeyad.Web.Pages;
public class PostModel : PageModel
{
    private readonly IPostServices _postService;
    private readonly ICommentService _commentService;

    public PostModel(IPostServices postService, ICommentService commentService)
    {
        _postService = postService;
        _commentService = commentService;
    }
    #region Properties
    public PostDTO Post { get; set; }

    [Required]
    [BindProperty]
    public string Text { get; set; }

    [BindProperty]
    public int PostId { get; set; }
    public List<CommentDto> Comments { get; set; }
    public List<PostDTO> RelatedPosts { get; set; }
    #endregion

    public IActionResult OnGet(string slug)
    {
        Post = _postService.GetPostBySlug(slug);
        if (Post == null)
            return NotFound();

        Comments = _commentService.GetPostComments(Post.PostId);
        RelatedPosts = _postService.GetRealtedPosts(Post.SubCategoryId??Post.CategoryID, Post.PostId);
        _postService.IncreaseVisit(Post.PostId);

        return Page();

    }
    public IActionResult OnPost(string slug)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToPage("Post", new { slug });
        }

        if(!ModelState.IsValid)
        {
            Post = _postService.GetPostBySlug(slug);
            Comments = _commentService.GetPostComments(Post.PostId);
            RelatedPosts = _postService.GetRealtedPosts(Post.SubCategoryId ?? Post.CategoryID, Post.PostId);

            return Page();
        }

        var result = _commentService.CreateComment(new CreateComment()
        {
            PostId = PostId,
            Text = Text,
            UserId = User.GetUserId()
        });
        
        return RedirectToPage("Post", new { slug });
    }
}
