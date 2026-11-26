using System;
using System.Collections.Generic;
using System.Text;

namespace TestingGround.TestControllers
{
    public class IntervalControllerTest
    {
        [Fact]
        public void TestNewInterval_ExpectDefaultValues()
        {
           //Arrange
            var interval = new FridgeDisplay.Models.Interval();

            //Act
            double minTemp = interval.MinTemperature;
            double maxTemp = interval.MaxTemperature;
            double minHumidity = interval.MinHumidity;
            double maxHumidity = interval.MaxHumidity;

            //Assert
            Assert.Equal(3.0, minTemp);
            Assert.Equal(5.0, maxTemp);
            Assert.Equal(60.0, minHumidity);
            Assert.Equal(80.0, maxHumidity);
        }
    }
}
