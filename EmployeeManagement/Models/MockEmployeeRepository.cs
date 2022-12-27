using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeInterface
    {
        private List<Employee> _EmpList;

        public MockEmployeeRepository()
        {
            _EmpList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Yogesh Pawar",Email="pawaryogi@gmail.com",Department="IT"},
                new Employee(){Id=2,Name="Sagar Rane",Email="ranesagar@gmail.com",Department="IT Testing"}
            };
        }   

        public Employee GetEmployee(int id)
        {
            return _EmpList.FirstOrDefault(e => e.Id == id);
        }
    }
}
