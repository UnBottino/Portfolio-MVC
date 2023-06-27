using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        //GET
        public IActionResult Contact()
        {
            return View(new ContactMessage());
        }

        //POST
        [HttpPost]
        public JsonResult Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                var myEmail = new MailAddress("unbottino@gmail.com", "Adrian Collins");
                const string myPassword = "password";
                const string sub = "Portfolio Email";

                var body = model.FirstName + " ";
                body += model.Surname + "\r\n";
                body += model.Email + "\r\n";
                body += model.PhoneNumber + "\r\n";
                body += model.Message;

                try
                {
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(myEmail.Address, myPassword)
                    };
                    using var message = new MailMessage(myEmail, myEmail)
                    {
                        Subject = sub,
                        Body = body
                    };
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Json(new { Success = true, redirectToUrl = Url.Action("About", "Home") });
            }

            return Json(new { Success = false });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
