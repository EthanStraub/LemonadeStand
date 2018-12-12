using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {

        public int temp;
        public int weatherNum;
        public int forecastNum;
        public string weather;
        public string forecast;
        

        

        public void makeWeather()
        {
            assignWeather();
            assignForecast();

            forecast = forecastConditions[forecastNum];
            weather = weatherConditions[weatherNum];
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
