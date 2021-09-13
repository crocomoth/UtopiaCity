using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UtopiaCity.Controllers
{
    public class MailSenderController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public string SendEmail(string Name, string Email, string Message)
        {

            try
            {
                // Credentials
                var credentials = new NetworkCredential("2681567f7e14e0", "d4bb031a8ee6b3");
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
                    Port = 587,
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
