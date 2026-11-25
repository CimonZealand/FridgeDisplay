using FridgeDisplay.Controllers;
using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingGround.TestControllers
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetLatest_ReturnsNewestMeasurement()
        {
            var repository = new MeasurementsRepoList();
            repository.AddMeasurement(new Measurement { Temperature = 4.2 });
            repository.AddMeasurement(new Measurement { Temperature = 6.1 });
            var controller = new MeasurementsController(repository);

            var result = Assert.IsType<OkObjectResult>(
                controller.GetLatest().Result);
            var measurement = Assert.IsType<Measurement>(result.Value);

            Assert.Equal(6.1, measurement.Temperature);
        }

        [Fact]
        public void TestGetLatestMeasurement_ReturnsNull_WhenNoMeasurementsExist()
        {
            // Arrange
            var repository = new MeasurementsRepoList(includesTestData: false);
            var controller = new MeasurementsController(repository);
            // Act
            var result = controller.GetLatest();
            // Assert
            Assert.Null(result);
        }
    }
}
