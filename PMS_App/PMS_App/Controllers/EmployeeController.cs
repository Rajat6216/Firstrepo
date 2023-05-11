using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS_App.Models;
using System.Numerics;
using System.Reflection;

namespace PMS_App.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee_Model> Record_List = new List<Employee_Model> {
        new Employee_Model
        {
            Id = 1,
            Emp_Name = "Rajat kushwah",
            User_Name = "Rj101",
            Email = "rajat@example.com",
            User_Password = "password123",
            Phone = "94280468"
        },
        new Employee_Model
        {
            Id=2,
            Emp_Name = "Mohit Gupta",
            User_Name = "Gm102",
            Email = "mohit@example.com",
            User_Password = "password456",
            Phone = "123456789"
        },
        new Employee_Model
        {
            Id=3,
            Emp_Name = "punit b",
            User_Name = "pb103",
            Email = "punit@example.com",
            User_Password = "password789",
            Phone = "987654321"
        }
    };


        public IActionResult Index()
        {
           


            return View(Record_List);


        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(Employee_Model model)
        {
              Record_List.Add(new Employee_Model()
                {
                    Id = model.Id,
                    Emp_Name = model.Emp_Name,
                    User_Name = model.User_Name,
                    Email = model.Email,
                    User_Password = model.User_Password,
                    Phone = model.Phone

                });
                var record = Record_List;
                return RedirectToAction("Index",record);

             


        }



        public IActionResult Edit(int id)
        {
            var employee = Record_List.FirstOrDefault(e => e.Id == id);



            return View(employee);
        }



        [HttpPost]
        public IActionResult Edit(Employee_Model model)
        {
            var employee = Record_List.FirstOrDefault(e => e.Id == model.Id);
            if (employee == null)
            {
                return View("Error");
            }

            employee.Emp_Name = model.Emp_Name;
            employee.User_Name = model.User_Name;
            employee.Email = model.Email;
            employee.User_Password = model.User_Password;
            employee.Phone = model.Phone;

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var existingRecord = Record_List.FirstOrDefault(r => r.Id == id);

            if (existingRecord != null)
            {
                Record_List.Remove(existingRecord);
            }

            var updatedList = Record_List.ToList();
            return RedirectToAction("Index");
        }




    }
}
