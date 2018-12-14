using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        public int dayNum = 0;
        public int time;

        private int currentTemp;
        private string currentForecast;
        private string currentWeather;

        public int CurrentTemp { get { return currentTemp; } set { currentTemp = value; } }
        public string CurrentForecast { get { return currentForecast; } set { currentForecast = value; } }
        public string CurrentWeather { get { return currentWeather; } set { currentWeather = value; } }

        private double initialWallet;
        public double InitialWallet { get { return initialWallet; } set { initialWallet = value; } }

        Weather dayWeather = new Weather();

        public void ApplyDayWeather()
        {
            dayWeather.makeWeather();
            currentForecast = dayWeather.Forecast;
            currentWeather = dayWeather.WeatherType;
            currentTemp = dayWeather.Temp;
        }
        
    }
}
