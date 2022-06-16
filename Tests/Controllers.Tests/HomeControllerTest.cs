using DemoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.Controllers.Tests
{
    public class HomeControllerTest
    {
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController();
        }

        [Fact]
        public void GetAllProduct_WithSuccess()
        {
            var response = _controller.Index();

            Assert.IsType<OkObjectResult>(response);
        }

    }
}