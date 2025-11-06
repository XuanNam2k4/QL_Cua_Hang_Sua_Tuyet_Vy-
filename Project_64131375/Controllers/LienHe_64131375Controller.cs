using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;


namespace Project_64131375.Controllers
{
    public class LienHe_64131375Controller : Controller
    {
        // GET: LienHe_64131375
        public ActionResult Index_64131375()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index_64131375(MailInfo_64131375 model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("DaNhanMail_64131375");
        }

        [HttpPost]
        public ActionResult DaNhanMail_64131375(MailInfo_64131375 model)
        {
            return View();
        }

    }
}