using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player Player1;        
        Store GameStore = new Store();
        Inventory PlayerInv = new Inventory();

        public Day[] dayArray;
        public Customer[] customerArray;

        public int totalBought;
        public int currentDayIndex = 0;
        public int dayArrayMax = 0;

        public void Introduction()
        {
            UserInterface.NewLine();
            Console.WriteLine(" --  Lemonade Stand! -- ");
            UserInterface.NewLine();
        }

        public void AskWeek()
        {
            Console.WriteLine("How many weeks would you like to run the stand for?");
            Console.WriteLine("Options: '1' for one week, '2' for two weeks, and '3' for three weeks.");

            string prompt = Console.ReadLine();
            if (prompt == "1")
            {
                dayArray = new Day[7];
                dayArrayMax = 7;
                UserInterface.NewLine();
            }
            else if (prompt == "2")
            {
                dayArray = new Day[14];
                dayArrayMax = 14;
                UserInterface.NewLine();
            }
            else if (prompt == "3")
            {
                dayArray = new Day[21];
                dayArrayMax = 21;
                UserInterface.NewLine();
            }
            else
            {
                Console.WriteLine("Please try again.");
                AskWeek();
                UserInterface.NewLine();
            }
        }

        public void AddDays()
        {
            for (int i = 0; i < dayArray.Length; i++)
            {
                Day newDay = new Day();
                dayArray[i] = newDay;
                dayArray[i].dayNum = i+1;
            }
        }

        public void NextDay()
        {
            currentDayIndex += 1;
        }

        public void SetUpPlayers()
        {
            Player1 = new Player();
        }

        public void SetUpCustomers()
        {
            totalBought = 0;
            customerArray = new Customer[100];
            for (int i = 0; i < 100; i++)
            {
                Customer newCustomer = new Customer();
                customerArray[i] = newCustomer;
                ApplyTotalDesire(customerArray[i]);
            }
        }

        public void ApplyTempDesire(Customer cust)
        {
            if (dayArray[currentDayIndex].CurrentTemp >= 50 && dayArray[currentDayIndex].CurrentTemp < 70)
            {
                cust.SetDesire(50, 91);
            }
            else if (dayArray[currentDayIndex].CurrentTemp >= 70 && dayArray[currentDayIndex].CurrentTemp < 90)
            {
                cust.SetDesire(55, 96);
            }
            else if (dayArray[currentDayIndex].CurrentTemp >= 90 && dayArray[currentDayIndex].CurrentTemp < 100)
            {
                cust.SetDesire(60, 101);
            }
        }

        public void ApplyWeatherDesire(Customer cust)
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

        public void ApplyCustomerBought(Customer cust)
        {
            //corner cases
            if (cust.CustomerDesire <= 0)
            {
                cust.CustomerDesire = 0;
            }
            else if (cust.CustomerDesire >= 100)
            {
                cust.CustomerDesire = 100;
            }

            //check if wants to buy
            if (cust.CustomerDesire >= 80)
            {
                cust.CustomerWillBuy = true;
                totalBought += 1;
            }
            else
            {
                cust.CustomerWillBuy = false;
            }
        }

        public void ApplyTotalDesire(Customer cust)
        {
            cust.CustomerDesire = 0;
            ApplyTempDesire(cust);
            ApplyWeatherDesire(cust);
            ApplyCustomerBought(cust);
        }

        public void SetUpRecipe()
        {
            UserInterface.NewLine();
            Console.WriteLine(" --  Recipe -- ");
            UserInterface.NewLine();


        }

        public void GameLoop()
        {
            Introduction();

            AskWeek();
            AddDays();

            while (currentDayIndex < dayArrayMax)
            {
                
                dayArray[currentDayIndex].ApplyDayWeather();
                AskIfBuy();
                SetUpRecipe();
                SetUpCustomers();
                
                Console.WriteLine(totalBought+" Total customers today!");
                //other game methods

                NextDay();
                UserInterface.NewLine();

            }
            Console.WriteLine("TEST GAME OVER");
        }

        public void AskIfBuy()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Day "+ dayArray[currentDayIndex].dayNum+". Forecast: "+ dayArray[currentDayIndex].CurrentForecast+", Temperature: "+ dayArray[currentDayIndex].CurrentTemp);
                Console.WriteLine("Would you like to go to the store before you open your stand for the day? y/n");
                string doesBuy = Console.ReadLine();

                switch (doesBuy)
                {
                    case "y":
                        isInputValid = true;
                        UserInterface.NewLine();
                        Console.WriteLine("You enter the store with $" + Player1.Wallet + ". What would you like to buy?");
                        AskWhatBuy();
                        break;
                    case "n":
                        isInputValid = true;
                        UserInterface.NewLine();
                        Console.WriteLine("You start the day without going to the store.");
                        StartDay();
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
            
        }

        public void StartDay()
        {

        }

        public void AskWhatBuy()
        {    
            Console.WriteLine("'p' for 10 paper cups ($" + GameStore.storePrices[0] + ").");
            Console.WriteLine("'l' for 10 lemons ($" + GameStore.storePrices[1] + ").");
            Console.WriteLine("'s' for 10 cups of sugar ($" + GameStore.storePrices[2] + ").");
            Console.WriteLine("'i' for 10 ice cubes ($" + GameStore.storePrices[3] + ").");
            Console.WriteLine("'inv' to check your inventory.");
            Console.WriteLine("'exit' to exit the store.");
            Console.WriteLine("'options' to see this list again.");
            UserInterface.NewLine();
            BuyOptions();
        }

        public void Purchase(int product)
        {
            Player1.Wallet -= GameStore.storePrices[product];
            PlayerInv.ChangeInv(product);
            Console.WriteLine("You buy 10 " + GameStore.storeOptions[product]);
            Console.WriteLine("You now have $" + Player1.Wallet);
            UserInterface.NewLine();
            BuyOptions();
        }

        public void checkInv()
        {
            Console.WriteLine("You have " +
            PlayerInv.InvSpace[0] +" paper cups, " +
            PlayerInv.InvSpace[1] + " lemons, " +
            PlayerInv.InvSpace[2] + " cups of sugar, and "+
            PlayerInv.InvSpace[3] + " ice cubes.");
            UserInterface.NewLine();
        }

        public void BuyOptions()
        {

            bool isInputValid = false;
            while (!isInputValid)
            {
                string option = Console.ReadLine();

                switch (option)
                {
                    case "p":
                        isInputValid = true;
                        Purchase(0);
                        break;
                    case "l":
                        isInputValid = true;
                        Purchase(1);
                        break;
                    case "s":
                        isInputValid = true;
                        Purchase(2);
                        break;
                    case "i":
                        isInputValid = true;
                        Purchase(3);
                        break;
                    case "inv":
                        isInputValid = true;
                        checkInv();
                        BuyOptions();
                        break;
                    case "options":
                        AskWhatBuy();
                        break;
                    case "exit":
                        isInputValid = true;
                        Console.WriteLine("You leave the store and open up your stand for the day.");
                        UserInterface.NewLine();
                        StartDay();
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
        }
    }
}
