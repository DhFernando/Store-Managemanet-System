using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithVue.Models
{
    public class SQLEmployee : IEmployee
    {
        private readonly AppDbContext context;
        public SQLEmployee(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
