using Microsoft.AspNetCore.Mvc;

namespace Codeyad.Web.Controllers;
public class ErrorHandlerController : Controller
{
    [Route("/ErorrHandler/{code}")]
    public IActionResult Index(int code)
    {
        switch(code){
            case 404: 
                return View("NotFound");

            case 500:
                return View("ServerException");
        }
        
        return View("NotFound");
    }
}
