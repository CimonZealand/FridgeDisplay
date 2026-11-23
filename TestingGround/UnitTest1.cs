using System;
using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
namespace TestingGround
{
    public class UnitTest1
    {

        private readonly IMeasurementRepository _repo;
        public UnitTest1()
        {
            _repo = new MeasurementsRepoList();
        }

        [Fact]
        public void AddMeasurement_AssignsIdsToMeasurements()
        {
            //Arrange
            var testMeasurement1 = new Measurement { Temperature = 20.5, Humidity = 50, DoorClosed = true };
            var testMeasurement2 = new Measurement { Temperature = 22.0, Humidity = 55, DoorClosed = false };

            //Act
            var result1 = _repo.AddMeasurement(testMeasurement1);
            var result2 = _repo.AddMeasurement(testMeasurement2);

            //Assert
            Assert.Equal(1, result1.Id);
            Assert.Equal(2, result2.Id);
        }
    }
}
