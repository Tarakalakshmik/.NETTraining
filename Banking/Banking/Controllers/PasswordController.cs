using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

namespace Banking.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        private BankingDBEntities1 db = new BankingDBEntities1();

        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        
        public ActionResult Login(string email, string password)
        {
            var user = db.Internet_Banking_Details.FirstOrDefault(u => u.email == email && u.login_password== password);
            if (user != null)
            {
                Session["UserEmail"] = user.Email_Id;
                Session["CustomerId"] = user.Customer_Id;
                return RedirectToAction("Dashboard", "User");
            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }



        // GET: ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult GenerateOtp(string email)
        {
            var user = db.Internet_Banking_Details.FirstOrDefault(u => u.Email_Id == email);
            if (user == null)
            {
                ViewBag.Error = "Email not found.";
                return View("ForgotPassword");
            }

            var otp = new Random().Next(100000, 999999).ToString();
            Session["OTP"] = otp;
            Session["OTP_Expiry"] = DateTime.Now.AddMinutes(1);
            Session["OTP_Email"] = email;

            SendOtpEmail(email, otp);
            return RedirectToAction("VerifyOtp");
        }

        // GET: VerifyOtp
        public ActionResult VerifyOtp()
        {
            var model = new VerifyOtpViewModel
            {
                Email = Session["OTP_Email"]?.ToString()
            };
            return View(model);
        }

        [HttpPost]
        
        public ActionResult VerifyOtp(string email, string otp)
        {
            var storedOtp = Session["OTP"]?.ToString();
            var expiry = (DateTime?)Session["OTP_Expiry"];

            if (storedOtp == otp && expiry.HasValue && DateTime.Now <= expiry.Value)
            {
                var user = db.Internet_Banking_Details.FirstOrDefault(u => u.email == email);
                if (user != null)
                {
                    Session["UserEmail"] = user.email;
                    Session["CustomerId"] = user.Account_Number;
                    return RedirectToAction("Dashboard", "User");
                }
            }

            ViewBag.Error = "Invalid or expired OTP.";
            return View();
        }

        private void SendOtpEmail(string toEmail, string otp)
        {
            var fromAddress = new MailAddress("yourbank@example.com", "Online Banking");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "your-email-password";
            const string subject = "Your OTP for Online Banking";
            string body = $"Your OTP is: {otp}. It is valid for 1 minute.";

            var smtp = new SmtpClient
            {
                Host = "smtp.yourprovider.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }
}





  