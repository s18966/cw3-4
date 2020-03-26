using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;

using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDBService _dBService;
        private List<Student> students;
        public StudentsController(IDBService dBService)
        {
            _dBService = dBService;
            students = new List<Student>();
        }
        [HttpGet("{id}")]
        public IActionResult GetStudents(int id)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-Q6CSP2B\\SQLSERVER;Initial Catalog=CW4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using(var com = new SqlCommand())
            {
                com.Connection = con;
                //com.CommandText = $"select * from Student S inner join Enrollment E on S.IdEnrollment = E.IdEnrollment where S.IndexNumber = {id}";
                com.CommandText = "select * from Student where IndexNumber = @id";
                com.Parameters.AddWithValue("id", id);
                con.Open();
                var dr = com.ExecuteReader();
                string str = "";
                while (dr.Read())
                {
                   // str += dr["IdEnrollment"].ToString() + " " + dr["Semester"].ToString() + " " + dr["IdStudy"].ToString() + " " + dr["StartDate"].ToString() + "\n";
                   str += dr["FirstName"].ToString() + " " + dr["LastName"].ToString() + " " + dr["IndexNumber"].ToString() + " " + dr["BirthDate"].ToString() + "\n" + dr["IdEnrollment"];

                }
                return Ok(str);
            }

           
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