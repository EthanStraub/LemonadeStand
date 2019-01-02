using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        internal GameManager GameManager
        {
            get => default(GameManager);
            set
            {
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            GameManager NewManager = new GameManager();
            NewManager.StartManager();
        }
    }
}
