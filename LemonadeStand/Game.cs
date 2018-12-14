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
        Recipe Recipe1;
        Store GameStore = new Store();
        Inventory PlayerInv = new Inventory();

        public Day[] dayArray;
        public Customer[] customerArray;

        public int currentDayIndex = 0;
        public int dayArrayMax = 0;
        public int totalBought;
        public bool bankruptcyEnd = false;
        public double prevWallet;

        //Game introduction text
        public void Introduction()
        {
            UserInterface.NewLine();
            Console.WriteLine(" --  Lemonade Stand! -- ");
            UserInterface.NewLine();
        }





        //Functions that set up game elements
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

        public void SetUpPlayers()
        {
            Player1 = new Player();
        }





        //GameLoop
        public void GameLoop()
        {
            Introduction();

            AskWeek();
            AddDays();

            while (currentDayIndex < dayArrayMax)
            {
                dayArray[currentDayIndex].ApplyDayWeather();
                AskIfBuy();
                if (bankruptcyEnd) { break; }
                SetUpRecipe();
                SetUpCustomers();
                ListProfits();
                NextDay();
                UserInterface.NewLine();
            }
        }





        //Functions that determine if and what the player buys at the store
        public void AskIfBuy()
        {
            dayArray[currentDayIndex].InitialWallet = Player1.Wallet;
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Day " + dayArray[currentDayIndex].dayNum + ". Forecast: " + dayArray[currentDayIndex].CurrentForecast + ", Temperature: " + dayArray[currentDayIndex].CurrentTemp);
                Console.WriteLine("Would you like to go to the store before you open your stand for the day? y/n");
                string doesBuy = Console.ReadLine();

                switch (doesBuy)
                {
                    case "y":
                        isInputValid = true;
                        UserInterface.NewLine();
                        Console.WriteLine("You enter the store with $" + Player1.Wallet.ToString("f2") + ". What would you like to buy?");
                        AskWhatBuy();
                        break;
                    case "n":
                        isInputValid = true;
                        UserInterface.NewLine();
                        Console.WriteLine("You start the day without going to the store.");
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
        }

        public void AskWhatBuy()
        {
            Console.WriteLine("'p' for 10 paper cups ($" + GameStore.storePrices[0].ToString("f2") + ").");
            Console.WriteLine("'l' for 10 lemons ($" + GameStore.storePrices[1].ToString("f2") + ").");
            Console.WriteLine("'s' for 10 cups of sugar ($" + GameStore.storePrices[2].ToString("f2") + ").");
            Console.WriteLine("'i' for 100 ice cubes ($" + GameStore.storePrices[3].ToString("f2") + ").");
            Console.WriteLine("'inv' to check your inventory.");
            Console.WriteLine("'exit' to exit the store.");
            Console.WriteLine("'options' to see this list again.");
            UserInterface.NewLine();
            BuyOptions();
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
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
        }

        public void Purchase(int product)
        {
            if (Player1.Wallet == 0)
            {
                Console.WriteLine("You have no more money!");
                Bankruptcy();
            }
            else if (Player1.Wallet - GameStore.storePrices[product] <= 0)
            {
                Console.WriteLine("You dont have enough money to buy " + GameStore.storeOptions[product] + "!");
                BuyOptions();
            }
            else
            {
                Player1.Wallet -= GameStore.storePrices[product];
                PlayerInv.ChangeInv(product);
                if (product == 3)
                {
                    Console.WriteLine("You buy 100 " + GameStore.storeOptions[product]);
                }
                else
                {
                    Console.WriteLine("You buy 10 " + GameStore.storeOptions[product]);
                }
                checkInv();
                BuyOptions();
            }
        }

        public void Bankruptcy()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Will you declare bankruptcy and end the game? y/n");
                string doesDeclare = Console.ReadLine();
                switch (doesDeclare)
                {
                    case "y":
                        Console.WriteLine("You have declared bankruptcy!");
                        bankruptcyEnd = true;
                        isInputValid = true;
                        break;
                    case "n":
                        Console.WriteLine("You leave the store and open up your stand for the day.");
                        Player1.Wallet = 0;
                        bankruptcyEnd = false;
                        isInputValid = true;
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        bankruptcyEnd = false;
                        break;
                }
            }
        }

        public void checkInv()
        {
            Console.WriteLine("You have $" +
            Player1.Wallet.ToString("f2") + ", " +
            PlayerInv.InvSpace[0] + " paper cup(s), " +
            PlayerInv.InvSpace[1] + " lemon(s), " +
            PlayerInv.InvSpace[2] + " cup(s) of sugar, and " +
            PlayerInv.InvSpace[3] + " ice cube(s).");
            UserInterface.NewLine();
        }





        //Functions that deal with the recipe system
        public void SetUpRecipe()
        {
            Recipe1 = new Recipe();
            UserInterface.NewLine();
            Console.WriteLine(" --  Recipe -- ");
            UserInterface.NewLine();
            MakeRecipe();
        }

        public void MakeRecipe()
        {
            Recipe1.LemCount = 0;
            UseCups();
            UseLemons();
            UseSugar();
            UseIce();
            AskPrice();
        }

        public void UseCups()
        {
            Recipe1.CupNum = 0;
            Console.WriteLine($"How many paper cups would you like to use? You have " + PlayerInv.InvSpace[0]);
            Recipe1.CupsUsed = Console.ReadLine();

            int myInt;
            bool isNumerical = int.TryParse(Recipe1.CupsUsed, out myInt);

            if (isNumerical)
            {
                Recipe1.CupNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
                UseCups();
            }

            if (Recipe1.CupNum > PlayerInv.InvSpace[0])
            {
                Console.WriteLine("Too many paper cups! You only have " + PlayerInv.InvSpace[0]);
                UserInterface.NewLine();
                UseCups();
            }
            PlayerInv.InvSpace[0] -= Recipe1.CupNum;
            UserInterface.NewLine();
        }

        public void UseLemons()
        {
            Recipe1.LemNum = 0;
            Console.WriteLine("How many lemons would you like to use? You have " + PlayerInv.InvSpace[1]);
            Recipe1.LemonsUsed = Console.ReadLine();

            int myInt;
            bool isNumerical = int.TryParse(Recipe1.LemonsUsed, out myInt);

            if (isNumerical)
            {
                Recipe1.LemNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
                UseLemons();
            }

            if (Recipe1.LemNum > PlayerInv.InvSpace[1])
            {
                Console.WriteLine("Too many lemons! You only have " + PlayerInv.InvSpace[1]);
                UserInterface.NewLine();
                UseLemons();
            }
            PlayerInv.InvSpace[1] -= Recipe1.LemNum;
            UserInterface.NewLine();
        }

        public void UseSugar()
        {
            Recipe1.SugNum = 0;
            Console.WriteLine("How many cups of sugar would you like to use? You have " + PlayerInv.InvSpace[2]);
            Recipe1.SugarUsed = Console.ReadLine();

            int myInt;
            bool isNumerical = int.TryParse(Recipe1.SugarUsed, out myInt);

            if (isNumerical)
            {
                Recipe1.SugNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
                UseSugar();
            }

            if (Recipe1.SugNum > PlayerInv.InvSpace[2])
            {
                Console.WriteLine("Too many cups of sugar! You only have " + PlayerInv.InvSpace[2]);
                UserInterface.NewLine();
                UseSugar();
            }
            PlayerInv.InvSpace[2] -= Recipe1.SugNum;
            UserInterface.NewLine();
        }

        public void UseIce()
        {
            Recipe1.IceNum = 0;
            Console.WriteLine("How many ice cubes would you like to use? You have " + PlayerInv.InvSpace[3]);
            Recipe1.IceUsed = Console.ReadLine();

            int myInt;
            bool isNumerical = int.TryParse(Recipe1.IceUsed, out myInt);

            if (isNumerical)
            {
                Recipe1.IceNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
                UseIce();
            }

            if (Recipe1.IceNum > PlayerInv.InvSpace[3])
            {
                Console.WriteLine("Too many ice cubes! You only have " + PlayerInv.InvSpace[3]);
                UserInterface.NewLine();
                UseIce();
            }
            PlayerInv.InvSpace[3] -= Recipe1.IceNum;
            UserInterface.NewLine();
        }

        public void AskPrice()
        {
            Recipe1.PriceNum = 0;
            Console.WriteLine("How much should each cup of lemonade cost? Enter a value between 1 and 100 cents.");
            Recipe1.PriceUsed = Console.ReadLine();

            int myInt;
            bool isNumerical = int.TryParse(Recipe1.PriceUsed, out myInt);

            if (isNumerical)
            {
                Recipe1.PriceNum = myInt;
                myInt = 0;
            }
            else
            {
                Console.WriteLine("Please try again.");
                AskPrice();
            }

            if (Recipe1.PriceNum == 0)
            {
                Console.WriteLine("That's nice of you, but your business will go under if you give away free lemonade. Try again.");
                AskPrice();
            }
            if (Recipe1.PriceNum > 100)
            {
                Console.WriteLine("Try to be realistic. If people pay that much it's only because they pity you. Try again.");
                AskPrice();
            }
        }





        //Functions that deal with customers and their decisions.
        public void SetUpCustomers()
        {
            totalBought = 0;
            customerArray = new Customer[100];
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
                    ApplyTotalDesire(customerArray[i]);
                }

            }
            SoldOutText();
            ResetItems();
        }

        public void ApplyTotalDesire(Customer cust)
        {
            cust.CustomerDesire = 0;
            ApplyTempDesire(cust);
            ApplyWeatherDesire(cust);
            ApplyWalletDesire(cust);
            ApplyCustomerBought(cust);
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

        public void ApplyWalletDesire(Customer cust)
        {
            if (Recipe1.PriceNum >= 70)
            {
                cust.CustomerDesire -= 5;
            }
            else if (Recipe1.PriceNum <= 30)
            {
                cust.CustomerDesire += 5;
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
                Consume();
            }
            else
            {
                cust.CustomerWillBuy = false;
            }
        }

        public void Consume()
        {
            Recipe1.CupNum -= 1;
            Recipe1.SugNum -= 1;

            //ice takes fewer customers to be consumed
            Recipe1.IceNum -= 2;

            //lemon takes more customers to be consumed
            Recipe1.LemCount += 1;
            if (Recipe1.LemCount >= 5)
            {
                Recipe1.LemNum -= 1;
                Recipe1.LemCount = 0;
            }
        }





        //Functions that deal with the consumption of products throughout the day
        public void SoldOutText()
        {
            if (Recipe1.CupNum == 0)
            {
                Console.WriteLine("You ran out of paper cups!");
            }
            if (Recipe1.LemNum == 0)
            {
                Console.WriteLine("You ran out of lemons!");
            }
            if (Recipe1.SugNum == 0)
            {
                Console.WriteLine("You ran out of cups of sugar!");
            }
            if (Recipe1.IceNum == 0)
            {
                Console.WriteLine("You ran out of ice cubes!");
            }
        }

        public bool HasSoldOut()
        {
            bool soldOut = false;
            if (Recipe1.CupNum == 0)
            {
                soldOut = true;
            }
            if (Recipe1.LemNum == 0)
            {
                soldOut = true;
            }
            if (Recipe1.SugNum == 0)
            {
                soldOut = true;
            }
            if (Recipe1.IceNum == 0)
            {
                soldOut = true;
            }
            return soldOut;
        }

        public void ResetItems()
        {
            if (Recipe1.CupNum < 0)
            {
                Recipe1.CupNum = 0;
            }
            if (Recipe1.LemNum < 0)
            {
                Recipe1.LemNum = 0;
            }
            if (Recipe1.SugNum < 0)
            {
                Recipe1.SugNum = 0;
            }
            if (Recipe1.IceNum < 0)
            {
                Recipe1.IceNum = 0;
            }
        }





        //Functions that deal with the end-day loop
        public void NextDay()
        {
            LeftOvers();
            currentDayIndex += 1;
        }

        public void LeftOvers()
        {
            if (Recipe1.CupNum > 0)
            {
                Console.WriteLine("You had " + Recipe1.CupNum + " paper cup(s) left over! You put them in your inventory.");
            }
            if (Recipe1.LemNum > 0)
            {
                Console.WriteLine("You had " + Recipe1.LemNum + " lemon(s) left over! You put them in your inventory.");
            }
            if (Recipe1.SugNum > 0)
            {
                Console.WriteLine("You had " + Recipe1.SugNum + " cup(s) of sugar left over! You put them in your inventory.");
            }

            PlayerInv.InvSpace[0] += Recipe1.CupNum;
            PlayerInv.InvSpace[1] += Recipe1.LemNum;
            PlayerInv.InvSpace[2] += Recipe1.SugNum;

            //there will never be left over ice
            if (Recipe1.IceNum > 0)
            {
                Melt();
            }

            UserInterface.NewLine();
        }

        public void Melt()
        {
            Console.WriteLine("All your remaining ice cubes melted!");
            Recipe1.IceNum = 0;
            PlayerInv.InvSpace[3] = 0;
        }

        public void ListProfits()
        {
            Console.WriteLine("Today's weather was: " + dayArray[currentDayIndex].CurrentWeather);
            double listedTotal = 0;
            prevWallet = dayArray[currentDayIndex].InitialWallet;

            Player1.Wallet += Convert.ToDouble(Recipe1.PriceNum) * Convert.ToDouble(totalBought) / 100;
            Console.WriteLine(totalBought + " Total customer(s) today! You now have $" + Player1.Wallet.ToString("f2"));
            if ((Player1.Wallet - prevWallet) > 0)
            {
                Console.WriteLine("Today you made a profit of $" + (Player1.Wallet - prevWallet).ToString("f2") + "!");
            }
            else if ((Player1.Wallet - prevWallet) < 0)
            {
                Console.WriteLine("Today you lost $" + (-1 * (Player1.Wallet - prevWallet)).ToString("f2") + "!");
            }
            if (Player1.Wallet == prevWallet)
            {
                Console.WriteLine("You made no money today!");
            }
            Player1.TotalProfits.Add(Player1.Wallet - prevWallet);
            foreach (double profit in Player1.TotalProfits)
            {
                listedTotal += profit;
            }
            Console.WriteLine("Your total profit so far is $" + listedTotal.ToString("f2"));
        }  
    }
}
