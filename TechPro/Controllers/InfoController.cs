using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class InfoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}