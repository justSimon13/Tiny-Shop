using Microsoft.AspNetCore.Mvc;

namespace TinyShop.Web.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}