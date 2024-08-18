using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codeyad.Web.Areas.Admin.Controllers;


public class HomeController : AdminControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}
