using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price=275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price=49.95M},
            new Product {Name = "Soccer Ball", Category = "Soccer", Price=9.9M},
            new Product {Name = "Corner flag", Category = "Soccer", Price=34.95M}
        };
        private IValueCalculator calc;

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}