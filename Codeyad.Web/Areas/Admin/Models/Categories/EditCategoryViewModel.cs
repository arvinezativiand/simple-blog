using System.ComponentModel.DataAnnotations;

namespace Codeyad.Web.Areas.Admin.Models.Categories;

public class EditCategoryViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
    public string Title { get; set; }

    [Display(Name = "اسلاگ")]
    [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
    public string Slug { get; set; }

    [Display(Name = "MetaTag")]
    [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
    public string MetaTag { get; set; }

    [Display(Name = "MetaDescription")]
    [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
    [DataType(DataType.MultilineText)]
    public string MetaDescription { get; set; }
}
