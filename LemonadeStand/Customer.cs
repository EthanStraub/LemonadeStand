using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private bool customerBuys;
        
        public bool CustomerBuys
        {
            get
            {
                return customerBuys;
            }
            set
            {
                customerBuys = value;
            }
        }
    }
}
