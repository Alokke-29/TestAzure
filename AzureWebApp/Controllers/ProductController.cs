using AzureWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Load Create Page

        public IActionResult Create()
        {
            return View();
        }

        // Add Employee

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Delete Employee

        public IActionResult Delete(int id)
        {
            var emp = _context.Products.Find(id);

            if (emp != null)
            {
                _context.Products.Remove(emp);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
    }
}
