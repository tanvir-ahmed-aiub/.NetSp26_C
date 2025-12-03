using IntroEF.DTOs;
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        Fall25_CEntities db = new Fall25_CEntities();
        // GET: Student

        public static Student Convert(StudentDTO s) {
            return new Student()
            {
                    Name = s.Name,
                    Email = s.Email,
                    Address = s.Address,
                    DeptId = s.DeptId
            };
        }
        public static StudentDTO Convert(Student s)
        {
            return new StudentDTO()
            {
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                DeptId = s.DeptId
            };
        }
        public static List<StudentDTO> Convert(List<Student> list) {
            var data = new List<StudentDTO>();
            foreach (var item in list)
            {
                data.Add(Convert(item));
            }
            return data;
        }
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View(new StudentDTO());
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {
            //validation
            if (ModelState.IsValid) {
                var st = Convert(s);
                db.Students.Add(st);
                db.SaveChanges(); //return no of rows affected
                TempData["Msg"] = "Data Created";
                return RedirectToAction("Index");
            }
            return View(s);
            
            
        }
        public ActionResult Details(int id) {
            var data = db.Students.Find(id); //search with primary key
            return View(data);

        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var data = db.Students.Find(id); //search with primary key
            //db.Students.Remove(data);
            //db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student s) { 
            var exObj = db.Students.Find(s.Id);
            exObj.Address = s.Address;
            exObj.Email = s.Email;
            exObj.Name = s.Name;
            db.SaveChanges();
            TempData["Msg"] = "Data Updated";
            return RedirectToAction("Index");
        }
        public ActionResult Search(string id) {
            var data = (from s in db.Students
                       where s.Name.Contains(id)
                       select s).ToList();
            return View(Convert(data));
        }
        public ActionResult Courses() {
            var stId = 1;
            var courses = (from c in db.CourseStudents
                           where c.SId == stId
                           select c).ToList();
            return View(courses);
        }
    }
}