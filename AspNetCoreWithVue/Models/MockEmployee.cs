using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models
{
    public class MockEmployee : IEmployee
    {
        private List<Employee> _employeeList;

        public MockEmployee()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = "1" , Name = "Dilshan" , Department = "IT"},
                new Employee() { Id = "2" , Name = "Hasitha" , Department = "HR"},
                new Employee() { Id = "3" , Name = "Fernando" , Department = "Account"}
            };
        }
        public List<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
