using IntroWebAPICore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            var s = new StudentDTO() {
                Id = 1,
                Name = "S1",
                Phone="1234546",
                Email="s.a@aiub.edu"
            };
            var s2 = new StudentDTO()
            {
                Id = 2,
                Name = "S2",
                Phone = "1234546",
                Email = "s2.a@aiub.edu"
            };
            var list =new List<StudentDTO>();
            list.Add(s);
            list.Add(s2);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(StudentDTO s) {
            return Ok("Hello");
        }
    }
}
