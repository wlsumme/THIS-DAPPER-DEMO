using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace ConsoleApp1
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly IDbConnection _conn;

        public DepartmentRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName)", new { newDepartmentName });
        }
    }
}
