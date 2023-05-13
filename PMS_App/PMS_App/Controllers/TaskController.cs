using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using PMS_App.Models;
using System.Reflection;
using System.Threading.Tasks;

namespace PMS_App.Controllers
{
    public class TaskController : Controller
    {
        private static List<Task_Model> RecordList = new List<Task_Model>
        {
            new Task_Model
        {
            Id = 1,
            Task_Name = "Create task manager",
            Task_Description = "Develop a task manager application",
            Start_Date = new DateTime(2022, 6, 1),
            End_Date = new DateTime(2022, 6, 30),
            IsActive = true,
           _EmployeesList = new List<Employee_Model>
            {
                new Employee_Model { Id = 3, Emp_Name = "Mark" }
            },
            _ProjectsList = new List<Project_Model>
            {
              new Project_Model { Id = 3, Project_Name = "Design website UI" }
            }
        },
        new Task_Model
        {
            Id = 2,
            Task_Name = "Crud operation",
            Task_Description = "Develop a task manager application",
            Start_Date = new DateTime(2022, 8, 16),
            End_Date = new DateTime(2023, 6, 30),
            IsActive = true,
           _EmployeesList= new List<Employee_Model>
            {

                    new Employee_Model { Id = 1,Emp_Name="Wood"},
           },
            _ProjectsList = new List<Project_Model>
            {
                new Project_Model { Id = 2, Project_Name = "Develop mobile app" }
              }
        },
            new Task_Model
            {
                 Id = 3,
                Task_Name = "Create task manager",
                Task_Description = "Develop a task manager application",
                Start_Date = new DateTime(2022, 6, 1),
                End_Date = new DateTime(2022, 6, 30),
                IsActive = true,
                _EmployeesList = new List<Employee_Model>
              {
                new Employee_Model { Id = 1, Emp_Name = "Rajat" }

            },
                _ProjectsList = new List<Project_Model>
            {
                new Project_Model { Id = 1, Project_Name = "Create quotation pdf" }
                         }
            }

    };

        public IActionResult Index(Task_Model model)
        {


            return View(RecordList);
        }
        public IActionResult Create()
        {
            Task_Model model = new Task_Model();
            model._EmployeesList = BindEmployee();
            model._ProjectsList = BindProject();

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Task_Model model)
        {
            var task = new Task_Model()
            {
                Id = model.Id,
                Task_Name = model.Task_Name,
                Task_Description = model.Task_Description,
                Start_Date = model.Start_Date,
                End_Date = model.End_Date,
                Employee_Id = model.Employee_Id,
                Project_Id = model.Project_Id,
                IsActive = model.IsActive
            };

            task._EmployeesList = BindEmployee();
            task._ProjectsList = BindProject();

            RecordList.Add(task);
            return RedirectToAction("Index", model);


        }


        public IActionResult Edit(int id)
        {
            var model = RecordList.FirstOrDefault(e => e.Id == id);


            model._EmployeesList = BindEmployee();
            model._ProjectsList = BindProject();


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Task_Model model)
        {
            var task = RecordList.FirstOrDefault(e => e.Id == model.Id);
            if (task == null)
            {
                return View("Error");
            }
            task.Task_Name = model.Task_Name;
            task.Task_Description = model.Task_Description;
            task.Start_Date = model.Start_Date;
            task.End_Date = model.End_Date;
            task.Created_On = model.Created_On;
            task.Created_By = model.Created_By;
            task.Updated_On = model.Updated_On;
            task.Updated_By = model.Updated_By;
            task.Employee_Id = model.Employee_Id;
            task._EmployeesList = model._EmployeesList;
            task.Project_Id = model.Project_Id;
            task._ProjectsList = model._ProjectsList;
            
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var existingRecord = RecordList.FirstOrDefault(r => r.Id == id);

            if (existingRecord != null)
            {
                RecordList.Remove(existingRecord);
            }

            var updatedList = RecordList.ToList();
            return RedirectToAction("Index");
        }

        public List<Employee_Model> BindEmployee()
        {
            var _emp = new List<Employee_Model>();
            _emp = new List<Employee_Model>
            {

                    new Employee_Model { Id = 1,Emp_Name="Mohit"},
                    new Employee_Model { Id = 2,Emp_Name="Rajat"},
                     new Employee_Model { Id = 3,Emp_Name="Sachin"},
                      new Employee_Model { Id = 4,Emp_Name="Aditya"}

            };
            return _emp;
        }
        public List<Project_Model> BindProject()
        {
            var _Project = new List<Project_Model>();
            _Project = new List<Project_Model>
            {

                new Project_Model { Id = 1, Project_Name = "Create quotation pdf" },
                new Project_Model { Id = 2, Project_Name = "Develop mobile app" },
                new Project_Model { Id = 3, Project_Name = "Design website UI" }

            };
            return _Project;
        }


    }

}
