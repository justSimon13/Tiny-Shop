using Microsoft.AspNetCore.Mvc;

namespace TinyShop.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}