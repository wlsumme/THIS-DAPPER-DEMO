using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDepartmentRepo
    {
        public IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment(string DepartmentName);
    }
}
