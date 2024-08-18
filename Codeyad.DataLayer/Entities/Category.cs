using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codeyad.DataLayer.Entities;

public class Category: BaseEntity
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Slug { get; set; }
    public string MetaTag { get; set; }
    public string MetaDescription { get; set; }
    public int? ParentId { get; set; }

    #region Relationals
    [InverseProperty("SubCategory")]
    public ICollection<Post> SubPosts { get; set; }

    [InverseProperty("Category")]
    public ICollection<Post> Posts { get; set; }
    #endregion
}
