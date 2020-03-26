using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDBService _dBService;
        public StudentsController(IDBService dBService)
        {
            _dBService = dBService;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dBService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //..add to db
            //..generate index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudents(int id)
        {
            {
                return Ok("Updated");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudents(int id)
        {
            {
                return Ok("Deleted");
            }
        }

    }
}