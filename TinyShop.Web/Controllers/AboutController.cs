using Microsoft.AspNetCore.Mvc;

namespace TinyShop.Web.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}