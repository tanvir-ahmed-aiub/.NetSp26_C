using AutoMapper;
using IntroCFWebAPICore.DTOs;
using IntroCFWebAPICore.EF;
using IntroCFWebAPICore.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCFWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly SMSContext db;
        public DepartmentController(SMSContext db) { 
            this.db = db;
        }

        [HttpGet("all")]
        public IActionResult All() {
            var data = db.Departments.ToList();
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(DepartmentDTO d) {
            var config = new MapperConfiguration(cfg => { 
                cfg.CreateMap<Department,DepartmentDTO>().ReverseMap();
            });
            var mapper = new Mapper(config);
            db.Departments.Add(mapper.Map<Department>(d));
            db.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) { 
            var data = db.Departments.Find(id);
            return Ok(data);
        }



    }
}
