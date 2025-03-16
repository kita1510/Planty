using firstWeb.Models;
using FrameworkProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FrameworkProject.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string mess)
        {
            if (mess != null)
            {
                ViewData["Message"] = mess;
            }
            else
            {
                ViewData["Message"] = "";

            }
            return View();
        }
        public ActionResult Regis(string mess = "")
        {
            ViewData["message"] = mess;
            return View();
        }

        public ActionResult Profile()
        {
            ViewData["fn"] = firstWeb.Program.USERGLOBAL.FIRSTNAME;
            ViewData["ln"] = firstWeb.Program.USERGLOBAL.LASTNAME;
            ViewData["email"] = firstWeb.Program.USERGLOBAL.EMAIL;
            ViewData["ad"] = firstWeb.Program.USERGLOBAL.ADDRESS;
            ViewData["phone"] = firstWeb.Program.USERGLOBAL.PHONE;
            ViewData["pass"] = firstWeb.Program.USERGLOBAL.PASSWORD;
            return View();
        }

        public ActionResult SaveProfile (Users u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.ChangeProfile(u);
            firstWeb.Program.USERGLOBAL.FIRSTNAME = u.FIRSTNAME;
            firstWeb.Program.USERGLOBAL.LASTNAME = u.LASTNAME;
            firstWeb.Program.USERGLOBAL.EMAIL = u.EMAIL;
            firstWeb.Program.USERGLOBAL.PASSWORD = u.PASSWORD;
            firstWeb.Program.USERGLOBAL.ADDRESS = u.ADDRESS;
            firstWeb.Program.USERGLOBAL.PHONE = u.PHONE;
            return RedirectToAction("Profile");
        }

        public ActionResult Load(Users u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            if (u != null)
            {
                Users a = context.LogIn(u);
                if (a.EMAIL == null)
                {
                    string mess = "Account does not exist or wrong password.";
                    return RedirectToAction("Login", new { mess});
                }
                else
                {
                    firstWeb.Program.USERGLOBAL = a;
                    firstWeb.Program.INVOICEGLOBAL = context.Createinvoice(a);
                    return RedirectToAction("Home", "Products");
                }
            }
            else
            {
                string mess = "";
                return RedirectToAction("Login", new { mess});
            }
            ;
        }

        public ActionResult LoadConfirmMailtoHome (string s)
        {
            if (s == "ecommerce")
            {
                StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
                context.ChangePassword(firstWeb.Program.USERGLOBAL);
                firstWeb.Program.USERGLOBAL = context.LogIn(firstWeb.Program.USERGLOBAL);
                firstWeb.Program.INVOICEGLOBAL = context.Createinvoice(firstWeb.Program.USERGLOBAL);
                return RedirectToAction("Home", "Products");
            }
            else
            {
                string mess = "Wrong code";
                return RedirectToAction("ConfirmCode", new { mess });
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ConfirmCode(string mess)
        {
            if (mess != null)
            {
                ViewData["Message"] = mess;
            }
            else
            {
                ViewData["Message"] = "";

            }
            return View();
        }

        public ActionResult SendEmail(Users u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            int a = context.CheckEmail(u.EMAIL);
            if (a > 0)
            {
                //Email người gửi
                string fromMail = "loveyou15102002@gmail.com";

                string fromPassword = "kmchsnvnzfvtfwpd";

                MailMessage message = new MailMessage();


                message.From = new MailAddress(fromMail);
                message.Subject = "Mã xác nhận thay đổi mật khẩu";
                // config here
                message.To.Add(new MailAddress(u.EMAIL));
                string s = "ecommerce";
                message.Body = "<html><body>" + s + " là mã xác nhận đó!</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true
                };
                //Gửi đoạn mail
                smtpClient.Send(message);
                firstWeb.Program.USERGLOBAL = u;
                string mess = "";
                return RedirectToAction("ConfirmCode", new { mess });
            }
            else return RedirectToAction("ForgotPassword");
        }

        public ActionResult LoadRegisToHome(Users u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            int c = context.CheckEmail(u.EMAIL);
            if (c > 0)
            {
                string mess = "Account was existed";
                return RedirectToAction("Regis", new { mess });
            }
            else
            {
                Users a = context.InsertUser(u);
                firstWeb.Program.USERGLOBAL = a;
                firstWeb.Program.INVOICEGLOBAL = context.Createinvoice(a);
                return RedirectToAction("Home", "Products");
            }
            
        }

        public ActionResult UserManagement()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;

            return View(context.AllUser());
        }

        public ActionResult Active(int u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.ActiveUser(u);
            return RedirectToAction("UserManagement");
        }
        public ActionResult Delete(int u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.DeleteUser(u);
            return RedirectToAction("UserManagement");
        }

        public ActionResult ToAdmin(int u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.ToAdmin(u);
            return RedirectToAction("UserManagement");
        }
        public ActionResult ToMem(int u)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.ToMem(u);
            return RedirectToAction("UserManagement");
        }
    }
}
