using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandSecondaryTest
{
    [TestClass]
    public class GameTest
    {
        public CustomerTest[] customerArray;
        
        [TestMethod]
        public void SetUpCustomers()
        {
            totalBought = 0;
            customerArray = new CustomerTest[1];
            UserInterface.NewLine();
            for (int i = 0; i < 100; i++)
            {
                if (HasSoldOut() == true)
                {
                    continue;
                }
                else
                {
                    Customer newCustomer = new Customer();
                    customerArray[i] = newCustomer;
                    ApplyWeatherDesire();
                }

            }
            SoldOutText();
            ResetItems();
        }

        [TestMethod]
        public void ApplyWeatherDesire()
        {
            if (dayArray[currentDayIndex].CurrentWeather == "Sunny")
            {
                cust.CustomerDesire += 10;
            }
            else if (dayArray[currentDayIndex].CurrentWeather == "Overcast")
            {
                //do nothing
            }
            else if (dayArray[currentDayIndex].CurrentWeather == "Cloudy")
            {
                cust.CustomerDesire -= 5;
            }
            else if (dayArray[currentDayIndex].CurrentWeather == "Rain")
            {
                cust.CustomerDesire -= 10;
            }
        }
    }
}
