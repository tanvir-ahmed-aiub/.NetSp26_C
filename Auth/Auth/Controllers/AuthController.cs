using Auth.DTOs;
using Auth.EF;
using Auth.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    public class AuthController : Controller
    {
        AuthCSp26Context db;

        public AuthController(AuthCSp26Context db) { 
            this.db = db;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegDTO() { });
        }
        [HttpPost]
        public IActionResult Registration(RegDTO obj) {
            if (ModelState.IsValid) {
                var user = new User() { 
                    Name = obj.Name,
                    Email = obj.Email,
                    Password = obj.Password,
                    Username = obj.Username,
                    Type = 2
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View(obj);
        }
        
    }
}
