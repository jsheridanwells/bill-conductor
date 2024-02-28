using BillConductor.Api.Controllers.HealthCheck;
using BillConductor.Application.HealthCheck.Commands;
using BillConductor.Application.HealthCheck.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BillConductor.Tests.BillConductor.Api.Tests.Controllers.HealthCheck
{
    public class SendHealthCheckController_Tests
    {
        private Mock<ISendHealthCheckCommandHandler> _sendHealthCheckCommandHandlerMock;

        public SendHealthCheckController_Tests()
        {
            _sendHealthCheckCommandHandlerMock = new Mock<ISendHealthCheckCommandHandler>();
        }

        [Fact]
        public async Task InvokesSendHealthCheckCommand()
        {
            // Arrange
            var testDto = new HealthCheckDto { HealthCheckDate = DateTime.Now, Uid = Guid.NewGuid() };
            _sendHealthCheckCommandHandlerMock.Setup(h => h.HandleAsync(It.IsAny<SendHealthCheckCommand>()))
                .ReturnsAsync(testDto);
            var sut = new SendHealthCheckController(_sendHealthCheckCommandHandlerMock.Object);

            // Act
            var result = await sut.SendHealthCheck() as OkObjectResult;

            // Assert
            _sendHealthCheckCommandHandlerMock
                .Verify(h => h.HandleAsync(It.IsAny<SendHealthCheckCommand>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task ReturnsOkResult()
        {
            // Arrange
            var testDto = new HealthCheckDto { HealthCheckDate = DateTime.Now, Uid = Guid.NewGuid() };
            _sendHealthCheckCommandHandlerMock.Setup(h => h.HandleAsync(It.IsAny<SendHealthCheckCommand>()))
                .ReturnsAsync(testDto);
            var sut = new SendHealthCheckController(_sendHealthCheckCommandHandlerMock.Object);

            // Act
            var result = await sut.SendHealthCheck() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnsErrorResult()
        {
            // Arrange
            var testMsg = "oh noooos";
            _sendHealthCheckCommandHandlerMock.Setup(h => h.HandleAsync(It.IsAny<SendHealthCheckCommand>()))
                .ThrowsAsync(new Exception(testMsg));

            var sut = new SendHealthCheckController(_sendHealthCheckCommandHandlerMock.Object);

            // Act
            var result = await sut.SendHealthCheck() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.Equal(testMsg, result.Value);
        }

    }
}
