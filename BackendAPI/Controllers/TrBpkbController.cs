using BackendAPI.Data;
using BackendAPI.DTOs;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrBpkbController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrBpkbController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public IActionResult InsertBpkb([FromBody] TrBpkbDto data)
        {
            var locationExists = _context.MsStorageLocations.Any(x => x.LocationId == data.LocationId);
            if (!locationExists)
            {
                return BadRequest("Invalid storage location.");
            }

            var newBpkb = new TrBpkb
            {
                AgreementNumber = data.AgreementNumber,
                BpkbNo = data.BpkbNo,
                BranchId = data.BranchId,
                BpkbDate = data.BpkbDate,
                FakturNo = data.FakturNo,
                FakturDate = data.FakturDate,
                LocationId = data.LocationId,
                PoliceNo = data.PoliceNo,
                BpkbDateIn = data.BpkbDateIn,
                CreatedBy = data.Username, 
                CreatedOn = DateTime.Now,
                LastUpdatedBy = data.Username,
                LastUpdatedOn = DateTime.Now
            };

            _context.TrBpkbs.Add(newBpkb);
            _context.SaveChanges();

            return Ok("Data successfully saved.");
        }

    }
}
