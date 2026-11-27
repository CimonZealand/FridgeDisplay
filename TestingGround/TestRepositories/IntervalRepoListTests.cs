using FridgeDisplay.Models;
using FridgeDisplay.Repositories;

namespace TestingGround.TestRepositories
{
    public class IntervalRepoListTests
    {
        private readonly IIntervalRepo _repo;

        public IntervalRepoListTests()
        {
            _repo = new IntervalRepoList();
        }

        [Fact]
        public void GetInterval_WhenNothingIsSaved_ReturnsDefaultValues()
        {
            // Act
            Interval result = _repo.GetInterval();

            // Assert
            Assert.Equal(3.0, result.MinTemperature);
            Assert.Equal(5.0, result.MaxTemperature);
            Assert.Equal(60.0, result.MinHumidity);
            Assert.Equal(80.0, result.MaxHumidity);
        }

        [Fact]
        public void UpdateInterval_SavesNewValues()
        {
            // Arrange
            Interval newInterval = new Interval
            {
                MinTemperature = 2.0,
                MaxTemperature = 6.0,
                MinHumidity = 50.0,
                MaxHumidity = 70.0
            };

            // Act
            _repo.UpdateInterval(newInterval);
            Interval result = _repo.GetInterval();

            // Assert
            Assert.Equal(2.0, result.MinTemperature);
            Assert.Equal(6.0, result.MaxTemperature);
            Assert.Equal(50.0, result.MinHumidity);
            Assert.Equal(70.0, result.MaxHumidity);
        }

        [Fact]
        public void UpdateInterval_MinTemperatureGreaterThanMax_ThrowsArgumentException()
        {
            // Arrange
            Interval invalid = new Interval { MinTemperature = 8.0, MaxTemperature = 4.0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _repo.UpdateInterval(invalid));
        }

        [Fact]
        public void UpdateInterval_MinHumidityGreaterThanMax_ThrowsArgumentException()
        {
            // Arrange
            Interval invalid = new Interval { MinHumidity = 90.0, MaxHumidity = 70.0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _repo.UpdateInterval(invalid));
        }

        [Fact]
        public void UpdateInterval_InvalidValues_KeepsOldValues()
        {
            // Arrange
            Interval invalid = new Interval { MinHumidity = 90.0, MaxHumidity = 70.0 };

            // Act
            try { _repo.UpdateInterval(invalid); } catch (ArgumentException) { }
            Interval result = _repo.GetInterval();

            // Assert: de gamle (default) værdier er uændrede
            Assert.Equal(60.0, result.MinHumidity);
            Assert.Equal(80.0, result.MaxHumidity);
        }

        [Fact]
        public void ResetInterval_ReturnsDefaultValuesAfterUpdate()
        {
            // Arrange
            _repo.UpdateInterval(new Interval { MinHumidity = 40.0, MaxHumidity = 50.0 });

            // Act
            Interval result = _repo.ResetInterval();

            // Assert
            Assert.Equal(60.0, result.MinHumidity);
            Assert.Equal(80.0, result.MaxHumidity);
        }
    }
}