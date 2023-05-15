using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS_App.Model;
using PMS_App.Models;
using System.Numerics;
using System.Reflection;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace PMS_App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        PMSDBContext _db;
        public EmployeeController(ILogger<EmployeeController> logger, PMSDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(Employee_Model model)
        {
            //var GetEmployee = (from e in _db.Employee

            //                   select e ).ToList();
            var employees = _db.Employee.Select(e => new Employee_Model
            {
                Id = e.Id,
                Emp_Name = e.Emp_Name,
                UserName = e.UserName,
                Email = e.Email,
                User_Password = e.User_Password,
                Phone = e.Phone,

            }).ToList();
            return View(employees);

        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(Employee_Model model)
        {
            var newEmployee = new Employee
            {
                Emp_Name = model.Emp_Name,
                UserName = model.UserName,
                Email = model.Email,
                User_Password = model.User_Password,
                Phone = model.Phone,
                Created_On = DateTime.Now,
                Updated_On = DateTime.Now,
                IsActive = model.IsActive

            };

            _db.Employee.Add(newEmployee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {

            var employee = _db.Employee.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeModel = new Employee_Model
            {
                Id = employee.Id,
                Emp_Name = employee.Emp_Name,
                UserName = employee.UserName,
                Email = employee.Email,
                User_Password = employee.User_Password,
                Phone = employee.Phone,
                IsActive = employee.IsActive

            };

            return View(employeeModel);



        }



        [HttpPost]
        public IActionResult Edit(Employee_Model model)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.Id == model.Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Emp_Name = model.Emp_Name;
            employee.UserName = model.UserName;
            employee.Email = model.Email;
            employee.User_Password = model.User_Password;
            employee.Phone = model.Phone;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _db.Employee.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.IsDeleted = true;
                _db.SaveChanges();
            }


            return RedirectToAction("Index");
        }




    }
}