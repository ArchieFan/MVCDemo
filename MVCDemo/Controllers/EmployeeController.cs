using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index(int departmentId = 0)
        {
            ModelsContext employeeContext = new ModelsContext();
            List<Employee> employees = employeeContext.Employees.Where(em => em.departmentId == departmentId).ToList();

            return View(employees);
        }
        // GET: Employee
        public ActionResult Details(int id = 0)
        {
            //Employee employee = new Employee()
            //{
            //    EmployeeId = 101,
            //    Name = "John",
            //    Gender = "Male",
            //    City = "London"
            //};
            ModelsContext employeeContext = new ModelsContext();
            Employee employee = employeeContext.Employees.Single(x => x.EmployeeId == id);

            return View(employee);
        }
    }
}