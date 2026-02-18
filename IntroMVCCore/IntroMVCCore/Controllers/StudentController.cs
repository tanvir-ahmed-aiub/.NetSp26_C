using IntroMVCCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace IntroMVCCore.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Name = "Tanvir";
            //ViewData["Cgpa"] = 3.45f; //Dictionary
            Student s1 = new Student();
            s1.Name = "A";
            s1.Cgpa = 3.45f;
            s1.HSCGpa = 5.00f;
            s1.Id = 1;
            
            return View(s1);
        }
        public IActionResult List() { 
            Random random = new Random();
            
            List<Student> data = new List<Student>();
            for (int i = 1; i <= 50; i++) {
                var s = new Student() { 
                    Id = i,
                    Name = "Student "+i,
                    Cgpa =(float) (random.Next(2,4)+random.NextDouble()),
                    HSCGpa = (float)(random.Next(2, 5) + random.NextDouble())
                };
                data.Add(s);
            }
            return View(data);  
        }
        //public IActionResult List()
        //{
        //    string[] names = new string[] {"Rahim","Karim","Latif" };
        //    ViewBag.Names = names;
        //    return View(names); //model binding
        //}
        public IActionResult Create() { 
            return View();
        }
    }
}
