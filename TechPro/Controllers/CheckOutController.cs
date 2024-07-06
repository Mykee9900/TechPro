using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;

public class CheckOutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}