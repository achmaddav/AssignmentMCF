using BackendAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MsStorageLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MsStorageLocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetStorageLocations")]
        public IActionResult GetStorageLocations()
        {
            var locations = _context.MsStorageLocations.ToList();
            return Ok(locations);
        }
    }

}
