using Auth.DTOs;
using Auth.EF;
using Auth.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Controllers
{
    public class AuthController : Controller
    {
        AuthCSp26Context db;

        public AuthController(AuthCSp26Context db) { 
            this.db = db;
        }

        public IActionResult Dashboard() {
            if (HttpContext.Session.GetString("Uname") != null) {
                ViewBag.Uname = HttpContext.Session.GetString("Uname");
                ViewBag.Type = HttpContext.Session.GetInt32("UType");
                return View();
            }
            return Unauthorized();
            
        }

        [HttpGet]
        public IActionResult Login() { 
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Uname, string Password) {
            var user = (from u in db.Users   
                       where u.Username.Equals(Uname) &&
                       u.Password.Equals(GetMd5(Password))
                       select u).SingleOrDefault();
            if (user != null) {
                HttpContext.Session.SetString("Uname", user.Username);
                HttpContext.Session.SetInt32("UType",user.Type );
                return RedirectToAction("Dashboard");
            }
            TempData["Msg"] = "Username and Passsword Invalid";
            return View();
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
                    Password = GetMd5(obj.Password),
                    Username = obj.Username,
                    Type = 2
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View(obj);
        }
        string GetMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // lowercase hex
                }

                return sb.ToString();
            }
        }

    }
}
