using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLogic
{
    class BlackPlayer : IHumanPlayer
    {
        private CheckerColor color;
        private int startPos;
        private int homePos;
        public BlackPlayer(CheckerColor initColor)
        {
            color = initColor;
            Turns = 0;
            IsPlayerTurn = false;
            startPos = 24;
            homePos = 5;
        }
        public bool IsPlayerTurn { get; set; }
        public int Turns { get; set; }
        public CheckerColor Color
        {
            get
            {
                return color;
            }
        }

        public bool CheckBearOffStage(Board currBoard)
        {
            for (int i = homePos + 1; i < startPos; i++)
            {
                if (currBoard[i].Color == color)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPlayerWon(Board currBoard)
        {
            for (int i = 0; i < 24; i++)
            {
                if(currBoard[i].Color == color)
                {
                    return false;
                }
            }
            return true;
        }
        public bool MakeBarMove(int Move, Board currBoard)
        {
            if (currBoard[startPos - Move].IsAvailable(color))
            {
                if (currBoard[startPos - Move].Color == CheckerColor.Empty)
                {
                    currBoard.DecreaseFirstPlayerBar();
                    currBoard[startPos - Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[startPos - Move].Color == color)
                {
                    currBoard.DecreaseFirstPlayerBar();
                    currBoard[startPos - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard.DecreaseFirstPlayerBar();
                    currBoard.IncreaseSecondPlayerBar();
                    currBoard[startPos - Move].RemoveChecker();
                    currBoard[startPos - Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool MakeMove(int currentIndex, int Move, Board currBoard)
        {
            if (currentIndex - Move < 0)
            {
                return false;
            }
            if (currBoard[currentIndex - Move].IsAvailable(color))
            {
                if (currBoard[currentIndex - Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[currentIndex - Move].Color == color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.IncreaseSecondPlayerBar();
                    currBoard[currentIndex - Move].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool MakeBearOffMove(int currentIndex, int Move, Board currBoard)
        {
            if (currentIndex - Move < 0)
            {
                currBoard[currentIndex].RemoveChecker();
                return true;
            }

            else if (currBoard[currentIndex - Move].IsAvailable(color))
            {
                if (currBoard[currentIndex - Move].Color == CheckerColor.Empty)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(color);
                    return true;
                }
                else if (currBoard[currentIndex - Move].Color == color)
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker();
                    return true;
                }
                else
                {
                    currBoard[currentIndex].RemoveChecker();
                    currBoard.IncreaseSecondPlayerBar();
                    currBoard[currentIndex - Move].RemoveChecker();
                    currBoard[currentIndex - Move].AddChecker(color);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckLegalBarMoves(Dice currDice, Board currBoard)
        {
            if (currBoard[startPos - currDice.FirstDice].IsAvailable(color))
            {
                return true;
            }
            if (!currDice.IsDouble)
            {
                if (currBoard[startPos - currDice.SecondDice].IsAvailable(color))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckLegalMoves(Dice currDice, Board currBoard)
        {
            for (int i = 0; i < startPos; i++)
            {
                if (i - currDice.FirstDice >= 0)
                {
                    if (currBoard[i - currDice.FirstDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
                if (i - currDice.SecondDice >= 0 &&
                    !currDice.IsDouble)
                {
                    if (currBoard[i - currDice.SecondDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckLegalBearOffMoves(Dice currDice, Board currBoard)
        {
            for (int i = 0; i <= homePos; i++)
            {
                if (i - currDice.FirstDice >= 0)
                {
                    if (currBoard[i - currDice.FirstDice].IsAvailable(color))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
                if (!currDice.IsDouble)
                {
                    if (i - currDice.SecondDice >= 0)
                    {
                        if (currBoard[i - currDice.SecondDice].IsAvailable(color))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
