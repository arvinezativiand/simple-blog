using Codeyad.CoreLayer.DTOs.Comments;
using Codeyad.CoreLayer.Utilities;

namespace Codeyad.CoreLayer.Services.Comments;
public interface ICommentService
{
    OperationResult CreateComment(CreateComment command);
    List<CommentDto> GetPostComments(int postId);
}
