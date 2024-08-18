namespace Codeyad.CoreLayer.DTOs.Comments;

public class CreateComment
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
}
