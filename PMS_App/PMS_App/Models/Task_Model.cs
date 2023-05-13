using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PMS_App.Models
{
    public class Task_Model
    {
        private static int _nextId = 1;

        public Task_Model()
        {
            _EmployeesList = new List<Employee_Model>();
            _ProjectsList = new List<Project_Model>();
            Id = _nextId;
            _nextId++;
        }
        [Key]
        public int Id { get; set; }
        public string? Task_Name { get; set; }
        public string? Task_Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }

        public int Employee_Id { get; set; }
        public List<Employee_Model> _EmployeesList { get; set; }

        public int Project_Id { get; set; }
        public List<Project_Model> _ProjectsList { get; set; }

       
        
    }
}
