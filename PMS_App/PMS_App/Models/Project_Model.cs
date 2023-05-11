using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Net.Cache;
using System.Security.Cryptography;
namespace PMS_App.Models
{
    public class Project_Model
    {
        private static int _nextId = 1;

        public Project_Model()
        {
            Id = _nextId;
            _nextId++;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Project_Name { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        [Required]
        public DateTime End_Date { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }
    }
}
