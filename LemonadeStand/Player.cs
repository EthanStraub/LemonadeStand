﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        private double wallet = 20.00;
        public double Wallet { get { return wallet; } set { wallet = value; } }

        private List<double> totalProfits = new List<double>();
        public List<double> TotalProfits { get { return totalProfits; } set { totalProfits = value; } }
    }
}
