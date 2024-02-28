using BillConductor.Application.HealthCheck.Commands;

namespace BillConductor.Tests.BillConductor.Application.Tests.HealthCheck.Commands
{
    public class SendHealthCheckCommand_Tests
    {
        [Fact]
        public async Task ReturnsExpectedDate()
        {
            // Arrange
            var testDate = DateTime.Now;
            var command = new SendHealthCheckCommand(testDate);

            // Act
            var result = await new SendHealthCheckCommandHandler().HandleAsync(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testDate, result.HealthCheckDate);
        }
    }
}
