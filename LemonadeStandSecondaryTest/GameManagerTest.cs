using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandSecondaryTest
{
    [TestClass]
    public class GameManagerTest
    {
        GameTest gameOne;

        [TestMethod]
        public GameTest MakeGame()
        {
            return new GameTest();
        }

        public void StartGame()
        {
            gameOne = MakeGame();
        }
    }
}
