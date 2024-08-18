using System.ComponentModel.DataAnnotations;

namespace Codeyad.Web.Areas.Admin.Models.Posts;

public class CreatePostViewModel
{
    [Display(Name ="عنوان مجموعه")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    public int CategoryID { get; set; }

    [Display(Name ="عنوان زیر مجموعه")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    public int SubCategoryId { get; set; }

    [Display(Name ="عنوان")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name ="توضیحات")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    [UIHint("CKeditor")]
    public string Description { get; set; }

    [Display(Name ="Slug")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    public string Slug { get; set; }
    [Display(Name = "پست ویژه")]
    public bool IsSpecial { get; set; }
    [Display(Name ="عکس")]
    [Required(ErrorMessage="لطفا {0} را وارد کنید")]
    public IFormFile ImageFile { get; set; }
}
