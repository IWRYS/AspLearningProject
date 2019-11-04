using asp.net.LearningProject.Data;
using System.Collections.Generic;

namespace asp.net.LearningProject.Models.EmployeesModels
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly MyProjectDBContext context;
        public SQLEmployeeRepository(MyProjectDBContext context)
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
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;

        }

        public string EmployeeTown(int id)
        {
            var employee = context.Employees.Find(id);
            string townName = string.Empty;
            if (employee != null)
            {
                var town = context.Towns.Find(employee.TownId);
                townName = town.Name;
            }

            return townName;

        }

        public Employee GetEmployee(int id)
        {
            var employee = context.Employees.Find(id);

          
            return employee;
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
