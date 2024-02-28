using BillConductor.Application.HealthCheck.Models;

namespace BillConductor.Application.HealthCheck.Commands
{
    public interface ISendHealthCheckCommandHandler
    {
        Task<HealthCheckDto> HandleAsync(SendHealthCheckCommand request);
    }

    public record SendHealthCheckCommand(DateTime date);

    public class SendHealthCheckCommandHandler : ISendHealthCheckCommandHandler
    {
        public async Task<HealthCheckDto> HandleAsync(SendHealthCheckCommand request)
        {
            return await Task.Run(() =>
            {
                return new HealthCheckDto
                {
                    HealthCheckDate = request.date,
                    Uid = Guid.NewGuid()
                };
            });
        }
    }
}
