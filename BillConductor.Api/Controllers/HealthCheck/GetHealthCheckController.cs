using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillConductor.Api.Controllers.HealthCheck
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetHealthCheckController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHealthCheck()
        {
            return Ok("updates");
        }
    }
}
