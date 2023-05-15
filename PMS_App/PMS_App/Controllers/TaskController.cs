using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using PMS_App.Model;
using PMS_App.Models;
using System.Reflection;
using System.Threading.Tasks;
using Task = PMS_App.Model.Task;

namespace PMS_App.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        PMSDBContext _db;
        public TaskController(ILogger<TaskController> logger, PMSDBContext db)
        {
            _logger = logger;
            _db = db;
        }


        public IActionResult Index()
        {

            var task = (from t in _db.Task
                        join e in _db.Employee on t.Employee_Id equals e.Id
                        join g in _db.Project on t.Project_Id equals g.Id
                        select new Task_Model
                        {
                            Id = t.Id,
                            Task_Name = t.Task_Name,
                            Task_Description = t.Task_Description,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            Employee_Id = t.Employee_Id,
                            Project_Id = t.Project_Id,
                            IsActive = t.IsActive,
                            Emp_Name = e.Emp_Name,
                            Project_Name = g.Project_Name
                        }).ToList();
            return View(task);

        }
        public IActionResult Create()
        {
            var model = new Task_Model();
            model._EmployeesList = _db.Employee.Select(e => new Employee_Model
            {
                Id = e.Id,
                Emp_Name = e.Emp_Name
            }).ToList();
            model._ProjectsList = _db.Project.Select(p => new Project_Model
            {
                Id = p.Id,
                Project_Name = p.Project_Name
            }).ToList();

            return View(model);
        }

        [HttpPost]

        public IActionResult Create(Task_Model model)
        {
            var task = new Task
            {
                Task_Name = model.Task_Name,
                Task_Description = model.Task_Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Employee_Id = model.Employee_Id,
                Project_Id = model.Project_Id,
                IsActive = model.IsActive,
                IsDeleted = false,
                Created_On = DateTime.Now,
                Updated_On = DateTime.Now,
            };


            model._EmployeesList = _db.Employee.Select(e => new Employee_Model
            {
                Id = e.Id,
                Emp_Name = e.Emp_Name
            }).ToList();
            model._ProjectsList = _db.Project.Select(p => new Project_Model
            {
                Id = p.Id,
                Project_Name = p.Project_Name
            }).ToList();
            _db.Task.Add(task);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var task = _db.Task.FirstOrDefault(e => e.Id == id);
            if (task == null)
            {
                return View("Error");
            }
            var model = new Task_Model
            {
                Id = task.Id,
                Task_Name = task.Task_Name,
                Task_Description = task.Task_Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Employee_Id = task.Employee_Id,
                Project_Id = task.Project_Id,
                IsActive = task.IsActive,
                Created_On = task.Created_On,
                Created_By = task.Created_By,
                Updated_On = task.Updated_On,
                Updated_By = task.Updated_By,
                _EmployeesList = _db.Employee.Select(e => new Employee_Model
                {
                    Id = e.Id,
                    Emp_Name = e.Emp_Name
                }).ToList(),
                _ProjectsList = _db.Project.Select(p => new Project_Model
                {
                    Id = p.Id,
                    Project_Name = p.Project_Name
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Task_Model model)
        {
            var task = _db.Task.FirstOrDefault(e => e.Id == model.Id);
            if (task == null)
            {
                return View("Error");
            }
            task.Task_Name = model.Task_Name;
            task.Task_Description = model.Task_Description;
            task.StartDate = model.StartDate;
            task.EndDate = model.EndDate;
            task.Created_On = model.Created_On;
            task.Updated_On = model.Updated_On;
            task.Employee_Id = model.Employee_Id;
            task.Project_Id = model.Project_Id;


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var existingRecord = _db.Task.FirstOrDefault(r => r.Id == id);

            if (existingRecord != null)
            {
                _db.Task.Remove(existingRecord);
            }


            return RedirectToAction("Index");
        }




    }

}
