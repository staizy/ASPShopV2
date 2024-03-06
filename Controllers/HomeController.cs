using ASPShopV2.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using ASPShopV2.Models;
using System.Collections.Generic;

namespace ASPShopV2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*_context.Products.Add(new Product("Apple", "Green and tasty", 100, "default"));
            _context.SaveChanges();*/
            return View();
        }

        public IActionResult Print() 
        {
            List <Product> products = _context.Products.ToList();
            return View("PrintProduct", products);
        }

        public IActionResult RemoveItem(int id)
        {
            var prod = _context.Products.Find(id);
            if (prod != null)
            {
                _context.Remove(prod);
                _context.SaveChanges();
            }
            List<Product> products = _context.Products.ToList();
            return View("PrintProduct", products);
        }
    }
}
