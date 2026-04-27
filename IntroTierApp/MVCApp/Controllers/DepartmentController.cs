using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service) { 
            this.service = service;
        }

        [HttpGet]
        public IActionResult List() {
            
            var data = service.GetAll();
            
            return View(data);
        }
        [HttpPost]
        public IActionResult Create(){ //param 
            //validation
            
            var res = service.Create();
            return View(res);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
