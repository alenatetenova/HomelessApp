
    using System;
    using System.Collections.Generic;
    using Homeless.Authorization.Attributes;
    using Homeless.Controllers;
    using Homeless.Database.Models;
    using Homeless.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    namespace Homeless.Tests.Controllers
    {
        public class HelpPointControllerTests
        {
            private readonly Mock<IHelpPointRepository> _mockRepository;
            private readonly HelpPointController _controller;

            public HelpPointControllerTests()
            {
                _mockRepository = new Mock<IHelpPointRepository>();
                _controller = new HelpPointController(_mockRepository.Object);
            }

           
            [Fact]
            public void Post_ReturnsOkObjectResult_WithNewHelpPoint()
            {
                // Arrange
                var newHelpPoint = new HelpPointModel();
                _mockRepository.Setup(repo => repo.Add(It.IsAny<HelpPointModel>())).Returns(newHelpPoint);

                // Act
                var result = _controller.Post(newHelpPoint);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<HelpPointModel>(okResult.Value);
                Assert.Equal(newHelpPoint, model);
            }

            [Fact]
            public void Post_ReturnsStatusCode500InternalServerError_WhenExceptionThrown()
            {
                // Arrange
                _mockRepository.Setup(repo => repo.Add(It.IsAny<HelpPointModel>())).Throws<Exception>();

                // Act
                var result = _controller.Post(new HelpPointModel());

                // Assert
                Assert.IsType<ObjectResult>(result);
                var statusCodeResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            }

            [Fact]
            public void Delete_ReturnsOkResult()
            {
                // Arrange
                var id = Guid.NewGuid();

                // Act
                var result = _controller.Delete(id);

                // Assert
                Assert.IsType<OkResult>(result);
            }

            [Fact]
            public void Delete_ReturnsStatusCode500InternalServerError_WhenExceptionThrown()
            {
                // Arrange
                var id = Guid.NewGuid();
                _mockRepository.Setup(repo => repo.Delete(id)).Throws<Exception>();

                // Act
                var result = _controller.Delete(id);

                // Assert
                Assert.IsType<ObjectResult>(result);
                var statusCodeResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            }
        }
    
}
