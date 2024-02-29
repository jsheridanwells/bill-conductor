using BillConductor.Application.HealthCheck.Models;

namespace BillConductor.Application.HealthCheck.Queries
{
    public interface IGetHealthCheckQueryHandler
    {
        Task<HealthCheckDto> HandleAsync(Guid uid);
    }

    public record GetHealthCheckQuery(Guid uid);

    public class GetHealthCheckQueryHandler : IGetHealthCheckQueryHandler
    {
        public async Task<HealthCheckDto> HandleAsync(Guid uid)
        {
            return await Task.Run(() =>
            {
                return new HealthCheckDto
                {
                    HealthCheckDate = DateTime.Now,
                    Uid = uid
                };
            });
        }
    }

}
