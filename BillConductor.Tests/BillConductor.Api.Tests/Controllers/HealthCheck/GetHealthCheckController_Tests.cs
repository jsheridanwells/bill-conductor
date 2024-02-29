using BillConductor.Api.Controllers.HealthCheck;
using BillConductor.Application.HealthCheck.Models;
using BillConductor.Application.HealthCheck.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BillConductor.Tests.BillConductor.Api.Tests.Controllers.HealthCheck
{
    public class GetHealthCheckController_Tests
    {
        private readonly Mock<IGetHealthCheckQueryHandler> _getHealthCheckQueryHandlerMock;

        public GetHealthCheckController_Tests()
        {
            _getHealthCheckQueryHandlerMock = new Mock<IGetHealthCheckQueryHandler>();
        }

        [Fact]
        public async Task InvokesGetHealthCheckQuery()
        {
            // Arrange
            _getHealthCheckQueryHandlerMock.Setup(h => h.HandleAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new HealthCheckDto());
            var sut = new GetHealthCheckController(_getHealthCheckQueryHandlerMock.Object);

            // Act
            var result = await sut.GetHealthCheck(Guid.NewGuid());

            // Assert
            _getHealthCheckQueryHandlerMock
                .Verify(h => h.HandleAsync(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task ReturnsOkResult()
        {
            // Arrange
            _getHealthCheckQueryHandlerMock.Setup(h => h.HandleAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new HealthCheckDto());
            var sut = new GetHealthCheckController(_getHealthCheckQueryHandlerMock.Object);

            // Act
            var result = await sut.GetHealthCheck(Guid.NewGuid()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnsErrorResult()
        {
            // Arrange
            var testMsg = "situation normal...";
            _getHealthCheckQueryHandlerMock.Setup(h => h.HandleAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception(testMsg));
            var sut = new GetHealthCheckController(_getHealthCheckQueryHandlerMock.Object);

            // Act
            var result = await sut.GetHealthCheck(Guid.NewGuid()) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.Equal(testMsg, result.Value);
        }

        [Fact]
        public async Task ReturnsNotFoundResult()
        {
            // Arrange
            _getHealthCheckQueryHandlerMock.Setup(h => h.HandleAsync(It.IsAny<Guid>()))
                .ReturnsAsync((HealthCheckDto?)null!);
            var sut = new GetHealthCheckController(_getHealthCheckQueryHandlerMock.Object);

            // Act
            var result = await sut.GetHealthCheck(Guid.NewGuid()) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
