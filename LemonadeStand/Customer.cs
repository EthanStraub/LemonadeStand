using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        
        private int customerDesire = 0;
        private int customerPriceBracket = 0;
        private bool customerWillBuy = false;

        public int CustomerDesire { get { return customerDesire; } set { customerDesire = value; } }
        public int CustomerPriceBracket { get { return customerPriceBracket; } set { customerPriceBracket = value; } }
        public bool CustomerWillBuy { get { return customerWillBuy; } set { customerWillBuy = value; } }

        public void SetDesire(int rand1, int rand2)
        {
            CustomerDesire = UserInterface.RandomNumber(rand1, rand2);
        }
    }
}
