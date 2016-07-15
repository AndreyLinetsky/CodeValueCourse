using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Dices
    {
        public Dices()
        {
            ResetFirstDice();
            ResetSecondDice();
        }
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set; }

        public bool IsDouble
        {
            get
            {
                return FirstDice == SecondDice;
            }
        }

        public void ThrowDice()
        {
            Random rnd = new Random();
            FirstDice = rnd.Next(1, 7);
            SecondDice = rnd.Next(1, 7);
        }
        public void ResetFirstDice()
        {
            FirstDice = 0;
        }
        public void ResetSecondDice()
        {
            SecondDice = 0;
        }
    }
}