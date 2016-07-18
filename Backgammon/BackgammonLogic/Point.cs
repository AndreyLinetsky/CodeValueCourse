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
        public Point(int initCheckers, CheckerColor initcolor)
        {
            CheckersAmount = initCheckers;
            Color = initcolor;
        }
        public int CheckersAmount { get; private set; }
        public CheckerColor Color { get; private set; }
        public bool IsAvailable(CheckerColor inputColor)
        {
            return Color == CheckerColor.Empty || Color == inputColor || CheckersAmount == 1;
        }
        public void RemoveChecker()
        {
            CheckersAmount--;
            if (CheckersAmount == 0)
            {
                Color = CheckerColor.Empty;
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
