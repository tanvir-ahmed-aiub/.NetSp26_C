using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService;
        CategoryService categoryService;

        public ProductController(ProductService productService, CategoryService categoryService) { 
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var data = productService.Get();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create() {
            ViewBag.Categories = categoryService.Get();
            return View(new ProductDTO());
        }
        [HttpPost]
        public IActionResult Create(ProductDTO p) {
            if (ModelState.IsValid) { 
               var res = productService.Create(p);
                if (res == true) {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = categoryService.Get();
            return View(p);
            
        }
        [HttpGet]
        public IActionResult Edit(int id) { 
            var data = productService.Get(id);
            ViewBag.Categories = categoryService.Get();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ProductDTO p)
        {
            if (ModelState.IsValid)
            {
                var res = productService.Update(p);
                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Categories = categoryService.Get();
            return View(p);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var data = productService.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, string Decision) {
            if (Decision.Equals("Yes")) { 
                productService.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
