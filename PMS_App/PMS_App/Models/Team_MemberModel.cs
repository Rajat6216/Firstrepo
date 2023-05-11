namespace PMS_App.Models
{
    public class Team_MemberModel
    {
        public int Id { get; set; }
        public int Emp_Id { get; set; }
        public int Team_Id { get; set; } 
        public int Role_Id { get; set; } 
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }
    }
}
