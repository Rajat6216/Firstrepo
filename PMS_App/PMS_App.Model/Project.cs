using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_App.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Project_Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int Created_By { get; set; }

        public DateTime? Created_On { get; set; }

        public int Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }



    }
}