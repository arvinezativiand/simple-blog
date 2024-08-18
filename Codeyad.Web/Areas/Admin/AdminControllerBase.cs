using Codeyad.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using static Codeyad.CoreLayer.Utilities.OperationResult;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Codeyad.Web.Areas.Admin;

[Area("Admin")]
[Authorize]
public class AdminControllerBase : Controller
{
    protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success());
        HttpContext.Response.Cookies.Append("SustemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return View();
        return redirectPath;
    }
    protected void SuccessAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success());
        HttpContext.Response.Cookies.Append("SustemAlert", model);
    }
    protected void SuccessAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success(message));
        HttpContext.Response.Cookies.Append("SustemAlert", model);
    }
    protected void ErrorAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error());
        HttpContext.Response.Cookies.Append("SustemAlert", model);
    }
    protected void ErrorAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error(message));
        HttpContext.Response.Cookies.Append("SustemAlert", model);
    }
}
