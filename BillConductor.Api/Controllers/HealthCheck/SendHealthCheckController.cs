using BillConductor.Application.HealthCheck.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillConductor.Api.Controllers.HealthCheck
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendHealthCheckController : ControllerBase
    {
        private readonly ISendHealthCheckCommandHandler _sendHealthCheckCommandHandler;

        public SendHealthCheckController(ISendHealthCheckCommandHandler sendHealthCheckCommandHandler)
        {
            _sendHealthCheckCommandHandler = sendHealthCheckCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SendHealthCheck()
        {
            try
            {
                var result = await _sendHealthCheckCommandHandler.HandleAsync(new SendHealthCheckCommand(DateTime.Now));
                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
