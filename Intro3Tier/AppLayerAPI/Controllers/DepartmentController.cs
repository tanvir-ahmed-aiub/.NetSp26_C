using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service) { 
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult All() {
            var data = service.All();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) { 
            var data = service.Get(id); 
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(DepartmentDTO d) { 
        
            var rs = service.Create(d);
            return Ok(rs);
        }
    }
}
