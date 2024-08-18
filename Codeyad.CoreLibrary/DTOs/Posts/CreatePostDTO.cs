using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Codeyad.CoreLayer.DTOs.Posts;

public class CreatePostDTO
{
    public int UserId { get; set; }

    [Display(Name = "عنوان دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int CategoryID { get; set; }
    [Display(Name = "عنوان دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int? SubCategoryId { get; set; }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Title { get; set; }
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Description { get; set; }
    [Display(Name = "Slug")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Slug { get; set; }
    [Display(Name = "عکس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public IFormFile ImageFile { get; set; }
    public bool IsSpecial { get; set; }
}
