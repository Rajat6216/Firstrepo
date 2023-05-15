using Microsoft.AspNetCore.Mvc;
using PMS_App.Model;
using PMS_App.Models;
using System.Security.Cryptography.Xml;

namespace PMS_App.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        PMSDBContext _db;
        public ProjectController(ILogger<ProjectController> logger, PMSDBContext db)
        {
            _logger = logger;
            _db = db;
        }




        public IActionResult Index()
        {
            var project = _db.Project.Select(e => new Project_Model
            {
                Id = e.Id,
                Project_Name = e.Project_Name,
                StartDate = e.StartDate,
                EndDate = e.EndDate,

            }).ToList();
            return View(project);
        }

        public IActionResult Create()
        {

                
                return View();

        }
        [HttpPost]
        public IActionResult Create(Project_Model model)
        {
            var newProject = new Project
            {
                Id = model.Id,
                Project_Name = model.Project_Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,

                IsActive = model.IsActive

            };
            _db.Project.Add(newProject);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var project = _db.Project.FirstOrDefault(e => e.Id == id);

            var ProjectModel = new Project_Model
            {
                Id = project.Id,
                Project_Name = project.Project_Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                IsActive = project.IsActive
            };

            return View(ProjectModel);
        }

        [HttpPost]
        public IActionResult Edit(Project_Model model)
        {
            var project = _db.Project.FirstOrDefault(e => e.Id == model.Id);

            if (project != null)
            {
                project.Project_Name = model.Project_Name;
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var project = _db.Project.FirstOrDefault(e => e.Id == id);
            if (project != null)
            {
                project.IsDeleted = true;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}