using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    internal class Dice
    {
        private int firstDice;
        private int secondDice;
        private bool isDouble;

        public Dice()
        {
            ResetFirstDice();
            ResetSecondDice();
        }

        public int FirstDice
        {
            get
            {
                return firstDice;
            }
        }

        public int SecondDice
        {
            get
            {
                return secondDice;
            }
        }

        public bool IsDouble
        {
            get
            {
                return isDouble;
            }
        }

        public void ThrowDice()
        {
            isDouble = false;
            Random rnd = new Random();
            firstDice = rnd.Next(1, 7);
            secondDice = rnd.Next(1, 7);
            if (firstDice == secondDice)
            {
                isDouble = true;
            }
        }
        public void ResetFirstDice()
        {
            firstDice = 0;
        }
        public void ResetSecondDice()
        {
            secondDice = 0;
        }
    }
}