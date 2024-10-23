using Microsoft.AspNetCore.Mvc;
using MVCProjectIntro.Models;

namespace MVCProjectIntro.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product {Id= 1 ,Name = "Sandalye", Price=100 },
            new Product {Id= 2 ,Name = "Yulaf Sütü", Price=200 },
            new Product {Id= 3 ,Name = "Mouse", Price=150 }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(products);
        }
    }
}
