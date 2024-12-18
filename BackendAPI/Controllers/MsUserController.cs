using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MsUserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] MsUser user)
        {
            var result = _context.MsUsers
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive);

            if (result == null)
                return Unauthorized("Username atau Password salah");

            return Ok(result);
        }
    }
}
