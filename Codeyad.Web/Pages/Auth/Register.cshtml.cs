using Codeyad.CoreLayer.DTOs.Users;
using Codeyad.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static Codeyad.CoreLayer.Utilities.OperationResult;

namespace Codeyad.Web.Pages.Auth;

[ValidateAntiForgeryToken]
[BindProperties]
public class RegisterModel : PageModel
{
    #region Properties

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string FullName { get; set; }

    [Display(Name = "رمز عبور")]
    [MinLength(4, ErrorMessage = "{0} باید بیشتر از 4 رقم باشد")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Password { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(4, ErrorMessage = "{0} باید بیشتر از 4 رقم باشد")]
    public string UserName { get; set; }
    #endregion

    private readonly IUserService _userService;
    public RegisterModel(IUserService userService)
    {
        _userService = userService;
    }
    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        var result = _userService.RegisterUser(new UserRegisteryDTO()
        {
            FullName = FullName,
            UserName = UserName,
            Password = Password
        });
        if (result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("UserName", result.Message);
            return Page();
        }
        return RedirectToPage("Login");
    }
}
