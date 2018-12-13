using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        private string cupsUsed;
        private string lemonsUsed;
        private string sugarUsed;
        private string iceUsed;
        private string priceUsed;

        public string CupsUsed { get { return cupsUsed; } set { cupsUsed = value; } }
        public string LemonsUsed { get { return lemonsUsed; } set { lemonsUsed = value; } }
        public string SugarUsed { get { return sugarUsed; } set { sugarUsed = value; } }
        public string IceUsed { get { return iceUsed; } set { iceUsed = value; } }
        public string PriceUsed { get { return priceUsed; } set { priceUsed = value; } }


    }
}
