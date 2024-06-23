using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}