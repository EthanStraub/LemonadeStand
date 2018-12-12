using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        private int[] invSpace = { 0, 0, 0, 0 };
        public int[] InvSpace
        {
            get
            {
                return invSpace;
            }
            set
            {
                invSpace = value;
            }
        }
        public void ChangeInv(int newItem)
        {
            InvSpace[newItem] += 10;   
        }
    }
}
