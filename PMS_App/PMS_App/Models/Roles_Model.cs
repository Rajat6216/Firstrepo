namespace PMS_App.Models
{
    public class Roles_Model
    {
        public int Id { get; set; }
        public string? Role_Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }
    }
}
