using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTestProject
{
    [TestClass]

    class GameManager
    {
        [TestMethod]
        public void RestartGame_True_QuitsProgram()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                string winOption = "quit";
                switch (winOption)
                {
                    case "restart":          
                        break;
                    case "quit":
                        isInputValid = true;
                        //System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
            Assert.IsTrue(isInputValid);
        }

        [TestMethod]
        public void RestartGame_InvalidInput_ReturnsMesage()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                string winOption = "exit1234";
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
            Assert.IsFalse(isInputValid);
        }
    }
}
