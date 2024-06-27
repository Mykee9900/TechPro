using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}