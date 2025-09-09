using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Banking.Service;
using Banking.Models;
namespace Sample_mail.Controllers
{
    public class SupportController : Controller
    {
        private AdminService adminService;

        public SupportController()
        {
            adminService = new AdminService();
        }

        private BankingDBEntities1 db= new BankingDBEntities1();

        [HttpGet]
        public ActionResult SendSupportMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSupportMessage(SupportMessage supportMessage)
        {
            if (ModelState.IsValid)
            {
                var result = adminService.RaiseSupportMessage(supportMessage);

                ViewBag.Status = result.message;

                // Optionally redirect or return a view
                return View("SendSupportMessage", supportMessage);
            }

            ViewBag.Status = "Invalid input. Please check your details.";
            return View("SendSupportMessage", supportMessage);

        }
      
        

          
          


         
    [HttpGet]
        public ActionResult ViewMessages()
        {
            var messages = db.SupportMessages
                                 .Where(m => m.Status == "Pending")
                                 .ToList();
            return View(messages);

        }
       

        public ActionResult ResolvedMessages()
        {
            var messages = db.SupportMessages
                             .Where(m => m.Status != "Pending")
                             .ToList();
            return View("ViewMessages", messages); // reuse the same view or create a new one
        }

        [HttpGet]
        public ActionResult ReplyToMessage(int id)
        {
            var message = db.SupportMessages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        [HttpPost]
        public ActionResult ReplyToMessage(int id, string reply)
        {
            var message = db.SupportMessages.Find(id);
            if (message != null)
            {
                message.AdminReply = reply;
                message.RepliedAt = DateTime.Now;
                message.Status = "Solved"; // ✅ Set status
                db.SaveChanges();

                // Optionally send reply via email
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("admin@gmail.com"));
                email.To.Add(MailboxAddress.Parse(message.UserEmail));
                email.Subject = "Reply to your support request";
                email.Body = new TextPart("plain") { Text = reply };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("tarakakillada@gmail.com", "baev kroz pvpf trck");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }

            return RedirectToAction("ViewMessages");
        }
    }

}

