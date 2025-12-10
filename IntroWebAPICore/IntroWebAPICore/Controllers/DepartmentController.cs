using IntroWebAPICore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult All() {
            var d1 = new DepartmentDTO() { 
                Id = 1,
                Name = "Test",
            };
            var d2 = new DepartmentDTO()
            {
                Id = 1,
                Name = "Test",
            };
            var list = new List<DepartmentDTO>() { d1, d2 };
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var d1 = new DepartmentDTO() { 
                Id = id,
                Name ="Dept "+id
            };
            return Ok(d1);
        }
        [HttpPost("create")]
        public IActionResult Create(DepartmentDTO s) {
            //
            //
            return Created();
        }
    }
}
