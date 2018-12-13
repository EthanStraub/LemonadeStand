using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UserInterface
    {
        public static Random random = new Random();

        public static void NewLine()
        {
            Console.WriteLine("");
        }

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
