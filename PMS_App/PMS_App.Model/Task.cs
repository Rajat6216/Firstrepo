using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_App.Model
{
    public class Task
    {
       
        public int Id { get; set; }
        public string? Task_Name { get; set; }
        public string? Task_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public int Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public int Updated_By { get; set; }

        public int Employee_Id { get; set; }
     
        public int Project_Id { get; set; }

     }
}
