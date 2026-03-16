using IntroEF.EF;
using IntroEF.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroEF.Controllers
{
    public class DepartmentController : Controller
    {
        StudentMsCSp26Context db;
        public DepartmentController(StudentMsCSp26Context db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Departments.ToList(); //select all
            return View(data);
        }
        public IActionResult Details(int id) {
            var data = db.Departments.Find(id); //works with only PK
            return View(data);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department d) {
            db.Departments.Add(d); //saves a insert query
            var rs = db.SaveChanges(); //commits the query return no of rows affected
            if (rs > 0) {
                TempData["Msg"] = d.Name + " Created Successfully";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = db.Departments.Find(id);
            //data = (from d in db.Departments where d.Id == id select d).SingleOrDefault();
            return View(data);

        }
        [HttpPost]
        public IActionResult Update(Department d) { 
            var dbObj = db.Departments.Find(d.Id);
            dbObj.Name = d.Name;
            //
            //
            //
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //var dbObj = db.Departments.Find(pk);
        //db.Departments.Remove(dbObj);
        //db.SaveChanges();


    }
}
