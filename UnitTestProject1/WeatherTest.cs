using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTestProject
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void MakeWeather_ForeCastNumOne_ReturnOvercast()
        {
            int forecastNum = 1;

            string forecastType;

            forecastType = forecastConditions[forecastNum];

            Assert.AreEqual(forecastType, "Overcast");
        }

        [TestMethod]
        public void MakeWeather_WeatherNumTwo_ReturnCloudy()
        {
            int weatherNum = 2;

            string weatherType;

            weatherType = weatherConditions[weatherNum];

            Assert.AreEqual(weatherType, "Cloudy");
        }

        [TestMethod]
        private void AssignForecast_Three_ReturnThreeIsNotEqualToFour()
        {
            int forecastNum;
            int weatherNum = 3;

            forecastNum = UserInterface.RandomNumber(weatherNum - 1, weatherNum + 1);
            if (forecastNum == 4)
            {
                forecastNum = 3;
            }
            else if (forecastNum == -1)
            {
                forecastNum = 0;
            }
            Assert.AreNotEqual(forecastNum, 4);
        }

        public string[] weatherConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
        public string[] forecastConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
    }
}
