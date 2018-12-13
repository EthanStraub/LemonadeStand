using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        
        public int weatherNum;
        public int forecastNum;

        private int temp;
        private string weatherType;
        private string forecast;
        
        public int Temp {  get { return temp; } set { temp = value; } }
        public string WeatherType {  get { return weatherType; } set { weatherType = value; } }
        public string Forecast {  get { return forecast; } set { forecast = value; } }

        public void makeWeather()
        {
            assignWeather();
            assignForecast();

            forecast = forecastConditions[forecastNum];
            weatherType = weatherConditions[weatherNum];
        }
        
        public void assignWeather()
        {
            weatherNum = UserInterface.RandomNumber(0, 4);
            temp = UserInterface.RandomNumber(50, 100);
        }

        public void assignForecast()
        {
            forecastNum = UserInterface.RandomNumber(weatherNum, 1+weatherNum);
            if (forecastNum == 5)
            {
                forecastNum = 4;
            }
        }

        
        public string[] weatherConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
        public string[] forecastConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
    }
}
