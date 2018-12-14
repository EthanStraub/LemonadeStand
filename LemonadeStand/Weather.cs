using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        //Examples of encapsulation within this program are most notably found in the Weather class. 
        //Data such as the temperature, weather, and forecast are all placed within private member variables so that
        //The implementation of them can be done privately, and return a public data value for other functions within the game.

        //Certain methods are also made private and are called upon by a public method, 
        //namely 'makeWeather', showcasing an example of abstraction.
        
        public int weatherNum;
        public int forecastNum;

        private int temp;
        private string weatherType;
        private string forecast;
        
        public int Temp {  get { return temp; } set { temp = value; } }
        public string WeatherType {  get { return weatherType; } set { weatherType = value; } }
        public string Forecast {  get { return forecast; } set { forecast = value; } }

        public void MakeWeather()
        {
            AssignWeather();
            AssignForecast();

            forecast = forecastConditions[forecastNum];
            weatherType = weatherConditions[weatherNum];
        }
        
        private void AssignWeather()
        {
            weatherNum = UserInterface.RandomNumber(0, 4);
            temp = UserInterface.RandomNumber(50, 100);
        }

        private void AssignForecast()
        {
            forecastNum = UserInterface.RandomNumber(weatherNum-1, weatherNum+1);
            if (forecastNum == 4)
            {
                forecastNum = 3;
            }
            else if  (forecastNum == -1)
            {
                forecastNum = 0;
            }
        }
  
        public string[] weatherConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
        public string[] forecastConditions = { "Sunny", "Overcast", "Cloudy", "Rain" };
    }
}
