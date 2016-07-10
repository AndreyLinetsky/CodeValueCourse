using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Point
    {
        private int checkersAmount;
        private CheckerColor color;

        public Point()
        {
            checkersAmount = 0;
            color = CheckerColor.Empty;
        }
        public Point(int initCheckers, CheckerColor initcolor)
        {
            checkersAmount = initCheckers;
            color = initcolor;
        }

        public int CheckersAmount
        {
            get
            {
                return checkersAmount;
            }
        }

        public CheckerColor Color
        {
            get
            {
                return color;
            }
        }
        public bool IsAvailable(CheckerColor inputColor)
        {
            if (color == CheckerColor.Empty)
            {
                return true;
            }
            else if (color == inputColor)
            {
                return true;
            }
            else
            {
                if (checkersAmount == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool RemoveChecker()
        {
            if (checkersAmount > 0)
            {
                checkersAmount--;
                if (checkersAmount == 0)
                {
                    color = CheckerColor.Empty;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddChecker()
        {
            checkersAmount++;
        }
        public void AddChecker(CheckerColor newColor)
        {
            color = newColor;
            checkersAmount = 1;
        }
    }
}
