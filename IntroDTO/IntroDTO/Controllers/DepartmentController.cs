using IntroDTO.DTOs;
using IntroDTO.EF;
using IntroDTO.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroDTO.Controllers
{
    public class DepartmentController : Controller
    {
        StudentMsCSp26Context db;
        public DepartmentController(StudentMsCSp26Context db) { 
            this.db = db;
        }

        [HttpGet]
        public IActionResult Create() {
            return View();        
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO d) {
            if (ModelState.IsValid) {
                var dept = new Department() { 
                    Name  = d.Name,
                };
                db.Departments.Add(dept);
                db.SaveChanges();
                return View();
            }
            return View();
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
