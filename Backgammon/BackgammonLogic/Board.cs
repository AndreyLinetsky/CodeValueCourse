using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    public class Board
    {
        public Board()
        {
            Points = new Point[24];
            FirstBar = new Bar(CheckerColor.Black);
            SecondBar = new Bar(CheckerColor.Green);
            InitBoard();
        }

        public Point this[int index]
        {
            get
            {
                return Points[index];
            }
        }

        public Point[] Points { get; private set; }
        public int BarSource { get; } = 24;

        private Bar FirstBar { get; set; }
        private Bar SecondBar { get; set; }

        public bool IsCheckersLeft(CheckerColor color)
        {
            return Points.Any(p => p.Color == color);
        }
        public Bar GetBar(CheckerColor barColor)
        {
            if (FirstBar.Color == barColor)
            {
                return FirstBar;
            }
            else
            {
                return SecondBar;
            }
        }
        public Bar GetOtherBar(CheckerColor barColor)
        {
            if (FirstBar.Color == barColor)
            {
                return SecondBar;
            }
            else
            {
                return FirstBar;
            }
        }
        public void InitBoard()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Points[i] = new Point(2, CheckerColor.Green);
                        break;
                    case 5:
                        Points[i] = new Point(5, CheckerColor.Black);
                        break;
                    case 7:
                        Points[i] = new Point(3, CheckerColor.Black);
                        break;
                    case 11:
                        Points[i] = new Point(5, CheckerColor.Green);
                        break;
                    case 12:
                        Points[i] = new Point(5, CheckerColor.Black);
                        break;
                    case 16:
                        Points[i] = new Point(3, CheckerColor.Green);
                        break;
                    case 18:
                        Points[i] = new Point(5, CheckerColor.Green);
                        break;
                    case 23:
                        Points[i] = new Point(2, CheckerColor.Black);
                        break;
                    default:
                        Points[i] = new Point();
                        break;
                }
            }
        }
    }
}
