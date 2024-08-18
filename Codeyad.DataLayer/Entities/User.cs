using System.ComponentModel.DataAnnotations;

namespace Codeyad.DataLayer.Entities;

public class User : BaseEntity
{

    [Required]
    [MinLength(4)]
    [MaxLength(16)]
    public string UserName { get; set; }
    public string FullName { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    public UserRole Role { get; set; }


    #region Relationals
    public ICollection<Post> Posts { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    #endregion
}
public enum UserRole
{
    Admin,
    User,
    Author
}
