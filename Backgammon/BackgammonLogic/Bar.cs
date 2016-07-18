using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Bar
    {
        public Bar(CheckerColor initColor)
        {
            Checkers = 0;
            Color = initColor;
        }

        public int Checkers { get; private set; }

        public CheckerColor Color { get; private set; }

        public void RemoveBarChecker()
        {
            Checkers--;
        }

        public void AddBarChecker()
        {
            Checkers++;
        }
    }
}

