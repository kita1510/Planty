using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrameworkProject.Models;
using firstWeb.Models;

namespace FrameworkProject.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            ViewData["user"] = firstWeb.Program.USERGLOBAL.REGISTRATIONDATE;
            return View();
        }
        public IActionResult Plants()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetProducts();
            return View(list);
        }
        public IActionResult Newest()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetNewest();
            return View(list);
        }
        public IActionResult PriceDesc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetPriceDesc();
            return View(list);
        }
        public IActionResult PriceAsc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetPriceAsc();
            return View(list);
        }
        public IActionResult AddFavor(int p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            Users u = new Users();
            u.USERID = firstWeb.Program.USERGLOBAL.USERID;
            Products pr = new Products();
            pr.PROID = p;
            int a = context.InsertFavoriteProduct(u, pr);
            return RedirectToAction("Plants");
        }
        public IActionResult AddToInvoice(int proid)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            Products p = new Products();
            p.PROID = proid;
            Invoices i = new Invoices();
            i.PACKID = firstWeb.Program.INVOICEGLOBAL.PACKID;
            context.InsertProductintoInvoice(p, i, 1);
            firstWeb.Program.INVOICEGLOBAL = context.GetInv(firstWeb.Program.USERGLOBAL.USERID);
            return RedirectToAction("Plants");
        }

        public IActionResult MyPlants()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetFavoriteProducts(firstWeb.Program.USERGLOBAL.USERID);
            return View(list);
        }
        public IActionResult MyPlantsNewest()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetFavoriteProductsNewest(firstWeb.Program.USERGLOBAL.USERID);
            return View(list);
        }
        public IActionResult MyPlantsPriceDesc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetFavoriteProductsPriceDesc(firstWeb.Program.USERGLOBAL.USERID);
            return View(list);
        }
        public IActionResult MyPlantsPriceAsc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.GetFavoriteProductsPriceAsc(firstWeb.Program.USERGLOBAL.USERID);
            return View(list);
        }

        public IActionResult PlantsCare()
        {
            return View();
        }

        public IActionResult ForSmallSize()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProducts(1);
            return View(list);
        }
        public IActionResult ForSmallSizeNewest()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsNewest(1);
            return View(list);
        }
        public IActionResult ForSmallSizePriceDesc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsPriceDesc(1);
            return View(list);
        }
        public IActionResult ForSmallSizePriceAsc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsPriceAsc(1);
            return View(list);
        }

        public IActionResult ForLargeSize()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProducts(2);
            return View(list);
        }
        public IActionResult ForLargeSizeNewest()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsNewest(2);
            return View(list);
        }
        public IActionResult ForLargeSizePriceDesc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsPriceDesc(2);
            return View(list);
        }
        public IActionResult ForLargeSizePriceAsc()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            List<Products> list = new List<Products>();
            list = context.SelectProductsPriceAsc(2);
            return View(list);
        }

        public IActionResult ProductManagement()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            
            return View(context.AllProducts());
        }

        public IActionResult Delete(int p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.DeleteProduct(p);
            return RedirectToAction("ProductManagement");
        }

        public IActionResult ReSale(int p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.ReSaleProduct(p);
            return RedirectToAction("ProductManagement");
        }

        public IActionResult Get10Qty (int p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.Add10Product(p);
            return RedirectToAction("ProductManagement");
        }

        public ActionResult AddProductView ()
        {
            return View();
        }

        public ActionResult AddProduct(Products p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(firstWeb.Models.StoreContext)) as StoreContext;
            context.InsertProduct(p);
            return RedirectToAction("ProductManagement");
        }
    }
}
