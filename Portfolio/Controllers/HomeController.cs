using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;
using System.Xml.Linq;
using MailKit;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            environment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var skillsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\lib\\skills.txt");
            var skillsFormattedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\lib\\skills_formatted.txt");

            if (System.IO.File.Exists(skillsFilePath))
            {
                var skills = System.IO.File.ReadLines(skillsFilePath).ToArray();
                var skills_formatted = System.IO.File.ReadLines(skillsFormattedFilePath).ToArray();

                ViewBag.Skills = skills;
                ViewBag.SkillsFormatted = skills_formatted;
            }
            else
            {
                ViewBag.Skills = "File not found.";
                ViewBag.SkillsFormatted = "File not found.";
            }
            return View();
        }       

        public FileResult AdrianCollins_2024()
        {
            var filepath = Path.Combine(environment.WebRootPath, "files", "AdrianCollins_CV(2024).pdf");
            byte[] FileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(FileBytes, "application/pdf");
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
                string myEmail = "adriancollins59@live.com";
                const string myPassword = "T2qv9jB8kfJaZhkpgANsQZb";
                const string sub = "Portfolio Email";

                var usersAddress = new MailAddress(model.Email);
                var body = model.Message;

                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = usersAddress;
                    mailMessage.To.Add(new MailAddress(myEmail));
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = sub;
                    mailMessage.Body = body;
                    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                    SmtpClient client = new SmtpClient();
                    
                    NetworkCredential su = new NetworkCredential(myEmail, myPassword);
                    client.Host = "smtp-mail.outlook.com";
                    client.Port = 587;
                    client.Credentials = su;
                    client.Send(mailMessage);

                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("it worked");

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