using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class DepartmentController : Controller
    {

        [HttpGet]
        public IActionResult List() {
            var service = new DepartmentService();
            var data = service.GetAll();
            
            return View(data);
        }
        [HttpPost]
        public IActionResult Create(){ //param 
            //validation
            var service = new DepartmentService();
            var res = service.Create();
            return View(res);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
