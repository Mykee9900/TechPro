using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}