namespace user_management.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public byte Password { get; set; }
        public bool Root { get; set; }
        public DateTime LastOnline { get; set; }
    }
}
