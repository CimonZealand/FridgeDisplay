using Microsoft.EntityFrameworkCore;
using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
using FridgeAid.Api.Data;

namespace TestingGround.Repositories
{
    public class MeasurementRepoDBTests
    {
        private readonly FridgeAidDbContext _context;
        private readonly MeasurementRepoDB _repository;
        public MeasurementRepoDBTests()
        {
            var options = new DbContextOptionsBuilder<FridgeAidDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new FridgeAidDbContext(options);
            _repository = new MeasurementRepoDB(_context);
        }

        [Fact]
        public void TestIfAddMeasurementReturnsMeasurement()
        {
            // Arrange
            var measurement = new Measurement
            {
                Id = 1,
                Temperature = 25.5
            };
            // Act
            var result = _repository.AddMeasurement(measurement);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(measurement.Temperature, result.Temperature);

            var saved = _context.Measurements.Find(measurement.Id);
            Assert.NotNull(saved);
        }
    }
}