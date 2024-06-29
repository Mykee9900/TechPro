using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class ServicesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}