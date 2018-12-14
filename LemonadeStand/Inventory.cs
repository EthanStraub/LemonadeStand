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
        public int[] InvSpace { get { return invSpace; } set { invSpace = value; } }

        public void ChangeInv(int newItem)
        {
            if (newItem == 3)
            {
                InvSpace[newItem] += 100;
            }
            else
            {
                InvSpace[newItem] += 10;
            }
        }
    }
}
