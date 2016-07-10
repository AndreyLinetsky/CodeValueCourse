using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    internal class Board
    {
        private Point[] points;
        private int firstPlayerBarCheckers;
        private int secondPlayerBarCheckers;

        public Board()
        {
            points = new Point[24];
            firstPlayerBarCheckers = 0;
            secondPlayerBarCheckers = 0;
            InitBoard();
        }

        public Point this[int index]
        {
            get
            {
                return points[index];
            }
        }

        public int FirstPlayerBarCheckers
        {
            get
            {
                return firstPlayerBarCheckers;
            }
        }

        public int SecondPlayerBarCheckers
        {
            get
            {
                return secondPlayerBarCheckers;
            }
        }
        public bool DecreaseFirstPlayerBar()
        {
            if (firstPlayerBarCheckers > 0)
            {
                firstPlayerBarCheckers--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DecreaseSecondPlayerBar()
        {
            if (secondPlayerBarCheckers > 0)
            {
                secondPlayerBarCheckers--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void IncreaseFirstPlayerBar()
        {
            firstPlayerBarCheckers++;
        }
        public void IncreaseSecondPlayerBar()
        {
            secondPlayerBarCheckers++;
        }

        public void InitBoard()
        {
            for (int i = 0; i < points.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        points[i] = new Point(2, CheckerColor.White);
                        break;
                    case 5:
                        points[i] = new Point(5, CheckerColor.Black);
                        break;
                    case 7:
                        points[i] = new Point(3, CheckerColor.Black);
                        break;
                    case 11:
                        points[i] = new Point(5, CheckerColor.White);
                        break;
                    case 12:
                        points[i] = new Point(5, CheckerColor.Black);
                        break;
                    case 16:
                        points[i] = new Point(3, CheckerColor.White);
                        break;
                    case 18:
                        points[i] = new Point(5, CheckerColor.White);
                        break;
                    case 23:
                        points[i] = new Point(2, CheckerColor.Black);
                        break;
                    default:
                        points[i] = new Point();
                        break;
                }
            }
        }
    }
}
