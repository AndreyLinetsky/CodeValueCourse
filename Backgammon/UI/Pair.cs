using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLogic;
namespace UI
{
    public class Pair
    {
        public Pair()
        {
            Amount = 0;
            Color = CheckerColor.Empty;
        }
        public Pair(int am, CheckerColor co)
        {
            Amount = am;
            Color = co;
        }
        public CheckerColor Color { get; set; }
        public int Amount { get; set; }
    }
}
