using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(int Id);
        
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
