namespace SmartTeapotsWebProject.Data.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public int RoleId { set; get; }
        public virtual Role Role { set; get; }

        public virtual List<Order> Orders { set; get; } = new();
    }
}