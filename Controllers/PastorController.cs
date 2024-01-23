using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PASTORALISPROJECTNEW.Models;
using PASTORALISPROJECTNEW.Repository;
using PASTORALISPROJECTNEW.RequestModels;


namespace PASTORALISPROJECTNEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PastorController : ControllerBase
    {
        private readonly IPastorRepository _pastorrepo;
        private readonly ITokenService _tokenService;

        public PastorController(IPastorRepository pastorrepo, ITokenService tokenService)
        {
            this._pastorrepo = pastorrepo;
            this._tokenService = tokenService;
        }

        
        [HttpGet("Get-All-Pastor")]
        public IActionResult GetAllPastor()
        {
           var pastors = _pastorrepo.GetAllPastors();
           return Ok(pastors);
        }

        [HttpGet("Get-All-Slots-Of-A-Pastor/{id}")]
        public IEnumerable<Slot> GetAllPastorslots(int id)
        {
            IEnumerable<Slot> slots = _pastorrepo.GetAllAvailableSlotsOfAParticularPastorById(id);
            return slots;
        }

        [HttpGet("GetPastorById/{id}")]
        public Pastor GetPastorById(int id)
        {
            var pastor = _pastorrepo.GetPastorById(id);
            return pastor;
        }
        [HttpPost("SetSlotDuration/{pastorId}")]
        public IActionResult SetDurationForSlotByPastorId(int pastorId, int duration)
        {
            string result = _pastorrepo.SetDurationForSlotByPastorId(pastorId, duration);
            if (result == $"pastor for {pastorId} not found")
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("SetAvailabilityForSlots/{pastorId}")]
        public IActionResult SetAvailabilityForSlots(int pastorId, DateOnly date , string starttime, string endtime, bool isAvailable)
        {
            var result = _pastorrepo.SetAvailbilityForSlotsByPastorId(pastorId,date,starttime,endtime,isAvailable);

            return Ok(result); 
        }

        [HttpPost("ChangePasswordOfPastor/{pastorId}")]
        public IActionResult ChangePassword(int pastorId,ChangePassword passmodel)
        {
            var result = _pastorrepo.ChnagePasswordForPastor(pastorId,passmodel);

            return Ok(result);
        }



    }
}
