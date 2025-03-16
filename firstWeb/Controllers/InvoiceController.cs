using firstWeb.Models;
using FrameworkProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FrameworkProject.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Package()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            Invoices i = new Invoices();
            i.PACKID = firstWeb.Program.INVOICEGLOBAL.PACKID;
            _ = new List<Products>();
            List<Products> list = context.SelectInvoiceDetail(i);
            ViewData["Inv"] = firstWeb.Program.INVOICEGLOBAL.TOTALPRICE;
            ViewData["list"] = list;

            return View(list);
        }
        public IActionResult Giam(int p, int q, string s)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            InvoiceDetail i = new InvoiceDetail();
            i.PACKID = firstWeb.Program.INVOICEGLOBAL.PACKID;
            i.PROID = p;
            if (s == "t")
            {
                i.QUANTITY = q + 1;
            }
            else
            {

            i.QUANTITY = q - 1;
            }
            context.UpdateProductInInvoice(i);
            firstWeb.Program.INVOICEGLOBAL = context.GetInv(firstWeb.Program.USERGLOBAL.USERID);
            return RedirectToAction("Package");
        }
        public IActionResult Tang(int p, int q)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            InvoiceDetail i = new InvoiceDetail();
            i.PACKID = firstWeb.Program.INVOICEGLOBAL.PACKID;
            i.PROID = p;
            i.QUANTITY = q + 1;
            int a = context.UpdateProductInInvoice(i);
            return View();
        }
        
        public IActionResult Succeed()
        {
            //Email người gửi
            string fromMail = "loveyou15102002@gmail.com";

            string fromPassword = "kmchsnvnzfvtfwpd";

            MailMessage message = new MailMessage();

            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.Pay(firstWeb.Program.INVOICEGLOBAL);

            message.From = new MailAddress(fromMail);
            message.Subject = "Chúc mừng bạn đã đặt hàng tại Planty'x thành công!";
            // config here
            message.To.Add(new MailAddress(firstWeb.Program.USERGLOBAL.EMAIL));
            message.Body = "<html><body>Chúc mừng bạn đã đặt hàng tại Planty'x thành công!<br /> " +
                "Vui lòng chuyển khoản vào số tài khoản xxxxxx với số tiền " + firstWeb.Program.INVOICEGLOBAL.TOTALPRICE.ToString()
                + "đ!<br/>Xin cảm ơn,<br />Thân. </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            //Gửi đoạn mail
            smtpClient.Send(message);
            ViewData["name"] = firstWeb.Program.USERGLOBAL.LASTNAME;
            ViewData["price"] = firstWeb.Program.INVOICEGLOBAL.TOTALPRICE;
            ViewData["add"] = firstWeb.Program.USERGLOBAL.ADDRESS;
            return View();
        }
    }
}
