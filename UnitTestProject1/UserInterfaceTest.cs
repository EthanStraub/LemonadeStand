using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTestProject
{
    [TestClass]
    public class UserInterfaceTest
    {

        [TestMethod]
        public void RandomNumber_PositiveIntegers_ReturnTrue()
        {
            int min = 0;
            int max = 4;

            Random random = new Random();
            random.Next(min, max);

            Assert.AreNotEqual(random, 4);
        }
    }
}
