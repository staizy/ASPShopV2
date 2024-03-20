using ASPShopV2.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using ASPShopV2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        public async Task<IActionResult> Print() 
        {
            List <Product> products = await _context.Products.ToListAsync();
            return View("PrintProduct", products);
        }

        [HttpPost]
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

        [HttpGet]
        public IActionResult AddProduct(string Name, string Description, string Price)
        {
            if (Name != null && Price != null)
            {
                _context.Add(new Product(Name, Description, Convert.ToDouble(Price), "None"));
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("null data");
            }
            return RedirectToAction("Print");
        }

        [Route("/print/{id}")]
        //[HttpPost]
        public IActionResult ViewProduct(int id)
        {
            Product value = _context.Products.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditProduct(int id)
        {
            Product value = _context.Products.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult EditSelectedProduct(Product product, string Name, string Description, string Price)
        {
            Product newproduct = _context.Products.Find(product.Id);
            if (newproduct != null)
            {
                newproduct.Name = Name;
                newproduct.Description = Description;
                newproduct.Price = Convert.ToDouble(Price);
                _context.SaveChanges();
                return RedirectToAction("Print");
            }
            return NotFound();
        }

    }
}
