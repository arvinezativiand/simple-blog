using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codeyad.DataLayer.Entities;

public class Post: BaseEntity
{
    
    public int Userid { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public int Visit { get; set; }
    [Required]
    [MaxLength(400)]
    public string Slug { get; set; }
    public string ImageName { get; set; }
    public bool IsSpecial { get; set; }

    [ForeignKey("Userid")]
    public User User { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [ForeignKey("SubCategoryId")]
    public Category SubCategory { get; set; }

    #region Relationals
    public ICollection<PostComment> PostComments { get; set; }
    #endregion
}
