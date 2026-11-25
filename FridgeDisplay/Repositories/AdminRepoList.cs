using FridgeDisplay.Models;
using Microsoft.AspNetCore.Identity;

namespace FridgeDisplay.Repositories
{
    public class AdminRepoList : 
    {
        private readonly List<Admin> _admins = new List<Admin>();
        private readonly PasswordHasher<Admin> _hasher = new PasswordHasher<Admin>();

        public AdminRepoList(bool includesTestData = false)
        {
            if (includesTestData == true)
            {
                // Testdata: kun til tests, aldrig et rigtigt password
                Admin admin = new Admin { Id = 1, UserName = "admin" };
                admin.PasswordHash = _hasher.HashPassword(admin, "Test1234!");
                _admins.Add(admin);
            }
        }

        public Admin? Login(string userName, string password)
        {
            Admin? admin = _admins.FirstOrDefault(a => a.UserName == userName);

            if (admin == null || admin.PasswordHash == null)
            {
                return null;
            }

            PasswordVerificationResult result =
                _hasher.VerifyHashedPassword(admin, admin.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return admin;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            Admin? admin = Login(userName, oldPassword);

            if (admin == null)
            {
                return false;
            }

            admin.PasswordHash = _hasher.HashPassword(admin, newPassword);
            return true;
        }
    }
}