namespace PMS_App.Models
{
    public class Ticket_Model
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public int Task_Id { get; set; }
        public int Emp_Id { get; set; }
        public int _Hours { get; set; }
        public string? Ticket_Description { get; set; }
        public DateTime Date_Time { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string? Updated_By { get; set; }
    }
}
