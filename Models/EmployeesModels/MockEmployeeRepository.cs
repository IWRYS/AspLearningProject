using asp.net.LearningProject.Models.EmployeesModels.Enums;
using System.Collections.Generic;
using System.Linq;
namespace asp.net.LearningProject.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeeList;

        public MockEmployeeRepository()
        {
            employeeList = new List<Employee>()
            {
                new Employee() {EmployeeId=1,Name="Name1",Department =Departament.Accounting,Email ="email1"},
                new Employee() {EmployeeId=2,Name="Name2",Department =Departament.HR,Email ="email2"},
                new Employee() {EmployeeId=3,Name="Name3",Department =Departament.IT,Email ="email3"}

            };
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = employeeList.Max(e => e.EmployeeId) + 1;
            employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = employeeList.FirstOrDefault(x => x.EmployeeId == id);

            if(employee != null)
            {
                employeeList.Remove(employee);
            }

            return employee;
        }

        public string EmployeeTown(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return employeeList.FirstOrDefault(x => x.EmployeeId == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeList;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employeeList.FirstOrDefault(x => x.EmployeeId == employeeChanges.EmployeeId);

            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }

            return employee;
        }
    }
}
