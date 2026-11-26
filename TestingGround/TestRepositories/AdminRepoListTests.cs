using FridgeDisplay.Models;
using FridgeDisplay.Repositories;

namespace TestingGround
{
    public class AdminRepoListTests
    {
        private readonly IAdminRepo _repo;

        public AdminRepoListTests()
        {
            _repo = new AdminRepoList(includesTestData: true);
        }

        [Fact]
        public void Login_WithCorrectPassword_ReturnsAdmin()
        {
            Admin? result = _repo.Login("admin", "Test1234!");

            Assert.NotNull(result);
        }

        [Fact]
        public void Login_WithWrongPassword_ReturnsNull()
        {
            Admin? result = _repo.Login("admin", "ForkertPassword");

            Assert.Null(result);
        }

        [Fact]
        public void ChangePassword_OnlyNewPasswordWorksAfterwards()
        {
            bool changed = _repo.ChangePassword("admin", "Test1234!", "NytPassword123");

            Assert.True(changed);
            Assert.Null(_repo.Login("admin", "Test1234!"));
            Assert.NotNull(_repo.Login("admin", "NytPassword123"));
        }

        [Fact]
        public void ChangePassword_WithWrongOldPassword_ReturnsFalse()
        {
            bool changed = _repo.ChangePassword("admin", "ForkertPassword", "NytPassword123");

            Assert.False(changed);
        }
    }
}