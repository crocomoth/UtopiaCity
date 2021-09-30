using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
namespace UtopiaCity.Controllers
{
    public class MailSenderController : Controller
    {
        private IConfiguration configuration;
        public MailSenderController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public ActionResult Index()
        {
            return View();
        }
        public string SendEmail(string Name, string Email, string Message)
        {

            try
            {
                string user = configuration.GetSection("MailConnecton").GetSection("UserName").Value;

                string secretWord = configuration.GetSection("MailConnecton").GetSection("Password").Value;

                // Credentials
                var credentials = new NetworkCredential(user, secretWord);
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@codinginfinite.com"),
                    Subject = "Email Sender App",
                    Body = Message
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 2525,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.mailtrap.io",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }
    }
}
