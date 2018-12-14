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

        private int cupNum;
        private int lemNum;
        private int sugNum;
        private int iceNum;
        private int priceNum;
        private int lemCount;

        public int CupNum { get { return cupNum; } set { cupNum = value; } }
        public int LemNum { get { return lemNum; } set { lemNum = value; } }
        public int SugNum { get { return sugNum; } set { sugNum = value; } }
        public int IceNum { get { return iceNum; } set { iceNum = value; } }
        public int PriceNum { get { return priceNum; } set { priceNum = value; } }
        public int LemCount { get { return lemCount; } set { lemCount = value; } }
    }
}
