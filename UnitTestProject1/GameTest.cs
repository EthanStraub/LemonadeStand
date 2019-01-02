using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTestProject
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void AskWeek_One_ReturnSeven()
        {

            int dayArrayMax = 0;

            string prompt = "1";
            if (prompt == "1")
            {          
                dayArrayMax = 7;
                UserInterface.NewLine();
            }
            else if (prompt == "2")
            {              
                dayArrayMax = 14;
                UserInterface.NewLine();
            }
            else if (prompt == "3")
            {
                dayArrayMax = 21;
                UserInterface.NewLine();
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            Assert.AreEqual(dayArrayMax, 7);
        }

        [TestMethod]
        public void AskWeek_Two_ReturnFourteen()
        {

            int dayArrayMax = 0;

            string prompt = "2";
            if (prompt == "1")
            {
                dayArrayMax = 7;
                UserInterface.NewLine();
            }
            else if (prompt == "2")
            {
                dayArrayMax = 14;
                UserInterface.NewLine();
            }
            else if (prompt == "3")
            {
                dayArrayMax = 21;
                UserInterface.NewLine();
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            Assert.AreEqual(dayArrayMax, 14);
        }

        [TestMethod]
        public void AskWeek_Three_ReturnTwentyOne()
        {

            int dayArrayMax = 0;

            string prompt = "3";
            if (prompt == "1")
            {
                dayArrayMax = 7;
                UserInterface.NewLine();
            }
            else if (prompt == "2")
            {
                dayArrayMax = 14;
                UserInterface.NewLine();
            }
            else if (prompt == "3")
            {
                dayArrayMax = 21;
                UserInterface.NewLine();
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
            Assert.AreEqual(dayArrayMax, 21);
        }

        [TestMethod]
        public void UseCups_String_ReturnFalseWhenAcceptingNonNumbers()
        {
            string CupsUsed = "hello world";

            int myInt;
            bool isNumerical = int.TryParse(CupsUsed, out myInt);

            Assert.IsFalse(isNumerical);
        }

        [TestMethod]
        public void UseCups_String_ReturnTrueWhenAcceptingNumbers()
        {
            string CupsUsed = "10";

            int myInt;
            bool isNumerical = int.TryParse(CupsUsed, out myInt);

            Assert.IsTrue(isNumerical);
        }

        [TestMethod]
        public void AskPrice_NegativeInteger_ReturnPriceAsInteger()
        {
            int PriceNum = 0;
            string PriceUsed = "-145";

            int myInt;
            bool isNumerical = int.TryParse(PriceUsed, out myInt);

            if (isNumerical)
            {
                PriceNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
            }

            Assert.AreEqual(PriceNum, -145);
        }

        [TestMethod]
        public void ApplyWeatherDesire_Sunny_DesireIsIncreased()
        {
            string CurrentWeather = "Sunny";
            int CustomerDesire = 0;

            if (CurrentWeather == "Sunny")
            {
                CustomerDesire += 10;
            }
            else if (CurrentWeather == "Overcast")
            {
                //do nothing
            }
            else if (CurrentWeather == "Cloudy")
            {
                CustomerDesire -= 5;
            }
            else if (CurrentWeather == "Rain")
            {
                CustomerDesire -= 10;
            }
            Assert.AreEqual(CustomerDesire, 10);
        }

        [TestMethod]
        public void ApplyWeatherDesire_Overcast_NoChangesToDesire()
        {
            string CurrentWeather = "Overcast";
            int CustomerDesire = 0;

            if (CurrentWeather == "Sunny")
            {
                CustomerDesire += 10;
            }
            else if (CurrentWeather == "Overcast")
            {
                //do nothing
            }
            else if (CurrentWeather == "Cloudy")
            {
                CustomerDesire -= 5;
            }
            else if (CurrentWeather == "Rain")
            {
                CustomerDesire -= 10;
            }
            Assert.AreEqual(CustomerDesire, 0);
        }

        [TestMethod]
        public void ApplyWeatherDesire_Cloudy_DesireDecreasedByFive()
        {
            string CurrentWeather = "Cloudy";
            int CustomerDesire = 0;

            if (CurrentWeather == "Sunny")
            {
                CustomerDesire += 10;
            }
            else if (CurrentWeather == "Overcast")
            {
                //do nothing
            }
            else if (CurrentWeather == "Cloudy")
            {
                CustomerDesire -= 5;
            }
            else if (CurrentWeather == "Rain")
            {
                CustomerDesire -= 10;
            }
            Assert.AreEqual(CustomerDesire, -5);
        }

        [TestMethod]
        public void ApplyWeatherDesire_Sunny_DesireDecreasedByten()
        {
            string CurrentWeather = "Rain";
            int CustomerDesire = 0;

            if (CurrentWeather == "Sunny")
            {
                CustomerDesire += 10;
            }
            else if (CurrentWeather == "Overcast")
            {
                //do nothing
            }
            else if (CurrentWeather == "Cloudy")
            {
                CustomerDesire -= 5;
            }
            else if (CurrentWeather == "Rain")
            {
                CustomerDesire -= 10;
            }
            Assert.AreEqual(CustomerDesire, -10);
        }

        [TestMethod]
        public void ApplyWalletDesire_OneHundrded_DecreaseDesireByFive()
        {
            int PriceNum = 100;
            int CustomerDesire = 0;

            if (PriceNum >= 70)
            {
                CustomerDesire -= 5;
            }
            else if (PriceNum <= 30)
            {
                CustomerDesire += 5;
            }

            Assert.AreEqual(CustomerDesire, -5);
        }

        [TestMethod]
        public void ApplyWalletDesire_NegativeTwenty_IncreaseDesireByFive()
        {
            int PriceNum = -20;
            int CustomerDesire = 0;

            if (PriceNum >= 70)
            {
                CustomerDesire -= 5;
            }
            else if (PriceNum <= 30)
            {
                CustomerDesire += 5;
            }

            Assert.AreEqual(CustomerDesire, 5);
        }

        [TestMethod]
        public void ApplyWalletDesire_Fifty_DoNothingToDesire()
        {
            int PriceNum = 50;
            int CustomerDesire = 0;

            if (PriceNum >= 70)
            {
                CustomerDesire -= 5;
            }
            else if (PriceNum <= 30)
            {
                CustomerDesire += 5;
            }

            Assert.AreEqual(CustomerDesire, 0);
        }
    }
}
