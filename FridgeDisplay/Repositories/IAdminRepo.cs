using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public interface IAdminRepo
    {
        public Admin? Login(string userName, string password);
        public bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
