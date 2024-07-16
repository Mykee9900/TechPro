using Microsoft.AspNetCore.Mvc;
using TechPro.Models.Data;

namespace TechPro.Controllers;

public class ProductController : Controller
{
    public IActionResult Index(Models.ProductViewModel vm)
    {
        
        return View();
    }

    public IActionResult CartACtion()
    {
        return View("Index");
    }
}