using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameManager
    {
        Game gameOne;
        bool isRunning = true;

        public Game MakeGame()
        {
            return new Game();
        }

        public void StartGame()
        {
            gameOne = MakeGame();
            gameOne.SetUpPlayers();
            gameOne.GameLoop();
        }

        public void RestartGame()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                string winOption = Console.ReadLine();
                switch (winOption)
                {
                    case "restart":
                        isInputValid = true;
                        break;
                    case "quit":
                        isInputValid = true;
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
        }

        public void StartManager()
        {
            while (isRunning)
            {
                StartGame();
                RestartGame();
            }
        }
    }
}
