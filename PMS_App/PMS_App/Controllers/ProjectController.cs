using Microsoft.AspNetCore.Mvc;
using PMS_App.Models;
using System.Security.Cryptography.Xml;

namespace PMS_App.Controllers
{
    public class Project : Controller
    {
        private static List<Project_Model> Record_List = new List<Project_Model>
    {
    new Project_Model
    {
        Id = 1,
        Project_Name = "create quotation pdf",
        Start_Date = new DateTime(2022, 3, 1),
        End_Date = new DateTime(2022, 3, 15),
    },
    new Project_Model
    {
        Id = 2,
        Project_Name = "develop mobile app",
        Start_Date = new DateTime(2022, 4, 1),
        End_Date = new DateTime(2022, 6, 30),
    },
    new Project_Model
    {
        Id = 3,
        Project_Name = "design website UI",
        Start_Date = new DateTime(2022, 5, 1),
        End_Date = new DateTime(2022, 5, 10),
    },
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
        public IActionResult Create(Project_Model model)
        {
            if(model.Id != null && model.Project_Name != null && model.Start_Date != null && model.End_Date != null)
            {
                Record_List.Add(new Project_Model()
                {
                    Id = model.Id,
                    Project_Name = model.Project_Name,
                    Start_Date = model.Start_Date,
                    End_Date = model.End_Date

                });
                var record = Record_List;
                return RedirectToAction("Index", record);

            }
            return View();

        }

        public IActionResult Edit(int id)
        {
            var project = Record_List.FirstOrDefault(e => e.Id == id);



            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project_Model model)
        {
            var project = Record_List.FirstOrDefault(e => e.Id == model.Id);

            if (project != null)
            {
                project.Project_Name = model.Project_Name;
                project.Start_Date = model.Start_Date;
                project.End_Date = model.End_Date;
            }

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
