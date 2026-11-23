using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FridgeDisplay.Repositories;
using FridgeDisplay.Models;

namespace TestingGround.Repositories
{
    public class MeasurementRepoDBTests
    {
        [Fact]
        public void TestIfAddMeasurementReturnsMeasurement()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeasurementDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var context = new MeasurementDBContext(options))
            {
                var repository = new MeasurementRepoDB(context);
                var measurement = new Measurement
                {
                    Id = 1,
                    Value = 25.5,
                    Timestamp = DateTime.Now
                };
                // Act
                var result = repository.AddMeasurement(measurement);
                // Assert
                Assert.NotNull(result);
                Assert.Equal(measurement.Id, result.Id);
                Assert.Equal(measurement.Value, result.Value);
                Assert.Equal(measurement.Timestamp, result.Timestamp);
            }
        }
    }
}
