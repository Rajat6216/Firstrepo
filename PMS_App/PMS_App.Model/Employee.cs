namespace PMS_App.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Emp_Name { get; set; }
        public string UserName { get; set; }
        public string User_Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int Created_By { get; set; }

        public DateTime? Created_On { get; set; }

        public int Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }



    }
}