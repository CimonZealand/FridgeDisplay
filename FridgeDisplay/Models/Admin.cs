namespace FridgeDisplay.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }

    }
}
