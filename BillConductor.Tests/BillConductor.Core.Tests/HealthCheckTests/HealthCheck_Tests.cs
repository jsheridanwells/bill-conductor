using BillConductor.Core.HealthCheck;

namespace BillConductor.Tests.BillConductor.Core.Tests.HealthCheckTests
{
    public class HealthCheck_Tests
    {
        [Fact]
        public void CreatesHealthCheckObject()
        {
            // Arrange
            var uid = new Uid { Value = Guid.NewGuid() };
            var healthCheckDate = new HealthCheckDate { Value = DateTime.Now.AddDays(-1) };

            // Assert
            var result = HealthCheck.Create(uid, healthCheckDate);

            // Act
            Assert.NotNull(result);
            Assert.IsType<HealthCheck>(result);
            Assert.Equal(uid, result.Uid);
            Assert.Equal(healthCheckDate, result.HealthCheckDate);
        }

        [Fact]
        public void ThrowsExceptionForInvalidHealthCheckDate() 
        {
            // Arrange
            var uid = new Uid { Value = Guid.NewGuid() };
            var healthCheckDate = new HealthCheckDate { Value = DateTime.Now.AddDays(10) };

            // Act
            Assert.Throws<ArgumentException>(() =>
            {
                var result = HealthCheck.Create(uid, healthCheckDate);
            });
        }
    }
}
