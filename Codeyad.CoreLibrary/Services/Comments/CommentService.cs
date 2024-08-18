using Codeyad.CoreLayer.DTOs.Comments;
using Codeyad.CoreLayer.Utilities;
using Codeyad.DataLayer.Context;
using Codeyad.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codeyad.CoreLayer.Services.Comments;

public class CommentService : ICommentService
{
    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }

    public OperationResult CreateComment(CreateComment command)
    {
        if (command == null)
            return OperationResult.NotFound("اطلاعات کامنت اشتباه است");

        PostComment comment = new()
        {
            PostId = command.PostId,
            Text = command.Text,
            UserId = command.UserId,
            CreationDate = command.CreationDate,
        };
        _context.PostComments.Add(comment);

        _context.SaveChanges();
        return OperationResult.Success();
    }

    public List<CommentDto> GetPostComments(int postId)
    {
        return _context.PostComments.Include(p => p.User).Where(p => p.PostId == postId).Select(p => new CommentDto()
        {
            CommentId = p.Id,
            PostId = p.PostId,
            Text = p.Text,
            UserFullName = p.User.FullName
        }).ToList();
    }
}
