using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MockDbService : IDBService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>();
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
