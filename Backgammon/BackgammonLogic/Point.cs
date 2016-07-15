using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Point
    {
        public Point()
        {
            CheckersAmount = 0;
            Color = CheckerColor.Empty;
        }
        public int CheckersAmount { get; private set; }
        public CheckerColor Color { get; private set; }
        public Point(int initCheckers, CheckerColor initcolor)
        {
            CheckersAmount = initCheckers;
            Color = initcolor;
        }

        public bool IsAvailable(CheckerColor inputColor)
        {
            if (Color == CheckerColor.Empty)
            {
                return true;
            }
            else if (Color == inputColor)
            {
                return true;
            }
            else
            {
                if (CheckersAmount == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveChecker()
        {
            if (CheckersAmount > 0)
            {
                CheckersAmount--;
                if (CheckersAmount == 0)
                {
                    Color = CheckerColor.Empty;
                }
            }
        }
        public void AddChecker()
        {
            CheckersAmount++;
        }
        public void AddChecker(CheckerColor newColor)
        {
            Color = newColor;
            CheckersAmount = 1;
        }
    }
}
