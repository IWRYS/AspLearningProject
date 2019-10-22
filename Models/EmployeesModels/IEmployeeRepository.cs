using System.Collections.Generic;

namespace asp.net.LearningProject.Models
{
   public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        IEnumerable<Employee> GetEmployees();

        Employee Add(Employee employee);

        Employee Update(Employee employeeChanges);

        Employee Delete(int id);

        string EmployeeTown(int id);
    }
}
