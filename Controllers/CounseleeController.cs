using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PASTORALISPROJECTNEW.Repository;

namespace PASTORALISPROJECTNEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounseleeController : ControllerBase
    {
        private readonly IPastorRepository _pastorrRepository;
        

        public CounseleeController()
        {
           
        }
        /*[HttpGet("GetAllavailablePastor")]
        public IActionResult GetAllavailablePastor()
        {
            List<Pastor> availablePastors = _counseleeRepository.GetAllAavailablePastors();
            return Ok(availablePastors);
        }*/


    }
}
