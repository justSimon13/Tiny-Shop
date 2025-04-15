using Microsoft.AspNetCore.Mvc;

namespace TinyStore.Web.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}