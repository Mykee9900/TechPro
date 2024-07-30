using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TechPro.Data;
using TechPro.Models;

namespace TechPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendChat(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return Json(new { message = "Message cannot be empty." });
            }

            var chatMessage = new ChatBox
            {
                CustomerID = 1, 
                Message = msg,
                DateTime = DateTime.Now,
                MessageStatus = "Sent"
            };

            _context.ChatBoxes.Add(chatMessage);
            await _context.SaveChangesAsync();

            return Json(new { message = "Message sent successfully!" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}