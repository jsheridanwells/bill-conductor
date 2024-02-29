using BillConductor.Application.HealthCheck.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillConductor.Api.Controllers.HealthCheck
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetHealthCheckController : ControllerBase
    {
        private readonly IGetHealthCheckQueryHandler _getHealthCheckQueryHandler;

        public GetHealthCheckController(IGetHealthCheckQueryHandler getHealthCheckQueryHandler)
        {
            _getHealthCheckQueryHandler = getHealthCheckQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealthCheck(Guid uid)
        {
            try
            {
                var healthCheck = await _getHealthCheckQueryHandler.HandleAsync(uid);
                if (healthCheck != null) 
                { 
                    return Ok(healthCheck);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}   
