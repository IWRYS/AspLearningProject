using asp.net.LearningProject.Data;
using System.Collections.Generic;

namespace asp.net.LearningProject.Models.EmployeesModels
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly MyProjectDBContext context;
        public SQLEmployeeRepository(MyProjectDBContext context )
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }


        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
            
        }

        public string EmployeeTown(int id)
        {
            var employee = context.Employees.Find(id);
            var town = context.Towns.Find(employee.TownId);
            return town.Name;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
