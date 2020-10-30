using CoreSight2.Data;
using CoreSight2.Data.Entities;
using CoreSight2.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace CoreSightTests.ControllerTests
{

    public class HomeControllerTests
    {
        private readonly Mock<ICoreSightRepository> _mockRepo;
        private readonly HomeController _sut;
        private readonly Mock<ILogger<HomeController>> _logger;

        public HomeControllerTests()
        {
            
            _mockRepo = new Mock<ICoreSightRepository>();
            _logger = new Mock<ILogger<HomeController>>();
            _sut = new HomeController(_logger.Object, _mockRepo.Object);
        }
        [Fact]
        public void ReturnViewForIndex()
        {
            IActionResult result = _sut.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ReturnViewForChart()
        {
            var reading = new Readings()
            {
                Id = 3,
                Temp1 = 85.5M,
                Temp2 = 85.4M,
                Temp3 = 85.3M,
                Temp4 = 85.5M,
                Hum1 = 45.5M,
                Hum2 = 45.6M,
                Hum3 = 45.3M,
                Hum4 = 45.3M,
                Date = new DateTime(2020, 01, 12)
            };

            var result = _sut.Chart();
        }
    }
}
