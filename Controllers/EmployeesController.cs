using asp.net.LearningProject.Models;
using asp.net.LearningProject.Models.TownsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp.net.LearningProject.ViewModels;
using System.Net;

namespace asp.net.LearningProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }

        [Route("")]
        [Route("Home")]
        public IActionResult Home()
        {
            var model = employeeRepository.GetEmployees();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int? id)
        {
            
            var  currEmployee = employeeRepository.GetEmployee(id.Value);

            if (currEmployee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            EmployeeDetailsViewmodel employee = new EmployeeDetailsViewmodel()
            {
                Employee = currEmployee,
                PageTitle = "Employee Details",
                Town = employeeRepository.EmployeeTown(currEmployee.EmployeeId)
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
        public IActionResult CreateEmployee(EmployeeDetailsViewmodel employeeDetails)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee();
                newEmployee.Name = employeeDetails.Employee.Name;
                newEmployee.Email = employeeDetails.Employee.Email;
                newEmployee.Department = employeeDetails.Employee.Department;
                newEmployee.TownId = employeeDetails.Employee.TownId;

                employeeRepository.Add(newEmployee);

                return RedirectToAction("GetEmployeeById", new { id = newEmployee.EmployeeId });
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = employeeRepository.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = employeeRepository.GetEmployee(model.EmployeeId);
                employee.Name = model.Name;
                employee.Department = model.Department;
                employee.Email = model.Email;
                employee.TownId = model.TownId;

                employeeRepository.Update(employee);

                return RedirectToAction("GetEmployeeById", new { id = employee.EmployeeId });
            }
            return View();
        }
    }
}
