using asp.net.LearningProject.Models;
using asp.net.LearningProject.Models.TownsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp.net.LearningProject.ViewModels;


namespace asp.net.LearningProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }

        [Route ("")]
        [Route("Home")]
        public IActionResult Home()
        {
            var model = employeeRepository.GetEmployees();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            EmployeeDetailsViewmodel employee = new EmployeeDetailsViewmodel()
            {
                Employee = employeeRepository.GetEmployee(id),
                PageTitle = "Employee Details",
                Town = employeeRepository.EmployeeTown(id)

            };

            return View(employee);
        }

        [HttpGet]
        public IActionResult AllEmployees()
        {
            var employees = employeeRepository.GetEmployees();
            return View(employees);
        }


    
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return RedirectToAction("home");
        }



        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult CreateEmployee(EmployeeDetailsViewmodel employeeDetails)
        {
            var newEmployee = new Employee();
            newEmployee.Name = employeeDetails.Employee.Name;
            newEmployee.Email = employeeDetails.Employee.Email;
            newEmployee.Department = employeeDetails.Employee.Department;
            newEmployee.TownId = employeeDetails.Employee.TownId;

            employeeRepository.Add(newEmployee);

            return RedirectToAction("GetEmployeeById", new { id = newEmployee.EmployeeId });
        }



        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = employeeRepository.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult EditEmployee(int id,Employee employee)
        {
            employeeRepository.Update(employee);

            return View(employee);
        }
    }
}
