using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandSecondaryTest
{
    [TestClass]
    public class CustomerTest
    {
        private int customerDesire = 0;
        private int customerPriceBracket = 0;
        private bool customerWillBuy = false;

        public int CustomerDesire { get { return customerDesire; } set { customerDesire = value; } }
        public int CustomerPriceBracket { get { return customerPriceBracket; } set { customerPriceBracket = value; } }
        public bool CustomerWillBuy { get { return customerWillBuy; } set { customerWillBuy = value; } }

        [TestMethod]
        public void SetDesire(int rand1, int rand2)
        {
            CustomerDesire = LemonadeStand.UserInterface.RandomNumber(rand1, rand2);
        }
    }
}
