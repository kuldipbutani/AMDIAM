using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMDIAM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        [HttpPost]
        public async Task<string> SendEmailViaSendGrid(string receiverEmail, string subject, string body)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);

                var from_email = new EmailAddress("no-reply@rushkar.com", "Rushkar - No Reply");
                var to_email = new EmailAddress(receiverEmail, receiverEmail);
                string htmlContent = body;

                var msg = new SendGridMessage()
                {
                    From = from_email,
                    Subject = subject,
                    HtmlContent = htmlContent
                };
                msg.AddTo(to_email);
                var response = await client.SendEmailAsync(msg);

                return response.StatusCode.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }
    }
}