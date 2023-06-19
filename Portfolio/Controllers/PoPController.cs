using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class PoPController : Controller
    {
        private readonly ILogger<PoPController> _logger;

        public PoPController(ILogger<PoPController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetModule(string partialName)
        {
            return PartialView($"~/Views/PoP/{partialName}.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}