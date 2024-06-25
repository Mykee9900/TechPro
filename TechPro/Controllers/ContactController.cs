using Microsoft.AspNetCore.Mvc;

namespace TechPro.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}