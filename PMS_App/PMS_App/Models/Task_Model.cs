using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PMS_App.Models
{
    public class Task_Model
    {
     
        public int Id { get; set; }
        public string? Task_Name { get; set; }
        public string? Task_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public int? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public int? Updated_By { get; set; }

        public int Employee_Id { get; set; }
        public List<Employee_Model>? _EmployeesList { get; set; }

        public int Project_Id { get; set; }
        public List<Project_Model>? _ProjectsList { get; set; }

        public string? Emp_Name { get; set; }
        public string? Project_Name { get; set; }



    }
}
