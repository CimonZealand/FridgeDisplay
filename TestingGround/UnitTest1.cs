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

        //Grundet YAGNY har vi ingen GetAll metode til measurements; Vi skal kun kunne se den seneste. 
        //Nedenstående test benytter derfor Add-metoden til at tilføje et measurement og tjekker om id'et er korrekt auto incrementeret. Hvis ID = 4, kan vi konkludere, at testdata er inkluderet i constructoren,
        //uden vi beøver en GetAll metode for at tjekke om testdata er inkluderet. 
       

        [Fact]
        public void MeasurementsRepoList_WithTestData_AssignsNextIdAfterSeedData()
        {
            // Arrange
            var repository = new MeasurementsRepoList(includesTestData: true);
            var measurement = new Measurement
            {
                Temperature = 20.5,
                Humidity = 50,
                DoorClosed = true
            };

            // Act
            var result = repository.AddMeasurement(measurement);

            // Assert
            Assert.Equal(4, result.Id);

        }

        [Fact]
        public void MeasurementsRepoList_WithoutTestData_StartsIdsAtOne()
        {
            // Arrange
            var repository = new MeasurementsRepoList();
            var measurement = new Measurement
            {
                Temperature = 20.5,
                Humidity = 50,
                DoorClosed = true
            };

            // Act
            var result = repository.AddMeasurement(measurement);

            // Assert
            Assert.Equal(1, result.Id);
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

        [Fact]

        public void AddMeasurement_ReturnsAddedMeasurement()
        {
            //Arrange
            var testMeasurement = new Measurement { Temperature = 20.5, Humidity = 50, DoorClosed = true };
            //Act
            var result = _repo.AddMeasurement(testMeasurement);
            //Assert
            Assert.Equal(testMeasurement.Temperature, result.Temperature);
            Assert.Equal(testMeasurement.Humidity, result.Humidity);
            Assert.Equal(testMeasurement.DoorClosed, result.DoorClosed);
        }

        [Fact]
        public void GetLatest_ReturnsMostRecentMeasurement()
        {
            //Arrange
            var measurement1 = new Measurement { Temperature = 20.5, Humidity = 50, DoorClosed = true };
            var measurement2 = new Measurement { Temperature = 22.0, Humidity = 55, DoorClosed = false };
            _repo.AddMeasurement(measurement1);
            _repo.AddMeasurement(measurement2);
            //Act
            var result = _repo.GetLatest();
            //Assert
            Assert.Equal(measurement2.Temperature, result.Temperature);
            Assert.Equal(measurement2.Humidity, result.Humidity);
            Assert.Equal(measurement2.DoorClosed, result.DoorClosed);
        }


        [Fact]
        public void GetLatest_ReturnsNullWhenNoMeasurements()
        {
            //Arrange
            var emptyRepo = new MeasurementsRepoList();
            //Act
            var result = emptyRepo.GetLatest();
            //Assert
            Assert.Null(result);
        }
    }
}
