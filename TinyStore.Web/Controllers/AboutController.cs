using Microsoft.AspNetCore.Mvc;

namespace TinyStore.Web.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}