using Azure;
using Codeyad.CoreLayer.DTOs.Users;
using Codeyad.CoreLayer.Services.Users;
using Codeyad.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static Codeyad.CoreLayer.Utilities.OperationResult;

namespace Codeyad.Web.Pages.Auth;

[ValidateAntiForgeryToken]
[BindProperties]
public class _loginModel : PageModel
{

    #region Properties
    [Required(ErrorMessage ="نام کاربری را وارد کنید")]
    public string UserName { get; set; }
    [Required(ErrorMessage ="کلمه عبور را وارد کنید")]
    public string Password { get; set; }
    #endregion


    private readonly IUserService _userService;
    public _loginModel(IUserService userService)
    {
        _userService = userService;
    }  

    public IActionResult OnPost()
    {
        var result = _userService.LoginUser(new UserLoginDto()
        {
            UserName = UserName,
            Password = Password
        });

        if(result == null)
        {
            ModelState.AddModelError("Username", "کاربر یافت نشد");
            return Page();
        }

        var claims = new List<Claim>() 
        {
            new Claim(ClaimTypes.Name, result.FullName),
            new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
            new Claim(ClaimTypes.Role, result.Role.ToString())
        };

        var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var claimPrinciple = new ClaimsPrincipal(Identity);
        HttpContext.SignInAsync(claimPrinciple);
        return Redirect("../Index");
    }
    public void OnGet()
    {

    }
}
