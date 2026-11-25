using FridgeAid.Api.Data;
using FridgeDisplay.Models;
using Microsoft.AspNetCore.Identity;

namespace FridgeDisplay.Repositories
{
    public class AdminRepoDB : IAdminRepo
    {
        private readonly FridgeAidDbContext _context;
        private readonly PasswordHasher<Admin> _hasher = new PasswordHasher<Admin>();

        public AdminRepoDB(FridgeAidDbContext context)
        {
            _context = context;
        }

        public Admin? Login(string userName, string password)
        {
            Admin? admin = _context.Admins.FirstOrDefault(a => a.UserName == userName);

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
            _context.SaveChanges();
            return true;
        }
    }
}