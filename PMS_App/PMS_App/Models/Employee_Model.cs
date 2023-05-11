using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Net.Cache;
using System.Security.Cryptography;
namespace PMS_App.Models
{
    public class Employee_Model
    {
        private static int _nextId = 1;

        public Employee_Model()
        {
            Id = _nextId;
            _nextId++;
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        public string? Emp_Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string? User_Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string? User_Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        [StringLength(10)]
        public String? Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }

    }
}
