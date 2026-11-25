using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FridgeDisplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo _repo;

        public AdminController(IAdminRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            Admin? admin = _repo.Login(request.UserName, request.Password);

            if (admin == null)
            {
                return Unauthorized("Forkert brugernavn eller adgangskode");
            }

            return Ok();
        }

        [HttpPut("password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            if (request.NewPassword.Length < 8)
            {
                return BadRequest("Den nye adgangskode skal være mindst 8 tegn");
            }

            bool changed = _repo.ChangePassword(request.UserName, request.OldPassword, request.NewPassword);

            if (!changed)
            {
                return Unauthorized("Forkert brugernavn eller adgangskode");
            }

            return NoContent();
        }
    }
}