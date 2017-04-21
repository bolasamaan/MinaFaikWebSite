using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MinaFaik2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // WEGOOOOOOO
        // Test Editing any file
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            //HOY
            //Test BOLA-------------------------------------------------Wego
            return View();

        }

         [HttpPost]
        public ActionResult EMAILMina(FormCollection form)
        {
             var subjectText ="";
             var fromText = "";
             var toText = "info@minafaikprofessional.com";
             var messageText ="";
             var nameText = "";

             MailPriority priority = MailPriority.Normal;
             bool isHtml = false;

            foreach (var key in form.AllKeys)
            {
                if (key.ToLower() == "subject")
                    subjectText = form[key];
                
                if (key.ToLower() == "email")
                    fromText = form[key];
             
                if (key.ToLower() == "message")
                    messageText = form[key];

                if (key.ToLower() == "name")
                    nameText = form[key];
             
                var test = form[key];
            }

            MailMessage mail = new MailMessage()
            {
                Subject = subjectText,
                From = new MailAddress(fromText),
                Body = "Message from " + nameText + ". The message is the following " + Environment.NewLine +  messageText,
                IsBodyHtml = isHtml,
                Priority = priority
            };

            mail.To.Add(toText);
            //mail.Bcc.Add(bcc);
            string smtpHost = "smtpout.secureserver.net";                 
            int smtpPort = 3535;

            string smtpUsername = "info@minafaikprofessional.com";
            string smtpPassword = "minafaikprofessional";

            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            //SmtpClient client = new SmtpClient();

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);

            client.Credentials = credentials;
            client.Send(mail);
            mail.Dispose();
            client = null;

            return RedirectToAction("Index");
        }

    }
}
