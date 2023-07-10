using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CG.Contas.API.Services.ContaService;
using CG.Contas.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CG.Contas.Test
{
    public class ContaControllerTest
    {
        [Fact]
        public async void GetAll_ReturnOkResult()
        {
            // Arr
            var _service = new Mock<IContaService>();
            _service.Setup(s => s.GetAll()).ReturnsAsync(ContaMockData.GetAll());
            var controller = new ContaController(_service.Object);

            // Act
            var okResult = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData("189ebae2-7e76-436d-a605-f8d31c9a6b1e")]
        [InlineData("cb095c30-7681-41c4-b9c8-9b0538aac416")]
        [InlineData("41de124c-c932-4d83-9d99-41c585b656d3")]
        public async void GetById_ReturnOkResult(string guid)
        {
            // Arrange
            Guid _guid = new Guid(guid);

            var _service = new Mock<IContaService>();
            _service.Setup(s => s.GetById(_guid)).ReturnsAsync(ContaMockData.GetById(_guid));
            var controller = new ContaController(_service.Object);

            // Act
            var okResult = (OkObjectResult)await controller.GetById(_guid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData("00000000-7e76-436d-a605-f8d31c9a6b1e")]
        [InlineData("cb095c30-cccc-41c4-b9c8-9b0538aac416")]
        [InlineData("41de124c-c932-bbbb-9d99-41c585b656d3")]
        public async void GetById_ReturnNotFoundResult(string guid)
        {
            // Arrange
            Guid _guid = new Guid(guid);

            var _service = new Mock<IContaService>();
            _service.Setup(s => s.GetById(_guid)).ReturnsAsync(ContaMockData.GetById(_guid));
            var controller = new ContaController(_service.Object);

            // Act
            var notFoundResult = (NotFoundObjectResult)await controller.GetById(_guid);

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}