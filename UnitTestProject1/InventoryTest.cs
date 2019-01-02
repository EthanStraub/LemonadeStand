using System;
using LemonadeStand;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonadeStandTestProject
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void ChangeInv_Three_Return100InSlotThree()
        {
            int[] invSpace = new int[4];
            int newItem = 3;

            if (newItem == 3)
            {
                invSpace[newItem] += 100;
            }
            else
            {
                invSpace[newItem] += 10;
            }
            Assert.AreEqual(invSpace[3], 100);
        }

        [TestMethod]
        public void ChangeInv_NumberOtherThanThree_Return10InRespectiveSlot()
        {
            int[] invSpace = new int[4];
            int newItem = 2;

            if (newItem == 3)
            {
                invSpace[newItem] += 100;
            }
            else
            {
                invSpace[newItem] += 10;
            }
            Assert.AreEqual(invSpace[2], 10);
        }
    }
}
