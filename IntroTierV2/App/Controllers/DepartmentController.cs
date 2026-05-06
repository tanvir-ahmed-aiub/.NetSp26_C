using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace App.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service)
        {
            this.service = service;
        }

        public IActionResult List()
        {
            var data = service.Get();
            return View();
        }
    }
}
